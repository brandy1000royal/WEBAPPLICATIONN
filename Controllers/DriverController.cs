using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebZuber.Contracts;
using WebZuber.Data;
using WebZuber.Models;

namespace WebZuber.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverRepository _repo;
        private readonly IMapper _mapper;


        public DriverController(IDriverRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;


        }
        // GET: Drivers
        public ActionResult Index()
        {
            var Drivers = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Driver>, List<DriverVM>>(Drivers);
            return View(model);
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Driver = _repo.FindById(id);
            var model = _mapper.Map<DriverVM>(Driver);
            return View(model);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DriverVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                var Driver = _mapper.Map<Driver>(model);

                var isSucess = _repo.Create(Driver);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Error");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Error");
                return View(model);
            }
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int id)

        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Driver = _repo.FindById(id);
            var model = _mapper.Map<DriverVM>(Driver);
            return View(model);
        }

        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DriverVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Driver = _mapper.Map<Driver>(model);


                var isSucess = _repo.Update(Driver);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Error");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Error");
                return View(model);
               
            }
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int id)
        {
            var Driver = _repo.FindById(id);
            if (Driver == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(Driver);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Drivers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DriverVM model)
        {
            try
            {
                var Driver = _repo.FindById(id);
                if (Driver == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(Driver);
                if (!isSucess)
                {

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}