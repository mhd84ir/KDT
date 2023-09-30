//create class
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Authorize (Roles = "Admin")]
public class AdminController : Controller
{
    //create object of database
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public AdminController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
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

        public IActionResult LcKhAcsept()
    {
        ViewBag.Doc = db.lCKhs
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        return View();
    }

        public IActionResult LcFAcsept()
    {
        ViewBag.Doc = db.lcfs
.OrderBy(a => a.Id)
.GroupBy(a => a.Id)
.Select(g => g.FirstOrDefault())
.ToList();
        return View();
    }

    public IActionResult LcRAcsept()
    {
        ViewBag.Doc = db.lcRequests
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


    public IActionResult StatusRejectLcKh(int ID)
    {
        List <LCKh> l = new List <LCKh> ();
        
        l = db.lCKhs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 2;
                db.lCKhs.Update(item);
            }
            db.SaveChanges();
        }
        return RedirectToAction("LcKhAcsept");
    }

    public IActionResult StatusAcseptLcKh(int ID)
    
    {
        
        List<LCKh> l = new List<LCKh>();
        l = db.lCKhs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 3;
                db.lCKhs.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction("LcKhAcsept");
    }

    public IActionResult StatusRejectLcF(int ID)
    {
        List <LCF> l = new List <LCF> ();
        
        l = db.lcfs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 2;
                db.lcfs.Update(item);
            }
            db.SaveChanges();
        }
        return RedirectToAction("LcFAcsept");
    }

    public IActionResult StatusAcseptLcF(int ID)
    
    {
        
        List<LCF> l = new List<LCF>();
        l = db.lcfs.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.status = 3;
                db.lcfs.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction("LcFAcsept");
    }


        public IActionResult StatusRejectLcR(int ID)
    {
        List <LcRequest> l = new List <LcRequest> ();
        
        l = db.lcRequests.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.Status = 2;
                db.lcRequests.Update(item);
            }
            db.SaveChanges();
        }
        return RedirectToAction("LcRAcsept");
    }

    public IActionResult StatusAcseptLcR(int ID)
    
    {
        
        List<LcRequest> l = new List<LcRequest>();
        l = db.lcRequests.OrderByDescending(a => a.Id).GroupBy(x => x.Id).Select(e => e.FirstOrDefault()).ToList();
        foreach (var item in l)
        {
            if (item.Id == ID)
            {

                item.Status = 3;
                db.lcRequests.Update(item);
            }

            db.SaveChanges();
        }
        return RedirectToAction("LcRAcsept");
    }



}