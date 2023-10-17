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
            var api = new APICall();
            var generatedCommit = api.GetCommit();
            return View(generatedCommit);
        }
    }
}
