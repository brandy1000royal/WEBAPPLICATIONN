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
    public class RideController : Controller
    {
        private readonly IRideRepository _repo;
        private readonly IMapper _mapper;


        public RideController(IRideRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;


        }
        // GET: Ride
        public ActionResult Index()
        {
            var Ride = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Ride>, List<RideVM>>(Ride);
            return View(model);
        }

        // GET: Ride/Details/
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Ride = _repo.FindById(id);
            var model = _mapper.Map<RideVM>(Ride);
            return View(model);
        }

        // GET: Ride/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ride/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RideVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                var Ride = _mapper.Map<Ride>(model);

                var isSucess = _repo.Create(Ride);
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

        // GET: Ride/Edit/5
        public ActionResult Edit(int id)

        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Ride = _repo.FindById(id);
            var model = _mapper.Map<RideVM>(Ride);
            return View(model);
        }

        // POST: Ride/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RideVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Ride = _mapper.Map<Ride>(model);


                var isSucess = _repo.Update(Ride);
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

        // GET: Ride/Delete/5
        public ActionResult Delete(int id)
        {
            var Ride = _repo.FindById(id);
            if (Ride == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(Ride);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Ride/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RideVM model)
        {
            try
            {
                var Ride = _repo.FindById(id);
                if (Ride == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(Ride);
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