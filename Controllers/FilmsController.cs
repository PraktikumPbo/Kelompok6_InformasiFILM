using ASPFILM.Data;
using ASPFILM.Models;
using ASPFILM.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPFILM.Controllers
{
    public class FilmsController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public FilmsController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mvs = await mvcDemoDbContext.Films.ToListAsync();
            return View(mvs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFilmViewModel addFilmRequest)
        {
            var pilm = new Film()
            {
                Id = Guid.NewGuid(),
                Judul = addFilmRequest.Judul,
                Genre = addFilmRequest.Genre,
                Rating = addFilmRequest.Rating,
                Durasi = addFilmRequest.Durasi,
                Rilis = addFilmRequest.Rilis,
                Sinopsis = addFilmRequest.Sinopsis
            };

            await mvcDemoDbContext.Films.AddAsync(pilm);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var pilem = await mvcDemoDbContext.Films.FirstOrDefaultAsync(x => x.Id == Id);

            if (pilem != null)
            {
                var viewModel = new UpdateFilmViewModel()
                {
                    Id = pilem.Id,
                    Judul = pilem.Judul,
                    Genre = pilem.Genre,
                    Rating = pilem.Rating,
                    Durasi = pilem.Durasi,
                    Rilis = pilem.Rilis,
                    Sinopsis = pilem.Sinopsis
                };

                return await Task.Run(() => View("View", viewModel));
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateFilmViewModel model)
        {
            var pilem = await mvcDemoDbContext.Films.FindAsync(model.Id);

            if (pilem != null)
            {
                pilem.Judul = model.Judul;    
                pilem.Genre = model.Genre;    
                pilem.Rating = model.Rating;    
                pilem.Durasi = model.Durasi;    
                pilem.Rilis = model.Rilis;    
                pilem.Sinopsis = model.Sinopsis;    

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateFilmViewModel model)
        {
            var pilem = await mvcDemoDbContext.Films.FindAsync(model.Id);

            if (pilem != null)
            {
                mvcDemoDbContext.Films.Remove(pilem);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
