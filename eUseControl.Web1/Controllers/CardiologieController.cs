using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using eUseControl.Web1.Models;
using eUseControl.Domain.Enums;

namespace eUseControl.Web1.Controllers
{
    public class CardiologieController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["eUseControl"].ConnectionString;

        public ActionResult ProgramariCardiologie()
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Index", "Login");
            }

            var programari = new List<Programare>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Programari WHERE Serviciu = @Serviciu AND (Stare IS NULL OR Stare != @Anulata) ORDER BY DataProgramare ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Serviciu", "Cardiologie");
                cmd.Parameters.AddWithValue("@Anulata", (int)StareProgramare.Anulata);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var p = new Programare
                    {
                        Id = (int)reader["Id"],
                        Nume = reader["Nume"].ToString(),
                        Prenume = reader["Prenume"].ToString(),
                        Telefon = reader["Telefon"].ToString(),
                        DataProgramare = (DateTime)reader["DataProgramare"],
                        Serviciu = reader["Serviciu"].ToString(),
                        PacientEmail = reader["Email"].ToString(),
                        Stare = Enum.TryParse(reader["Stare"].ToString(), out StareProgramare stare)
                                ? stare
                                : StareProgramare.InAsteptare
                    };
                    programari.Add(p);
                }
            }

            return View(programari);
        }
    }
}
