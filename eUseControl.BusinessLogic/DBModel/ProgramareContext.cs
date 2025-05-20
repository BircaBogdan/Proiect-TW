using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Programare;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ProgramareContext : DbContext
    {
        public ProgramareContext() : base("name=eUseControl") { }

        public virtual DbSet<UDbProgramare> Programari { get; set; }
    }
}
