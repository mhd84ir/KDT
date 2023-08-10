using Microsoft.AspNetCore.Mvc;
public class MarkazAmarController : Controller
{
    private readonly Context db;
    public MarkazAmarController(Context _db)
    {
        db = _db;
    }
    public IActionResult ShowDocument()
    {
                ViewBag.Doc = db.Documents
                .OrderBy(a => a.Id)
                .GroupBy(a=>a.NameSherkat)
                .Select(g => g.FirstOrDefault())
                .ToList();
        return View();
    }

        public IActionResult Delete(int ID)
    {
        Document doc = db.Documents.Find(ID);
        db.Documents.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowDocument");
    }
}