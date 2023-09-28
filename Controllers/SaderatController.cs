
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SaderatController : Controller
{
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public SaderatController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
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

        public IActionResult PrintDolar()
    {
        return View();
    }

}