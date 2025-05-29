using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using eUseControl.Domain.Enums;
using eUseControl.Web1.Models;

namespace eUseControl.Web1.Controllers
{
    public class ProgramareController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["eUseControl"].ConnectionString;

        public ActionResult Index()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"] == true)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Trimite(Programare model)
        {
            if (Session["IsAuthenticated"] == null || (bool)Session["IsAuthenticated"] == false)
            {
                return RedirectToAction("Index", "Login");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Programari (Nume, Prenume, Telefon, DataProgramare, Serviciu, Email) VALUES (@Nume, @Prenume, @Telefon, @DataProgramare, @Serviciu, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nume", model.Nume);
                cmd.Parameters.AddWithValue("@Prenume", model.Prenume);
                cmd.Parameters.AddWithValue("@Telefon", model.Telefon);
                cmd.Parameters.AddWithValue("@DataProgramare", model.DataProgramare);
                cmd.Parameters.AddWithValue("@Serviciu", model.Serviciu);
                cmd.Parameters.AddWithValue("@Email", Session["Email"] ?? "");
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Confirmare");
        }

        public ActionResult Confirmare()
        {
            return View();
        }

        public ActionResult ProgramarileMele()
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Index", "Login");
            }

            var programari = new List<Programare>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Programari WHERE Email = @Email ORDER BY DataProgramare DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", Session["Email"] ?? "");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    programari.Add(new Programare
                    {
                        Id = (int)reader["Id"],
                        Nume = reader["Nume"].ToString(),
                        Prenume = reader["Prenume"].ToString(),
                        Telefon = reader["Telefon"].ToString(),
                        DataProgramare = (DateTime)reader["DataProgramare"],
                        Serviciu = reader["Serviciu"].ToString(),
                        PacientEmail = reader["Email"].ToString(),
                        Stare = Enum.TryParse(reader["Stare"].ToString(), out StareProgramare stare) ? stare : StareProgramare.InAsteptare
                    });
                }
            }

            return View(programari);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchimbaStare(int id, int stareNoua, string specialitate)
        {
            if (Session["IsAuthenticated"] == null || !(bool)Session["IsAuthenticated"])
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Enum.IsDefined(typeof(StareProgramare), stareNoua))
            {
                TempData["ErrorMessage"] = "Starea programării nu este validă.";
                return RedirectToAction("ProgramarileMele");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Programari SET Stare = @StareNoua WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StareNoua", stareNoua);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        
            if (!string.IsNullOrEmpty(specialitate))
            {
                return RedirectToAction("Programari" + specialitate, specialitate);
            }

            return RedirectToAction("ProgramarileMele");
        }
    }
}
