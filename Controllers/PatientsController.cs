using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCLINIC.Data;
using ASPNETCLINIC.Models;

namespace ASPNETCLINIC.Controllers
{
    public class PatientsController : Controller
    {
      
        private readonly IDAL _dal;

        public PatientsController(IDAL idal)
        {

            _dal = idal;
        }

        // GET: Patients
        public IActionResult Index()
        {
            return View(_dal.GetPatients());
        }

        // GET: Patients/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _dal.GetPatient((int)id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PatientSurname,PESEL")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreatePatient(patient);
                    TempData["Alert"] = "BRAWO! Dodano nowego pacjenta!: " + patient.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "Wystapil błąd!" + ex.Message;
                         return View(patient);
                }
           
            }
            return View(patient);
        }

        }
    }

