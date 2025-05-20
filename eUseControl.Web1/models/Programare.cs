using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        

    }
}