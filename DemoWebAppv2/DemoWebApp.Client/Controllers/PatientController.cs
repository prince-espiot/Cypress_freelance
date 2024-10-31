using DemoWebApp.Api;
using DemoWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Client.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientManager _patientManager;

        public PatientController(PseudoDbContext pseudoDbContext)
        {
            _patientManager = new PatientManager(pseudoDbContext);
        }

        // GET: PatientController
        public ActionResult Index()
        {
            return View(_patientManager.GetAll());
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient model)
        {
            try
            {
                _patientManager.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_patientManager.Get(id));
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient model)
        {
            try
            {
                _patientManager.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
