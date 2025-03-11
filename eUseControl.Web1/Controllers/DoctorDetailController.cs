using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web1.Controllers
{
    public class DoctorDetailController : Controller
    {
        private IDoctor _doctor;
        // GET: DoctorDetail
        DoctorDetailController()
        {
            BusinessLogic business1 = new BusinessLogic();

            _doctor = business1.GetDoctorBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDoctor(int id)
        {

            DoctorDetail = _doctor.GetDetailDoctor(id);
            return View();
        
    }
    }
}