using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Contact;


namespace eUseControl.BusinessLogic.DBModel
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("name=eUseControl") { }

        public virtual DbSet<UDbContact> ContactMessages { get; set; }
    }
}
