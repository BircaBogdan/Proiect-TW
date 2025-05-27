using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                    string query = "INSERT INTO Programari (Nume, Prenume, Telefon, DataProgramare, Serviciu, Stare) VALUES (@Nume, @Prenume, @Telefon, @DataProgramare, @Serviciu, @Stare)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nume", model.Nume);
                    cmd.Parameters.AddWithValue("@Prenume", model.Prenume);
                    cmd.Parameters.AddWithValue("@Telefon", model.Telefon);
                    cmd.Parameters.AddWithValue("@DataProgramare", model.DataProgramare);
                    cmd.Parameters.AddWithValue("@Serviciu", model.Serviciu);
                    cmd.Parameters.AddWithValue("@Stare", (int)StareProgramare.InAsteptare);


                    conn.Open();
                    cmd.ExecuteNonQuery();
               }

               return RedirectToAction("Confirmare");
          }


          public ActionResult Confirmare()
          {
               return View();
          }
          [HttpPost]
          public ActionResult SchimbaStare(int id, int nouaStare, string specialitate)
          {
               using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    string query = "UPDATE Programari SET Stare = @Stare WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Stare", nouaStare);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
               }

               // Redirect pe baza specialitatii primite
               switch (specialitate.ToLower())
               {
                    case "cardiologie":
                         return RedirectToAction("ProgramariCardiologie");
                    case "dermatologie":
                         return RedirectToAction("ProgramariDermatologie");
                    case "orl":
                         return RedirectToAction("ProgramariORL");
                    default:
                         return RedirectToAction("Index");
               }
          }



          public ActionResult ProgramariCardiologie()
          {
               List<Programare> programari = new List<Programare>();

               using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    string query = "SELECT Id, Nume, Prenume, Telefon, DataProgramare, Serviciu, Stare FROM Programari WHERE Serviciu = 'Cardiologie'";
                    SqlCommand cmd = new SqlCommand(query, conn);
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
                              DataProgramare = Convert.ToDateTime(reader["DataProgramare"]),
                              Serviciu = reader["Serviciu"].ToString(),
                              Stare = (StareProgramare)(int)reader["Stare"]
                         });
                    }
               }

               return View("~/Views/Cardiologie/ProgramariCardiologie.cshtml", programari);


          }
          public ActionResult ProgramariDermatologie()
          {
               List<Programare> programari = new List<Programare>();

               using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    string query = "SELECT Id, Nume, Prenume, Telefon, DataProgramare, Serviciu, Stare FROM Programari WHERE Serviciu = 'Dermatologie'";
                    SqlCommand cmd = new SqlCommand(query, conn);
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
                              DataProgramare = Convert.ToDateTime(reader["DataProgramare"]),
                              Serviciu = reader["Serviciu"].ToString(),
                              Stare = (StareProgramare)(int)reader["Stare"]
                         });
                    }
               }

               return View("~/Views/Dermatologie/ProgramariDermatologie.cshtml", programari);
          }
          public ActionResult ProgramariORL()
          {
               List<Programare> programari = new List<Programare>();

               using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    string query = "SELECT Id, Nume, Prenume, Telefon, DataProgramare, Serviciu, Stare FROM Programari WHERE Serviciu = 'ORL'";
                    SqlCommand cmd = new SqlCommand(query, conn);
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
                              DataProgramare = Convert.ToDateTime(reader["DataProgramare"]),
                              Serviciu = reader["Serviciu"].ToString(),
                              Stare = (StareProgramare)(int)reader["Stare"]
                         });
                    }
               }

               return View("~/Views/ORL/ProgramariORL.cshtml", programari);
          }





     }
}
