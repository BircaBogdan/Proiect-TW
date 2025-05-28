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

        // Email-ul doctorului la care se face programarea
        public string DoctorEmail { get; set; }

        // Email-ul pacientului care face programarea
        public string PacientEmail { get; set; }
    }
}
