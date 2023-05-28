using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sushi.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        DataClasses1DataContext data;

        public MenuController()
        {
            string connectionString = "YOUR_CONNECTION_STRING";
            data = new DataClasses1DataContext(connectionString);
        }

        public ActionResult ListMenu()
        {
            var all_menu = from ss in data.Sushis select ss;
            return View(all_menu);
        }
    }
}