using Microsoft.AspNetCore.Mvc;
using MindGround.Models;

namespace MindGround.Controllers
{
    public class MoodBoardController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public MoodBoardController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MoodBoard> objMoodBoardList = _dbContext.MoodBoard;
            return View(objMoodBoardList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MoodBoard obj)
        {
            if (obj.Name == "Test")
            {
                ModelState.AddModelError("CustomError", "This is not a valid name");
            }
            if(ModelState.IsValid)
            {
                _dbContext.MoodBoard.Add(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Created MoodBoard successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var moodBoardFromDb = _dbContext.MoodBoard.Find(id);

            if (moodBoardFromDb == null)
            {
                return NotFound();
            }
            return View(moodBoardFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MoodBoard obj)
        {
            if (obj.Name == "Test")
            {
                ModelState.AddModelError("CustomError", "This is not a valid name");
            }
            if (ModelState.IsValid)
            {
                _dbContext.MoodBoard.Update(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Edited MoodBoard successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var moodBoardFromDb = _dbContext.MoodBoard.Find(id);

            if (moodBoardFromDb == null)
            {
                return NotFound();
            }
            return View(moodBoardFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id, bool NotUsed)
        {
            var obj = _dbContext.MoodBoard.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dbContext.MoodBoard.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Deleted MoodBoard successfully!";
            return RedirectToAction("Index");
        }


    }
}
