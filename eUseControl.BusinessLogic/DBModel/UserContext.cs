using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
     class UserContext : DbContext
     {
          public UserContext() :
              base("name=eUseControl") // connectionstring name define in your web.config
          {
          }
          public virtual DbSet<UDbTable> Users { get; set; }
     }
}