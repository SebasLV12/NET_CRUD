using Crud_prayaga.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_prayaga.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly DbModels context;

        public CarrerasController(DbModels dbContext)
        {
            context = dbContext;
        }

        public ActionResult Index()
        {
        
                return View(context.carrera.ToList());

        }

        // GET: carrera/Details/5
        public ActionResult Details(int id)
        {

                return View(context.carrera.Where(x => x.id == id));
  
        }

        // POST: carrera/Create
        [HttpPost]
        public ActionResult Create(carrera carrera)
        {
            try
            {
                
                context.carrera.Add(carrera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        // GET: carrera/Edit/5
        public ActionResult Edit(int id)
        {
            
                return View(context.carrera.Where(x => x.id == id).FirstOrDefault());
       
        }

        // POST: carrera/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, carrera carrera)
        {
            try
            {
                context.Entry(carrera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        // GET: carrera/Delete/5
        public ActionResult Delete(int id)
        {
            
                return View(context.carrera.Where(x => x.id == id).FirstOrDefault());
            
        }

        // POST: carrera/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, carrera carrera)
        {
            try
            {

                carrera carreraToRemove = context.carrera.SingleOrDefault(x => x.id == id && !x.eliminado);
                if (carreraToRemove == null)
                {
                    TempData["ErrorMessage"] = "La carrera que intentas eliminar no existe o ya ha sido eliminada.";
                    return RedirectToAction("Index");
                }
                carreraToRemove.eliminado = true;
                context.SaveChanges();
                TempData["SuccessMessage"] = "La carrera se eliminó correctamente.";
                return RedirectToAction("Index");   
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public ActionResult GetDeleted()
        {
            
                var deletedCarreras = context.carrera.Where(x => x.eliminado).ToList();
                return View(deletedCarreras);
            
        }
    }
}
