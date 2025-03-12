using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.Domain.Entities.Doctor;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic.Interfaces
{
    public class DoctorBL : UserApi, IDoctor
    {
        public DoctorDetail GetDetailDoctor(int id)
        {
            return GetDoctorUser(id);
        }
        private DoctorDetail GetDoctorUser(int id)
        {
            return new DoctorDetail();

        }
        public IDoctor GetDoctorBL()
        {
            return new DoctorBL();
        }
    }
}