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
        .GroupBy(a => a.NameSherkat)
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

    public IActionResult ShowSherkat()
    {
        ViewBag.Doc = db.sherkats
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameSherkat)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

        public IActionResult DeleteSh(int ID)
    {
        Sherkat doc = db.sherkats.Find(ID);
        db.sherkats.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowSherkat");
    }
        public IActionResult ShowMahsol()
    {
        ViewBag.Doc = db.mahsols
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameMahsol)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

            public IActionResult DeleteMh(int ID)
    {
        Mahsol doc = db.mahsols.Find(ID);
        db.mahsols.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowMahsol");
    }

            public IActionResult ShowMahsolSa()
    {
        ViewBag.Doc = db.mahsolSas
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameMahsol)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

            public IActionResult DeleteMhSa(int ID)
    {
        MahsolSa doc = db.mahsolSas.Find(ID);
        db.mahsolSas.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowMahsolSa");
    }

        public IActionResult ShowBank()
    {
        ViewBag.Doc = db.hesabs
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameBank)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

    public IActionResult DeleteBa(int ID)
    {
        Hesab doc = db.hesabs.Find(ID);
        db.hesabs.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowMahsol");
    }

        public IActionResult ShowBuyer()
    {
        ViewBag.Doc = db.kharidarDolars
        .OrderBy(a => a.Id)
        .GroupBy(a => a.Name)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

        public IActionResult DeleteBu(int ID)
    {
        Hesab doc = db.hesabs.Find(ID);
        db.hesabs.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowMahsol");
    }

    public IActionResult ShowDolar()
    {
                ViewBag.Doc = db.dolarDocs
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameKharidar)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }


    
}
