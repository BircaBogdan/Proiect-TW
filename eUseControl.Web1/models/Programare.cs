using System;

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

        // Nou: Email pacient, pentru filtrare și afișare
        public string PacientEmail { get; set; }

        // Nou: stare programare (pentru afișare și logică)
        public eUseControl.Domain.Enums.StareProgramare Stare { get; set; } = eUseControl.Domain.Enums.StareProgramare.InAsteptare;
    }
}
