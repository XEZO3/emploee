using emploee.Data;
using emploee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace emploee.Controllers
{
    public class EmploeeController : Controller
    {
        private readonly emploeeContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public EmploeeController(emploeeContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
        }
        // GET: EmploeeController
        public ActionResult Index()
        {
            List<Emploee> emploee = _context.Emploees.ToList();
            return View(emploee);
        }

        // GET: EmploeeController/Details/5
        public ActionResult Details(int id)
        {
            var emploee = _context.Emploees.FirstOrDefault(x => x.Id == id);
            return View(emploee);
        }

        // GET: EmploeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmploeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Emploee collection)
        {
            var file = HttpContext.Request.Form.Files;
            collection.CreationDate = DateTime.Now;
            collection.ImageUrl = uploadfile(file);
            _context.Add(collection);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: EmploeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emploee = _context.Emploees.FirstOrDefault(x => x.Id == id);
            return View(emploee);
            
        }

        // POST: EmploeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Emploee collection)
        {
            collection.UpdateDate = DateTime.Now;
            var file = HttpContext.Request.Form.Files;

            if (file.Count !=0) { 
            
            collection.ImageUrl = uploadfile(file);
            }
            
            _context.Emploees.Update(collection);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: EmploeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmploeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public string uploadfile(dynamic file) {
            string rootpath = _hostEnviroment.WebRootPath;
            
            string filename = Guid.NewGuid().ToString();
            var upload = Path.Combine(rootpath, @"images\emploee");
            var extention = Path.GetExtension(file[0].FileName);
            using (var filestrem = new FileStream(Path.Combine(upload, filename + extention), FileMode.Create))
            {
                file[0].CopyTo(filestrem);
            }
            return filename + extention;

        }
    }
}
