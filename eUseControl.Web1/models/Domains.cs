using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web1.Models
{
     public class Domains
     {
          public string Title { get; set; }
          public string Description { get; set; }
          public List<string> Services { get; set; }
          public List<string> Images { get; set; }
     }
}