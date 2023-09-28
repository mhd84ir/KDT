using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;



public class UserController : Controller
{
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public UserController(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }

    public IActionResult Add()
    {
        return View();
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

        public IActionResult AddToDb(VM_User vu)
    {
        user us = new user();
        if (us.AdminStatus==true)
        {
        us.AdminStatus=true;
        us.LcStatus=true;
        us.NaghdiStatus=true;
        us.SaderatStatus=true;
        }
        else
        {
        us.LcStatus=vu.LcStatus;
        us.NaghdiStatus=vu.NaghdiStatus;
        us.SaderatStatus=vu.SaderatStatus;
        us.AdminStatus=vu.AdminStatus;
        }
        us.Email=vu.Email;
        us.Id=vu.Id;
        us.Name=vu.Name;
        us.PassWord=vu.PassWord;
        us.Phone=vu.Phone;
        if (us.UserName==null)
        {
            us.UserName=vu.Phone;
        }
        else
        {
            us.UserName=vu.UserName;
        }
        if (vu.img!=null)
        {
            us.ImageName=UploadImage(vu.img);

        }
        else
        {
            us.ImageName=null;
        }
        db.users.Add(us);
        db.SaveChanges();
        return RedirectToAction("Add");

    }


    public IActionResult ShowUser()
    {
        ViewBag.Doc = db.users
        .OrderBy(a => a.Id)
        .GroupBy(a => a.Id)
        .Select(g => g.FirstOrDefault())
        .ToList();
        return View();
    }

    public IActionResult Delete(int ID)
    {
        user doc = db.users.Find(ID);
        db.users.Remove(doc);
        db.SaveChanges();
        return RedirectToAction("ShowUser");
    }

        public IActionResult Edit(int id)
    {

        var vu = db.users.Find(id);
        VM_User us = new VM_User();
        us.LcStatus=vu.LcStatus;

        us.NaghdiStatus=vu.NaghdiStatus;

        us.SaderatStatus=vu.SaderatStatus;

        us.AdminStatus=vu.AdminStatus;

        us.Email=vu.Email;

        us.Id=vu.Id;

        us.Name=vu.Name;

        us.PassWord=vu.PassWord;

        us.Phone=vu.Phone;

        us.UserName=vu.UserName;
        us.ImageName=vu.ImageName;

        return View(us);
    }


        public IActionResult Updatee(VM_User vu)
    {
        user us = new user();
        us.LcStatus=vu.LcStatus;

        us.NaghdiStatus=vu.NaghdiStatus;

        us.SaderatStatus=vu.SaderatStatus;

        us.AdminStatus=vu.AdminStatus;

        us.Email=vu.Email;

        us.Id=vu.Id;

        us.Name=vu.Name;

        us.PassWord=vu.PassWord;

        us.Phone=vu.Phone;

        us.UserName=vu.UserName;
        us.ImageName=vu.ImageName;
        db.users.Update(us);
        db.SaveChanges();
        return RedirectToAction("ShowUser");
    }





}
