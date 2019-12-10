using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilenioRadartonaAPI.Context;
using MilenioRadartonaAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Controllers
{
    public class PerfilController : Controller
    {

        private readonly ApplicationContext _ctx;

        public PerfilController(ApplicationContext ctx)
        {
            _ctx = ctx;
        }


        [HttpPost]
        public IActionResult AlteraDadosSimples([FromBody] MudaPerfilDTO mudancas)
        {
            if (User.Identity.Name != null)
            {
                string email = User.Identity.Name;
                var usuario = _ctx.Usuarios.Where(u => u.Email.Equals(email)).FirstOrDefault();
                usuario.Celular = mudancas.Celular;
                usuario.Nome = mudancas.Nome;

                _ctx.Attach(usuario).State = EntityState.Modified;
                _ctx.SaveChanges();

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }





    }
}



