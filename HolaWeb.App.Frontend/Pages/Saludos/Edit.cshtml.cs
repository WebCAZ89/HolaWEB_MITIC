using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HolaWeb.App.Dominio;
using HolaWeb.App.Persistencia.AppRepositorios;

namespace HolaWeb.App.Frontend.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioSaludos repositorioSaludos;
        public Saludo Saludo { get; set; }
        public EditModel(IRepositorioSaludos repositorioSaludos)
        {
            this.repositorioSaludos = repositorioSaludos;
        }
        public IActionResult OnGet(int? saludoId)
        {
            if (saludoId.HasValue)
            {
                Saludo = repositorioSaludos.GetSaludosPorId(saludoId.Value);
            }
            else
            {
                Saludo = new Saludo();
            }
            if (Saludo == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
        public IActionResult OnPost()
        {
            if(Saludo.Id>0)
            {
                Saludo = repositorioSaludos.Update(Saludo);
            }
            else
            {
                repositorioSaludos.Add(Saludo);
            }
            return Page();
        }
    }
}
