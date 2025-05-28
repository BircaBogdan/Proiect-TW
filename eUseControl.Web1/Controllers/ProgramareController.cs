using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using eUseControl.Web1.Models;

namespace eUseControl.Web1.Controllers
{
    public class ProgramareController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["eUseControl"].ConnectionString;

        // Afișează formularul de programare
        public ActionResult Index()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"] == true)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        // Trimite programarea în baza de date
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Trimite(Programare model)
        {
            if (Session["IsAuthenticated"] == null || (bool)Session["IsAuthenticated"] == false)
            {
                return RedirectToAction("Index", "Login");
            }

            string pacientEmail = Session["Email"] as string;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Programari (Nume, Prenume, Telefon, DataProgramare, Serviciu, DoctorEmail, PacientEmail) " +
                               "VALUES (@Nume, @Prenume, @Telefon, @DataProgramare, @Serviciu, @DoctorEmail, @PacientEmail)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nume", model.Nume);
                cmd.Parameters.AddWithValue("@Prenume", model.Prenume);
                cmd.Parameters.AddWithValue("@Telefon", model.Telefon);
                cmd.Parameters.AddWithValue("@DataProgramare", model.DataProgramare);
                cmd.Parameters.AddWithValue("@Serviciu", model.Serviciu);
                cmd.Parameters.AddWithValue("@DoctorEmail", model.DoctorEmail ?? "");
                cmd.Parameters.AddWithValue("@PacientEmail", pacientEmail ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Confirmare");
        }

        // Afișează pagina de confirmare după trimitere
        public ActionResult Confirmare()
        {
            return View();
        }

        // Afișează toate programările făcute de utilizatorul logat
        public ActionResult ProgramarileMele()
        {
            if (Session["IsAuthenticated"] == null || (bool)Session["IsAuthenticated"] == false)
            {
                return RedirectToAction("Index", "Login");
            }

            string pacientEmail = Session["Email"] as string;
            var programari = new List<Programare>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Programari WHERE PacientEmail = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", pacientEmail ?? "");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Programare
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nume = reader["Nume"].ToString(),
                            Prenume = reader["Prenume"].ToString(),
                            Telefon = reader["Telefon"].ToString(),
                            DataProgramare = Convert.ToDateTime(reader["DataProgramare"]),
                            Serviciu = reader["Serviciu"].ToString(),
                            DoctorEmail = reader["DoctorEmail"] != DBNull.Value ? reader["DoctorEmail"].ToString() : "",
                            PacientEmail = reader["PacientEmail"] != DBNull.Value ? reader["PacientEmail"].ToString() : ""
                        };
                        programari.Add(p);
                    }
                }
            }

            return View(programari);
        }
    }
}
