using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;

namespace mvc.Controllers
{
    public class FilesController : Controller
    {
        private readonly string target;

        public FilesController(HostingEnvironment e)
        {
            target = $"{e.WebRootPath}/TextFiles";
        }

        public IActionResult Index()
        {
            return View(Directory.GetFiles(target).Select(Path.GetFileNameWithoutExtension));
        }

        [Route("{controller}/{action}/{filename}")]
        public new IActionResult Content(string filename)
        {
            ViewBag.content = System.IO.File.ReadAllText($"{target}/{filename}.txt");
            return View();
        }
    }
}