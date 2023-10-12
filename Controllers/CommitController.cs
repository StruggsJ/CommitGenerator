using Microsoft.AspNetCore.Mvc;
using ProtoType.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProtoType.Controllers
{
    public class CommitController : Controller
    {
        public IActionResult Index()
        {
            //var client = new HttpClient();
            //var url = "https://whatthecommit.com/index.txt";
            //var response = client.GetStringAsync(url).Result;

            //Newtonsoft.Json.JsonReaderException: 'Unexpected character encountered while parsing value: c. Path '', line 0, position 0.' 
            //response url is a string from a website.
            // var root = JsonConvert.DeserializeObject<CommitRoot>(response);

            // Error will appear: Can not find "commit here".cshtml if using either or:
            //var root = JsonConvert.ToString(response);
            // var root = response.ToString(); 

            var api = new APICall();
            var generatedCommit = api.GetCommit();
            return View(generatedCommit);
        }
    }
}
