using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Enums;

namespace eUseControl.Web1.Models
{
     public class Programare
     {
          public int Id { get; set; }
          public string Nume { get; set; }
          public string Prenume { get; set; }
          public string Telefon { get; set; }
          public DateTime DataProgramare { get; set; }
          public string Serviciu { get; set; }
          public StareProgramare Stare { get; set; } = StareProgramare.InAsteptare;
     }
}
