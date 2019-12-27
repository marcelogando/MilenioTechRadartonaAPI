using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MilenioRadartonaAPI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Token;
using MilenioRadartonaAPI.Context;

namespace MilenioRadartonaAPI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MilenioRadartonaAPIUser> _signInManager;
        private readonly UserManager<MilenioRadartonaAPIUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationContext _ctx;

        public RegisterModel(SignInManager<MilenioRadartonaAPIUser> signInManager, UserManager<MilenioRadartonaAPIUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<RegisterModel> logger, ApplicationContext ctx)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _ctx = ctx;
        }

        //private readonly IEmailSender _emailSender;



        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "{0} tem que ter no minimo 11 caracteres e 15 no maximo.")]
            [MinLength(11, ErrorMessage = "{0} tem que ter no minimo 11 caracteres e 15 no maximo.")]
            [Display(Name = "Celular")]
            public string Celular { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} tem que ter no minimo {2} e no maximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "Senhas não batem.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
           
            if (ModelState.IsValid)
            {
                var user = new MilenioRadartonaAPIUser { UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.Celular};

                var result = await _userManager.CreateAsync(user, Input.Password);
                try
                {

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Usuario criou uma nova conta com a senha.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //    $"Por favor confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>.");

                        await _roleManager.CreateAsync(new IdentityRole(Roles.ROLE_API_RADAR));
                        var userIdentity = _userManager.FindByNameAsync(Input.Email).Result;
                
                        await _userManager.AddToRoleAsync(userIdentity, Roles.ROLE_API_RADAR);

                        returnUrl = returnUrl ?? Url.Content("~/Intra/Index/");

                        await _signInManager.SignInAsync(user, isPersistent: false);

                        /*  Criar o usuario nosso  */

                        Usuario usuario = new Usuario()
                        {
                            Bloqueado = false,
                            Celular = Input.Celular,
                            Email = Input.Email,
                            CriacaoDeConta = DateTime.Now,
                            UltimaMudancaDeSenha = DateTime.Now,
                            TipoUsuario = Roles.ROLE_API_RADAR,                            
                            Nome = Input.Nome, 
                        };

                        IList<RequisicaoInfos> reqs = new List<RequisicaoInfos>();
                        RequisicaoInfos req = new RequisicaoInfos()
                        {
                            QtdReqFeitasNoDia = 0,
                            QtdReqDiaMax = 1000,
                            DiaRequisicao = DateTime.Now,
                            Usuario = usuario,
                        };

                        reqs.Add(req);
                        usuario.ReqInfos = reqs;

                        _ctx.Usuarios.Add(usuario);
                        _ctx.SaveChanges();

                        User userLogin = new User();
                        userLogin.UserID = Input.Email;
                        userLogin.Password = Input.Password;

                        returnUrl = Url.Content("~/api/Login/" + userLogin.UserID + "/" + userLogin.Password);

                        return LocalRedirect(returnUrl);

                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
