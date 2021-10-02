using System;
using System.Collections.Generic;
using System.Linq;
using HolaWeb.App.Dominio;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;

        public RepositorioSaludosMemoria()
        {
            saludos= new List<Saludo>()
            {
                new Saludo{Id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno"},
                new Saludo{Id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon pomeriggio"},
                new Saludo{Id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona notte"}

            };
        }

        public Saludo Add(Saludo nuevoSaludo)
        {
            nuevoSaludo.Id=saludos.Max(r => r.Id)+1;
            saludos.Add(nuevoSaludo);
            return nuevoSaludo;
        }

        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }

        public IEnumerable<Saludo> GetSaludosPorFiltro(string filtro)
        {
            throw new NotImplementedException();
        }

        public Saludo GetSaludosPorId(int saludoId)
        {
            return saludos.SingleOrDefault(s => s.Id==saludoId);
        }

        public Saludo Update(Saludo saludoActualizado)
        {
            throw new NotImplementedException();
        }
    }
}