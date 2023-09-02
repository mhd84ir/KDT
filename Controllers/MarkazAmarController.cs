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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
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
        .GroupBy(a => a.Id)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

    public IActionResult EditKhDolarr(int id)
    {

        var edit=db.kharidarDolars.Find(id);

        return View(edit);
    }

    public IActionResult UpdateKhDolar(KharidarDolar kh)
    {
        KharidarDolar k = new KharidarDolar();
        k.Id=kh.Id;
        k.Country=kh.Country;
        k.Name=kh.Name;
        k.PassportNo=kh.PassportNo;
        db.kharidarDolars.Update(k);
        db.SaveChanges();
        return RedirectToAction("ShowBuyer");
    }


        public IActionResult EditBank(int id)
    {

        var edit=db.hesabs.Find(id);

        return View(edit);
    }

    public IActionResult UpdateBank(Hesab kh)
    {
        Hesab k = new Hesab();
        k.Id=kh.Id;
        k.NameBank=kh.NameBank;
        k.NameShobe=kh.NameShobe;
        k.ShomareShaba=kh.ShomareShaba;
        db.hesabs.Update(k);
        db.SaveChanges();
        return RedirectToAction("ShowBank");
    }


            public IActionResult EditSherkat(int id)
    {

        var edit=db.sherkats.Find(id);

        return View(edit);
    }

    public IActionResult UpdateSherkat(Sherkat kh)
    {
        Sherkat k = new Sherkat();
        k.Id=kh.Id;
        k.Codeposti=kh.Codeposti;
        k.NameSherkat=kh.NameSherkat;
        k.Neshani=kh.Neshani;
        k.ShenaseMeli=kh.ShenaseMeli;
        k.ShomareSabt=kh.ShomareSabt;

        db.sherkats.Update(k);
        db.SaveChanges();
        return RedirectToAction("ShowSherkat");
    }

    public IActionResult EditMa(int id)
    {

        var edit=db.mahsols.Find(id);

        return View(edit);
    }

    public IActionResult UpdateMa(Mahsol kh)
    {
        Mahsol k = new Mahsol();
        k.Id=kh.Id;
        k.NameMahsol=kh.NameMahsol;
        db.mahsols.Update(k);
        db.SaveChanges();
        return RedirectToAction("ShowMahsol");
    }
    

        public IActionResult EditMas(int id)
    {

        var edit=db.mahsolSas.Find(id);

        return View(edit);
    }

    public IActionResult UpdateMas(MahsolSa kh)
    {
        MahsolSa k = new MahsolSa();
        k.Id=kh.Id;
        k.NameMahsol=kh.NameMahsol;
        k.HSCode=kh.HSCode;
        k.FirstOfName=k.NameMahsol[0];
        db.mahsolSas.Update(k);
        db.SaveChanges();
        return RedirectToAction("ShowMahsolSa");
    }
}
