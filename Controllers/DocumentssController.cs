using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
[Authorize (Roles = "Admin, Naghdi, Saderat, Lc")]

public class DocumentssController : Controller
{

    //configur IwebHost
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public DocumentssController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }












    public IActionResult Sherkat()
    {
        return View();
    }

    public IActionResult Mahsol()
    {
        return View();
    }

    public IActionResult MahsolSa()
    {
        return View();
    }


    public IActionResult Hesab()
    {
        return View();
    }

    public IActionResult AddDbSherkat(Sherkat sh)
    {
        Sherkat s = new Sherkat();
        s.NameSherkat = sh.NameSherkat;
        s.ShomareSabt = sh.ShomareSabt;
        s.ShenaseMeli = sh.ShenaseMeli;
        s.Codeposti = sh.Codeposti;
        s.Neshani = sh.Neshani;
        db.sherkats.Add(s);
        db.SaveChanges();

        return RedirectToAction("Sherkat");
    }


    public IActionResult AddDbMahsol(Mahsol mh)
    {
        Mahsol m = new Mahsol();
        m.NameMahsol = mh.NameMahsol;
        db.mahsols.Add(m);
        db.SaveChanges();

        return RedirectToAction("Mahsol");
    }

    public IActionResult AddDbMahsolSA(MahsolSa mh)
    {
        MahsolSa m = new MahsolSa();
        m.NameMahsol = mh.NameMahsol;
        m.HSCode = mh.HSCode;
        m.FirstOfName = m.NameMahsol[0];
        db.mahsolSas.Add(m);
        db.SaveChanges();

        return RedirectToAction("MahsolSa");
    }

    public IActionResult AddDbHesab(Hesab he)
    {
        Hesab h = new Hesab();
        h.NameBank = he.NameBank;
        h.NameShobe = he.NameShobe;
        h.ShomareShaba = he.ShomareShaba;
        db.hesabs.Add(h);
        db.SaveChanges();

        return RedirectToAction("Hesab");
    }


    public IActionResult KharidarDolari()
    {
        return View();


    }

    public IActionResult AddKharidar(KharidarDolar k)
    {
        KharidarDolar kh = new KharidarDolar();
        kh.Name = k.Name;
        kh.PassportNo = k.PassportNo;
        kh.Country = k.Country;
        db.kharidarDolars.Add(kh);
        db.SaveChanges();

        return RedirectToAction("KharidarDolari");
    }






}