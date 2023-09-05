using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DocumentssController : Controller
{
    public IActionResult DocumentRegistration()
    {
        var sherkat = db.sherkats
       .OrderBy(a => a.Id)
       .GroupBy(a => a.Id)
       .Select(g => g.FirstOrDefault())
       .ToList();

        var hesab = db.hesabs
               .OrderBy(a => a.Id)
               .GroupBy(a => a.Id)
               .Select(g => g.FirstOrDefault())
               .ToList();

        var mahsol = db.mahsols
               .OrderBy(a => a.Id)
               .GroupBy(a => a.Id)
               .Select(g => g.FirstOrDefault())
               .ToList();

        var selectsherkatItems = sherkat.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.NameSherkat}"
        });

        var selecthesabItems = hesab.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.NameBank}"
        });

        var selectmahsolItems = mahsol.Select(g => new SelectListItem
        {
            Value = g.NameMahsol.ToString(),
            Text = $"{g.NameMahsol} "
        });


        ViewBag.Sherkat = new SelectList(selectsherkatItems, "Value", "Text");
        ViewBag.Hesab = new SelectList(selecthesabItems, "Value", "Text");

        ViewBag.Mahsol = new SelectList(selectmahsolItems, "Value", "Text");


        return View();
    }
    //configur IwebHost
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public DocumentssController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
    [HttpPost]
    public IActionResult AddDocumentToDb(Documentss d)
    {
        Document doc = new Document();
        doc.TarikhSabt = DateTime.Today;
        doc.Tarikhsodor = d.Tarikhsodor;
        doc.TarikhEtebar = d.TarikhEtebar;
        doc.SherkatId = d.SherkatId;
        List<Sherkat> l = new List<Sherkat>();
        l = db.sherkats.OrderBy(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == Convert.ToInt32(doc.SherkatId))
            {
                doc.NameSherkat = item.NameSherkat;
            }
        }
        doc.Tonazh = d.Tonazh;
        List<Hesab> la = new List<Hesab>();
        la = db.hesabs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in la)
        {
            if (item.Id == Convert.ToInt32(doc.SherkatId))
            {
                doc.Hesab = item.NameBank;
            }
        }

        doc.NoeForosh = d.NoeForosh;
        doc.NameVasete = d.NameVasete;
        doc.NameMahsol = d.NameMahsol;
        // doc.Tedad = d.Tedad;
        doc.FiGhablArzeshAfzode = d.FiGhablArzeshAfzode;
        doc.MabdaHaml = d.MabdaHaml;
        doc.Takhfif = d.Takhfif;
        doc.status = 0;
        int MablaghKol = (d.FiGhablArzeshAfzode * Convert.ToInt32(d.Tonazh)) - d.Takhfif;
        //اضافه کردن ۹ درصد ارزش افزوده
        doc.ArzeshAfzode = (MablaghKol * 9) / 100;
        doc.GheymatNahaei = MablaghKol + doc.ArzeshAfzode;
        doc.HesabId = d.HesabId;
        if (d.Img != null)
        {
            doc.ImageName = UploadImage(d.Img);
        }
        else
        {
            doc.ImageName = null;
        }
        db.Documents.Add(doc);
        db.SaveChanges();


        return RedirectToAction("DocumentRegistration");
    }
    [HttpPost]
    public string UploadImage(IFormFile file)
    {
        string FileExtension1 = Path.GetExtension(file.FileName);
        string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
        var path = $"{env.WebRootPath}/assets/FileUpload/{NewFileName}";
        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return NewFileName;
    }

    public IActionResult MeghdarBargiri()
    {
        ViewBag.Doc = db.Documents
        .OrderBy(a => a.Id)
        .GroupBy(a => a.NameSherkat)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

    public IActionResult UpdateMeghdarBargiri(Document doc)
    {
        List<Document> l = new List<Document>();
        l = db.Documents.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == doc.Id)
            {
                item.MeghdarBargiri = doc.MeghdarBargiri;
                item.status = 1;
                db.Documents.Update(item);
            }
            db.SaveChanges();
        }

        return RedirectToAction("MeghdarBargiri");
    }

    public IActionResult Delete(int ID)
    {
        Document doc = db.Documents.Find(ID);
        db.Documents.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("MeghdarBargiri");
    }



    public IActionResult Acsept()
    {
        ViewBag.Doc = db.Documents
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        return View();
    }
    public IActionResult AcseptDolar()
    {
        ViewBag.Doc = db.dolarDocs
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        return View();
    }

    public IActionResult StatusRejectD(int ID)
    {
        List<DolarDoc> l = new List<DolarDoc>();
        l = db.dolarDocs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 2;
                db.dolarDocs.Update(item);
            }
            db.SaveChanges();
        }
        return RedirectToAction("AcseptDolar");
    }

    public IActionResult StatusAcseptD(int ID)
    {
        List<DolarDoc> l = new List<DolarDoc>();
        l = db.dolarDocs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 3;
                var PishIdd = db.dolarDocs.OrderByDescending(a => a.Id).Select(x => x.PishId).Max();
                if (PishIdd == null)
                {
                    item.PishId = 1;
                }
                else
                {
                    PishIdd++;
                    item.PishId = PishIdd;
                }
                if (item.PishId.ToString().Length == 1)
                {
                    item.ShomarePish = item.NameMahsol[0] + "02-00" + item.PishId;
                }
                if (item.PishId.ToString().Length == 2)
                {
                    item.ShomarePish = item.NameMahsol[0] + "02-0" + item.PishId;
                }
                if (item.PishId.ToString().Length == 3)
                {
                    item.ShomarePish = item.NameMahsol[0] + "02-" + item.PishId;

                }




                db.dolarDocs.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction("AcseptDolar");
    }


    public IActionResult StatusReject(int ID)
    {
        List<Document> l = new List<Document>();
        l = db.Documents.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 2;
                db.Documents.Update(item);
            }
            db.SaveChanges();
        }
        return RedirectToAction("Acsept");
    }

    public IActionResult StatusAcsept(int ID)
    {
        List<Document> l = new List<Document>();
        l = db.Documents.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 3;
                var PishIdd = db.Documents.OrderByDescending(a => a.Id).Select(x => x.PishId).Max();
                if (PishIdd == null)
                {
                    item.PishId = 1;
                }
                else
                {
                    PishIdd++;
                    item.PishId = PishIdd;
                }
                if (item.PishId.ToString().Length == 1)
                {
                    item.ShomarePish = "402-000" + item.PishId;
                }
                if (item.PishId.ToString().Length == 2)
                {
                    item.ShomarePish = "402-00" + item.PishId;
                }
                if (item.PishId.ToString().Length == 3)
                {
                    item.ShomarePish = "402-0" + item.PishId;
                }
                if (item.PishId.ToString().Length == 4)
                {
                    item.ShomarePish = "402-" + item.PishId;
                }



                db.Documents.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction("Acsept");
    }


    public IActionResult print(int id)
    {
        var l = db.Documents.OrderBy(a => a.Id).GroupBy(b => b.Id).Select(c => c.FirstOrDefault());
        foreach (var item in l)
        {
            if (item.Id == id)
            {
                ViewBag.pishfack = item.ShomarePish;
                ViewBag.ts = item.Tarikhsodor;
                ViewBag.te = item.TarikhEtebar;
                var sherkat = db.sherkats.OrderBy(a => a.Id).GroupBy(a => a.Id).Select(a => a.FirstOrDefault()).ToList();
                foreach (var item1 in sherkat)
                {
                    if (item1.Id == Convert.ToInt32(item.SherkatId))
                    {
                        ViewBag.ns = item1.NameSherkat;
                        ViewBag.ss = item1.ShomareSabt;
                        ViewBag.sm = item1.ShenaseMeli;
                        ViewBag.cp = item1.Codeposti;
                        ViewBag.nsh = item1.Neshani;
                    }
                }
                ViewBag.sk = item.NameMahsol;
                ViewBag.tn = item.Tonazh;
            }
        }
        return View();
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

    public IActionResult Dolari()
    {
        var kharidar = db.kharidarDolars
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();

        var mahsol = db.mahsolSas
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();

        var selectkharidarItems = kharidar.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.Name} , {g.Country}"
        });

        var selectmahsolItems = mahsol.Select(g => new SelectListItem
        {
            Value = g.NameMahsol.ToString(),
            Text = $"{g.NameMahsol} "
        });

        ViewBag.kharidar = new SelectList(selectkharidarItems, "Value", "Text");
        ViewBag.Mahsol = new SelectList(selectmahsolItems, "Value", "Text");


        return View();
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

    public IActionResult PrintDolar()
    {
        return View();
    }


    public IActionResult AddDolarToDb(VM_dolari d)
    {
        DolarDoc doc = new DolarDoc();
        doc.Hesab = d.Hesab;
        doc.TarikhSabt = DateTime.Today;
        doc.Tarikhsodor = d.Tarikhsodor;
        doc.TarikhEtebar = d.TarikhEtebar;
        doc.SherkatId = d.SherkatId;
        List<KharidarDolar> l = new List<KharidarDolar>();
        l = db.kharidarDolars.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == Convert.ToInt32(doc.SherkatId))
            {
                doc.NameKharidar = item.Name;
            }
        }
        doc.Tonazh = d.Tonazh;


        doc.SharayetTahvil = d.SharayetTahvil;
        doc.NameVasete = d.NameVasete;
        doc.NameMahsol = d.NameMahsol;
        doc.Fi = d.Fi;
        doc.MaghsadHaml = d.MaghsadHaml;
        doc.Komision = d.Komision;
        doc.status = 0;
        int MablaghKol = d.Fi * d.Tonazh;
        //اضافه کردن ۹ درصد ارزش افزوده
        doc.GheymatNahaei = MablaghKol;
        if (d.Img != null)
        {
            doc.ImageName = UploadImage(d.Img);
        }
        else
        {
            doc.ImageName = null;
        }
        doc.FiMablaghGhabelEzhar = d.Fi - d.Komision;
        doc.MablaghGhabelEzhar = doc.FiMablaghGhabelEzhar * d.Tonazh;
        db.dolarDocs.Add(doc);
        db.SaveChanges();


        return RedirectToAction("Dolari");
    }

    public IActionResult Lc()
    {

        var sherkat = db.sherkats
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        var mahsol = db.mahsols
               .OrderBy(a => a.Id)
               .GroupBy(a => a.Id)
               .Select(g => g.FirstOrDefault())
               .ToList();
        var selectsherkatItems = sherkat.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.NameSherkat}"
        });
        var selectmahsolItems = mahsol.Select(g => new SelectListItem
        {
            Value = g.NameMahsol.ToString(),
            Text = $"{g.NameMahsol} "
        });
        ViewBag.Sherkat = new SelectList(selectsherkatItems, "Value", "Text");

        ViewBag.Mahsol = new SelectList(selectmahsolItems, "Value", "Text");


        return View();
    }


    [HttpPost]
    public IActionResult AddLCKhToDb(VM_LCKh d)
    {
        LCKh doc = new LCKh();
        doc.TarikhSabt = DateTime.Today;
        doc.Tarikhsodor = d.Tarikhsodor;
        doc.TarikhEtebar = d.TarikhEtebar;
        doc.SherkatId = d.SherkatId;
        List<Sherkat> l = new List<Sherkat>();
        l = db.sherkats.OrderBy(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == Convert.ToInt32(doc.SherkatId))
            {
                doc.NameSherkat = item.NameSherkat;
            }
        }
        doc.Tonazh = d.Tonazh;


        doc.NameVasete = d.NameVasete;
        doc.NameMahsol = d.NameMahsol;
        // doc.Tedad = d.Tedad;
        doc.FiGhablArzeshAfzode = d.FiGhablArzeshAfzode;
        doc.MabdaHaml = d.MabdaHaml;
        doc.Takhfif = d.Takhfif;
        doc.status = 0;

        int MablaghKol = (d.FiGhablArzeshAfzode * d.Tonazh) - d.Takhfif;
        //اضافه کردن ۹ درصد ارزش افزوده
        doc.ArzeshAfzode = (MablaghKol * 9) / 100;
        doc.GheymatNahaei = MablaghKol + doc.ArzeshAfzode;
        if (d.Img != null)
        {
            doc.ImageName = UploadImage(d.Img);
        }
        else
        {
            doc.ImageName = null;
        }
        doc.MabdaHaml = d.MabdaHaml;
        doc.MaghsadHaml = d.MaghsadHaml;
        doc.BankGoshayesh = d.BankGoshayesh;
        doc.BankKargozari = d.BankKargozari;
        doc.LCDay = d.LCDay;
        doc.Size = d.Size;
        doc.MeghdarBargiri = d.MeghdarBargiri;
        doc.Tozih = d.Tozih;
        doc.Sepam = d.Sepam;
        doc.TarikhGoshayesh = d.TarikhGoshayesh;
        doc.ShomarePish = d.ShomarePish;
        db.lCKhs.Add(doc);
        db.SaveChanges();


        return RedirectToAction("Lc");
    }

    public IActionResult RequestLcF ()
    {
                var sherkat = db.sherkats
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        var selectsherkatItems = sherkat.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.NameSherkat}"
        });
        ViewBag.Sherkat = new SelectList(selectsherkatItems, "Value", "Text");

        return View();
    }

    public IActionResult AddDbRequestLcF(Vm_RequestLcF vm)
    {
        LcRequest r = new LcRequest();
        r.ImageName=UploadImage(vm.img);
        r.MablaghR=vm.MablaghR;
        r.SherkatId=vm.SherkatId;
        List<Sherkat> l = new List<Sherkat>();
        l = db.sherkats.OrderBy(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == Convert.ToInt32(r.SherkatId))
            {
                r.NameSherkat = item.NameSherkat;
            }
        }
        r.TarikhR=vm.TarikhR;
        r.Tonazh=vm.Tonazh;
        r.Tozih=vm.Tozih;
        r.Vaste=vm.Vaste;
        db.lcRequests.Add(r);
        db.SaveChanges();
        return RedirectToAction("RequestLcF");
    }


}