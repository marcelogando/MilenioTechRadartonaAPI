using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MilenioRadartonaAPI.Areas.Identity.Data;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Service;

namespace MilenioRadartonaAPI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<MilenioRadartonaAPIUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IOptions<MyConfig> _config;

        public ForgotPasswordModel(UserManager<MilenioRadartonaAPIUser> userManager, IEmailSender emailSender, IOptions<MyConfig> config)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _config = config;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                _emailSender.SendEmailAsync(
                    Input.Email,
                    "Mudar Senha",
                    $"Por favor, mude sua senha ao <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicar aqui</a>.", "servico@mileniotech.com.br", "Milênio Tech - Servicos",
                    _config.Value.EmailAdministrador,
                    _config.Value.SenhaEmailAdministrador);

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
