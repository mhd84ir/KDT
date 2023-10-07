using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectPdf;
[Authorize (Roles = "Naghdi")]

public class NaghdiController: Controller
{
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public NaghdiController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
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
        int MablaghKol = (d.FiGhablArzeshAfzode * d.Tonazh) - d.Takhfif;
        //اضافه کردن ۹ درصد ارزش افزوده
        doc.ArzeshAfzode = ((d.FiGhablArzeshAfzode /100) * 9) * d.Tonazh ;
        doc.GheymatNahaei = MablaghKol ;
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
        .GroupBy(a => a.Id)
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


    public IActionResult EditNaghdi(int id)
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


        var e = db.Documents.Find(id);
        Documentss vd = new Documentss();
        vd.FiGhablArzeshAfzode = e.FiGhablArzeshAfzode;
        vd.NoeForosh = e.NoeForosh;
        vd.GheymatNahaei = e.GheymatNahaei;
        vd.Hesab = e.Hesab;
        vd.Id = e.Id;
        vd.ImageName = e.ImageName;
        vd.NameSherkat = e.NameSherkat;
        vd.MabdaHaml = e.MabdaHaml;
        vd.MeghdarBargiri = e.MeghdarBargiri;
        vd.Takhfif = e.Takhfif;
        vd.NameMahsol = e.NameMahsol;
        vd.NameVasete = e.NameVasete;
        vd.ArzeshAfzode = e.ArzeshAfzode;
        vd.SherkatId = e.SherkatId;
        vd.ShomarePish = e.ShomarePish;
        vd.status = e.status;
        vd.TarikhEtebar = e.TarikhEtebar;
        vd.TarikhSabt = e.TarikhSabt;
        vd.Tarikhsodor = e.Tarikhsodor;
        vd.Tonazh = e.Tonazh;
        vd.HesabId=e.HesabId;
        vd.ShomarePish=e.ShomarePish;
        ViewBag.ImageName=vd.ImageName;
        return View(vd);
    }


    public IActionResult print(int id)
    {
        var l = db.lcfs.OrderBy(a => a.Id).GroupBy(b => b.Id).Select(c => c.FirstOrDefault());
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

        public IActionResult RecheckNaghdi(int ID)
    
    {
        
        List<Document> l = new List<Document>();
        l = db.Documents.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 0;
                db.Documents.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction( "ShowDocument" ,"MarkazAmar");
    }

    //create pdf



}