using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KDT.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace KDT.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        // WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");
        // string[] rcpts = new string[] { "+989016250035" };
        // string json = JsonConvert.SerializeObject(rcpts);
        // request.Method = "POST";
        // string postData = "op=send&uname=09123409965&pass=mh123321&message=hello Test&to="+json+"&from=+983000505";
        // byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        // request.ContentType = "application/x-www-form-urlencoded";
        // request.ContentLength = byteArray.Length;
        // Stream dataStream = request.GetRequestStream();
        // dataStream.Write(byteArray, 0, byteArray.Length);
        // dataStream.Close();
        // WebResponse response = request.GetResponse();
        // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        // dataStream = response.GetResponseStream();
        // StreamReader reader = new StreamReader(dataStream);
        // string responseFromServer = reader.ReadToEnd();
        // Console.WriteLine(responseFromServer);
        // reader.Close();
        // dataStream.Close();
        // response.Close();
        // System.Diagnostics.Debug.WriteLine(responseFromServer);

        return View();
    }

    //         static void Main(string[] args)
    //     {
    //         PanelSMS.smsserver client = new PanelSMS.smsserver();
    //         var username = "";
    //         var password = "";
    //         var fromNum = "";
    //         string[] toNum = { "" };

    //         var patternCode = "119";


    //         var data = new PanelSMS.input_data_type[] {
    //             // key is your parameter name and value is what you want to send to the receiptor 
    //             new PanelSMS.input_data_type(){ key ="customer-name",value ="21981" } ,
    //             new PanelSMS.input_data_type(){ key ="number",value ="321233fds" }
    //         };

    //         var response = client.sendPatternSms(fromNum, toNum, username, password, patternCode, data);


    //         Console.WriteLine(response);
    //     }
    // }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
