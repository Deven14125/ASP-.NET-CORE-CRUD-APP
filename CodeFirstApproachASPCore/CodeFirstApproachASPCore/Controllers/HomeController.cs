using System.Diagnostics;
using CodeFirstApproachASPCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachASPCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }


        //Create Method Get
        public async Task<IActionResult> Index()
        {
            var stdData = await studentDB.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem { Value="Male",Text="Male"},
                new SelectListItem { Value="Female",Text="Female"}
            };
            ViewBag.Gender = Gender;

            List<SelectListItem> Standard = new()
            {
                new SelectListItem { Value="1",Text="1"},
                new SelectListItem { Value="2",Text="2"},
                new SelectListItem { Value="3",Text="3"},
                new SelectListItem { Value="4",Text="4"},
                new SelectListItem { Value="5",Text="5"},
                new SelectListItem { Value="6",Text="6"},
                new SelectListItem { Value="7",Text="7"},
                new SelectListItem { Value="8",Text="8"},
                new SelectListItem { Value="9",Text="9"},
                new SelectListItem { Value="10",Text="10"},
                new SelectListItem { Value="11",Text="11"},
                new SelectListItem { Value="12",Text="12"},
                new SelectListItem { Value="B.Tech",Text="B.Tech"},
                new SelectListItem { Value="M.Tech",Text="M.Tech"}
            };
            ViewBag.Standard = Standard;

            return View();
        }


        //Create Method Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student stdData)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(stdData);
                await studentDB.SaveChangesAsync();
                TempData["insert_success"] = "Data Added SuccessFully"; 
                return RedirectToAction("Index","Home");
            }
            return View(stdData);
        }


        //Details Method Get
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x=>x.Id==id);

            if (stdData == null) 
            {
                return NotFound();
            }
            return View(stdData);
        }


        //Edit Method Get
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem { Value="Male",Text="Male"},
                new SelectListItem { Value="Female",Text="Female"}
            };
            ViewBag.Gender = Gender;

            List<SelectListItem> Standard = new()
            {
                new SelectListItem { Value="1",Text="1"},
                new SelectListItem { Value="2",Text="2"},
                new SelectListItem { Value="3",Text="3"},
                new SelectListItem { Value="4",Text="4"},
                new SelectListItem { Value="5",Text="5"},
                new SelectListItem { Value="6",Text="6"},
                new SelectListItem { Value="7",Text="7"},
                new SelectListItem { Value="8",Text="8"},
                new SelectListItem { Value="9",Text="9"},
                new SelectListItem { Value="10",Text="10"},
                new SelectListItem { Value="11",Text="11"},
                new SelectListItem { Value="12",Text="12"},
                new SelectListItem { Value="B.Tech",Text="B.Tech"},
                new SelectListItem { Value="M.Tech",Text="M.Tech"}
            };
            ViewBag.Standard = Standard;

            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }


        //Edit Method Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Student stdData)
        {
            if(id!=stdData.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Students.Update(stdData);
                await studentDB.SaveChangesAsync();
                TempData["edit_success"] = "Data Upadated SuccessFully";
                return RedirectToAction("Index", "Home");
            }
            return View(stdData);
        }


        //Delete Method Get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        //Delete Method Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken ]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);
            if (stdData != null)
            {
                studentDB.Students.Remove(stdData);
            }
            await studentDB.SaveChangesAsync();
            TempData["delete_success"] = "Data Deleted SuccessFully";
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
