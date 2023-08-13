using Microsoft.AspNetCore.Mvc;


public class DocumentssController : Controller
{
        public IActionResult DocumentRegistration()
    {
        
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
        doc.TarikhSabt = d.TarikhSabt;
        doc.TarikhEtebar = d.TarikhEtebar;
        doc.NoeForosh = d.NoeForosh;
        doc.NameSherkat = d.NameSherkat;
        doc.NameVasete = d.NameVasete;
        doc.NameMahsol = d.NameMahsol;
        doc.Tedad = d.Tedad;
        doc.FiGhablArzeshAfzode = d.FiGhablArzeshAfzode;
        doc.MabdaHaml = d.MabdaHaml;
        doc.Takhfif = d.Takhfif;
        doc.MablaghDaryafti = d.MablaghDaryafti;
        doc.MojavezBargiri = d.MojavezBargiri;
        doc.MeghdarBargiri = d.MeghdarBargiri;
        doc.St=0;
        int MablaghKol= (d.FiGhablArzeshAfzode * d.Tedad) - d.Takhfif;
        //اضافه کردن ۹ درصد ارزش افزوده
        doc.ArzeshAfzode = (MablaghKol * 9) / 100;
        doc.GheymatNahaei = MablaghKol + doc.ArzeshAfzode;
        if (d.Img!=null)
        {
            doc.ImageName=UploadImage(d.Img);
        }
        else
        {
            doc.ImageName=null;
        }
        db.Documents.Add(doc);
        db.SaveChanges();

        
        return RedirectToAction ("DocumentRegistration");
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
                .GroupBy(a=>a.NameSherkat)
                .Select(g => g.FirstOrDefault())
                .ToList();
        return View();
    }

    public IActionResult UpdateMeghdarBargiri(Document doc)
    {
        List<Document> l = new List<Document>();
        l=db.Documents.OrderByDescending(a=>a.Id).GroupBy(x=>x.MeghdarBargiri).Select(e=>e.FirstOrDefault()).ToList();
            foreach (var item in l)
            {
                if (item.Id==doc.Id)
                {
                    item.MeghdarBargiri=doc.MeghdarBargiri;
                    item.St=1;
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
                .GroupBy(a=>a.NameSherkat)
                .Select(g => g.FirstOrDefault())
                .ToList();
        return View();
    }
        public IActionResult StatusReject(int ID)
        {
            List<Document> l = new List<Document>();
        l=db.Documents.OrderByDescending(a=>a.Id).GroupBy(x=>x.MeghdarBargiri).Select(e=>e.FirstOrDefault()).ToList();
            foreach (var item in l)
            {
                if (item.Id==ID)
                {
                    
                    item.St=2;
                    db.Documents.Update(item);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Acsept");
        }

        public IActionResult StatusAcsept(int ID)
        {
            List<Document> l = new List<Document>();
        l=db.Documents.OrderByDescending(a=>a.Id).GroupBy(x=>x.MeghdarBargiri).Select(e=>e.FirstOrDefault()).ToList();
            foreach (var item in l)
            {
                if (item.Id==ID)
                {
                    
                    item.St=3;
                    db.Documents.Update(item);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Acsept");
        }

        public IActionResult print()
        {
            return View();
        }



}