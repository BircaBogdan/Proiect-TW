using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Doctor;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IDoctor
    {
        DoctorDetail GetDetailDoctor(int id);
    }
}
