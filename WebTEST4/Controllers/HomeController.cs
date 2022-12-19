using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTEST4.Models;

namespace WebTEST4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            context.Default();
            return View();
        }
        public IActionResult Weapons()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (context.isAuthorized())
                return View(context.GetModelByType(context.UniqueID(), 1));
            else
                return Redirect("Bad");
        }
        public IActionResult AddItem()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (context.isAuthorized())
                return View(context.GetAllItems());
            else
                return Redirect("Bad");
        }

        public IActionResult Resources()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (context.isAuthorized())
                return View(context.GetModelByType(context.UniqueID(), 4));
            else
                return Redirect("Bad");
        }
        public IActionResult Food()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (context.isAuthorized())
                return View(context.GetModelByType(context.UniqueID(), 2));
            else
                return Redirect("Bad");
        }
        public IActionResult Quest()
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (context.isAuthorized())
                return View(context.GetModelByType(context.UniqueID(), 3));
            else
                return Redirect("Bad");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Bad()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            List<User> users = context.GetAllUsers();
            foreach(User i in users)
            {
                if (username == i.user_name && password == i.user_pass)
                {
                    context.Authorize(i.user_id);
                    return Redirect("Home/Weapons");
                }
            }
            return Redirect("Home/Bad");
        }
        [HttpPost]
        public IActionResult Registration(string username, string password)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            List<User> users = context.GetAllUsers();
            foreach( User i in users)
            {
                if (username == i.user_name)
                {
                    Console.WriteLine("Такой пользователь уже существует");
                    return View();
                }
                else
                {
                    context.AddUser(username, password);
                    return Redirect("Login");
                }
            }
            return Redirect("Bad");
        }
        [HttpPost]
        public IActionResult AddItem(int count, int item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (item == 0) return View(context.GetAllItems());
            List<Inventory> inventories = context.GetAllInventories(context.UniqueID());
            List<Item> items = context.GetAllItems();
            int type = 0;
            int newCount = 0;
            bool isExist = false;
            foreach( Inventory i in inventories)
            {
                if(i.item == item)
                {
                    newCount = i.count + count;
                    isExist = true;
                    break;
                }
                else
                {
                    isExist = false;
                }
            }
            foreach (Item j in items)
            {
                if (item == j.item_id)
                {
                    type = j.item_type;
                    break;
                }
            }
            if (isExist)
                context.EditInventoryCount(newCount, item, context.UniqueID());
            else
                context.AddInventory(item, count, context.UniqueID());

            switch (type)
            {
                case 0: return Redirect("Bad");
                case 1: return Redirect("Weapons");
                case 2: return Redirect("Food");
                case 3: return Redirect("Quest");
                case 4: return Redirect("Resources");
            }
            return Redirect("Bad");
        }
        [HttpPost]
        public IActionResult Resources(string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach(Item i in items)
            {
                if(item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 4));
        }
        [HttpGet]
        public IActionResult Resources(int count, string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            if(count > 0)
                context.EditInventoryCount(count, item_id, context.UniqueID());
            else
                context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 4));
        }
        [HttpPost]
        public IActionResult Weapons(string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 1));
        }
        [HttpGet]
        public IActionResult Weapons(int count, string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            if (count > 0)
                context.EditInventoryCount(count, item_id, context.UniqueID());
            else
                context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 1));
        }
        [HttpPost]
        public IActionResult Food(string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 2));
        }
        [HttpGet]
        public IActionResult Food(int count, string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            if (count > 0)
                context.EditInventoryCount(count, item_id, context.UniqueID());
            else
                context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 2));
        }
        [HttpPost]
        public IActionResult Quest(string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 3));
        }
        [HttpGet]
        public IActionResult Quest(int count, string item)
        {
            Models.AppContext context = HttpContext.RequestServices.GetService(typeof(Models.AppContext)) as Models.AppContext;
            if (!context.isAuthorized()) return Redirect("Bad");
            List<Item> items = context.GetAllItems();
            int item_id = 0;
            foreach (Item i in items)
            {
                if (item == i.item_name)
                {
                    item_id = i.item_id;
                    break;
                }
            }
            if (count > 0)
                context.EditInventoryCount(count, item_id, context.UniqueID());
            else
                context.DeleteItem(item_id, context.UniqueID());
            return View(context.GetModelByType(context.UniqueID(), 3));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}