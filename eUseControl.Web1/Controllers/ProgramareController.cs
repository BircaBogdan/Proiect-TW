using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                string query = "INSERT INTO Programari (Nume, Prenume, Telefon, DataProgramare, Serviciu) VALUES (@Nume, @Prenume, @Telefon, @DataProgramare, @Serviciu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nume", model.Nume);
                cmd.Parameters.AddWithValue("@Prenume", model.Prenume);
                cmd.Parameters.AddWithValue("@Telefon", model.Telefon);
                cmd.Parameters.AddWithValue("@DataProgramare", model.DataProgramare);
                cmd.Parameters.AddWithValue("@Serviciu", model.Serviciu);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Confirmare");
        }

        public ActionResult Confirmare()
        {
            return View(); 
        }
    }
}
