
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LcController : Controller
{
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public LcController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }

        public IActionResult RecheckLcKh(int ID)
    
    {
        
        List<LCKh> l = new List<LCKh>();
        l = db.lCKhs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 0;
                db.lCKhs.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction( "ShowLcKh" ,"MarkazAmar");
    }



        public IActionResult RecheckLcF(int ID)
    
    {
        
        List<LCF> l = new List<LCF>();
        l = db.lcfs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 0;
                db.lcfs.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction( "ShowLcF" ,"MarkazAmar");
    }


            public IActionResult RecheckLcR(int ID)
    
    {
        
        List<LcRequest> l = new List<LcRequest>();
        l = db.lcRequests.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.Status = 0;
                db.lcRequests.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction( "ShowLcR" ,"MarkazAmar");
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


        public IActionResult RequestLcF()
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
        if (vm.img!=null)
        {
            r.ImageName = UploadImage(vm.img);

        }
        else
        {
                    r.ImageName = null;

        }
        r.MablaghR = vm.MablaghR;
        r.SherkatId = vm.SherkatId;
        List<Sherkat> l = new List<Sherkat>();
        l = db.sherkats.OrderBy(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == Convert.ToInt32(r.SherkatId))
            {
                r.NameSherkat = item.NameSherkat;
            }
        }
        r.Status=0;
        r.TarikhR = vm.TarikhR;
        r.Tonazh = vm.TonazhR;
        r.Tozih = vm.Tozih;
        r.Vaste = vm.NameVasete;
        db.lcRequests.Add(r);
        db.SaveChanges();
        return RedirectToAction("RequestLcF");
    }

    public IActionResult LcF(int id)
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



        var edit = db.lcRequests.Find(id);
        VM_LCKh lcc = new VM_LCKh();
        lcc.TarikhR=edit.TarikhR;
        lcc.TonazhR=edit.Tonazh;
        lcc.MablaghR=edit.MablaghR;
        lcc.RId=edit.Id;
        lcc.NameVasete=edit.Vaste;
        lcc.SherkatId=edit.SherkatId.ToString();
        lcc.NameSherkat=edit.NameSherkat;









        return View(lcc);
    }

        [HttpPost]
    public IActionResult AddLCFToDb(VM_LCKh d)
    {
        LCF doc = new LCF();
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
        doc.RId=d.RId;
        List <LcRequest> laa = new List <LcRequest> ();
        
        laa = db.lcRequests.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in laa)
        {
            if (item.Id == d.RId)
            {

                item.Status = 4;
                db.lcRequests.Update(item);
            }
        }
        db.lcfs.Add(doc);
        db.SaveChanges();


        return RedirectToAction("readylcf");
    }


        public IActionResult ReadyLcF()
    {
        ViewBag.Doc = db.lcRequests
        .OrderBy(a => a.Id)
        .GroupBy(a => a.Id)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }




}

