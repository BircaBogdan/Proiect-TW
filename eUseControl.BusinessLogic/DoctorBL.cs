using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;

namespace eUseControl.BusinessLogic
{
    class DoctorBL : UserApi, IDoctor
    {
        public DoctorDetail GetDetailDoctor(int id)
        {
            return GetDoctorUser(id);
        }
    }
}