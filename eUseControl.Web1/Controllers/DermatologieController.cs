using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using eUseControl.Web1.Models; // Assuming you have a Programare model defined here

namespace eUseControl.Web1.Controllers
{
     public class DermatologieController : Controller
     {
          private string connectionString = ConfigurationManager.ConnectionStrings["eUseControl"].ConnectionString;

          public ActionResult ProgramariDermatologie()
          {
               var programari = new List<Programare>();

               using (SqlConnection conn = new SqlConnection(connectionString))
               {
                    string query = "SELECT * FROM Programari WHERE Serviciu = @Serviciu";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Serviciu", "Dermatologie");

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
                              Serviciu = reader["Serviciu"].ToString()
                         };
                         programari.Add(p);
                    }
               }

               return View(programari);
          }
     }
}