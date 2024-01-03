using Crud_prayaga.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Crud_prayaga.Controllers
{
    public class FacultadController : Controller
    {

        private readonly DbModels context;

        public FacultadController(DbModels dbContext)
        {
            context = dbContext;
        }

        public ActionResult Index()
        {

                return View(context.facultad.ToList());

        }

        // GET: Facultad/Details/5
        public ActionResult Details(int id)
        {

            

                return View(context.facultad.Where(x=>x.id==id));
            
        }
        public ActionResult Create()
        {

            return View();
        }

        // POST: Facultad/Create
        [HttpPost]
        public ActionResult Create(facultad facultad)
        {
            try
            {
                
                    context.facultad.Add(facultad);
                    context.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facultad/Edit/5
        public ActionResult Edit(int id)
        {

            return View(context.facultad.Where(x => x.id == id).FirstOrDefault());
        }

        // POST: Facultad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, facultad facultad)
        {
            try { 
             
                    context.Entry(facultad).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        // GET: Facultad/Delete/5
        public ActionResult Delete(int id)
        {
         
                return View(context.facultad.Where(x => x.id == id).FirstOrDefault());
         
        }

        // POST: Facultad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int? nuevaFacultadId)
        {
            try
            {
               
                    var facultadRemoved = context.facultad.SingleOrDefault(x => x.id == id && !x.eliminado);

                    if (facultadRemoved == null)
                    {
                        TempData["ErrorMessage"] = "La carrera no existe o ya ha sido eliminada.";

                        return RedirectToAction("Index");
                    }

                if (nuevaFacultadId.HasValue)
                    {
                        var nuevaFacultad = context.facultad.Find(nuevaFacultadId.Value);
                        if (nuevaFacultad == null || nuevaFacultad.eliminado)
                        {
                            TempData["ErrorMessage"] = "La nueva facultad no existe o ya ha sido eliminada."
                            return RedirectToAction("Index");
                        }

                        foreach (var carrera in facultadRemoved.carrera)
                        {
                            carrera.facultad = nuevaFacultadId.Value;
                        }
                    }

                    facultadRemoved.eliminado = true;
                    context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }


        public ActionResult GetDeleted()
        {
           

                var deletedFacultades = context.facultad.Where(x => x.eliminado).ToList();
                return View(deletedFacultades);
            
        }
    }
}
