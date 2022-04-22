namespace Twitter.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using ViewModel;
    using DataAccess;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    public class UserController : Controller
    {
        readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var isExist = _dataContext.RegisterModel.FirstOrDefault(x => x.userName == register.userName
                               || x.Email == register.Email);
                if(isExist!= null)
                {
                    ViewBag.Message = "User Already Exist";
                    return View(isExist);
                }
                else
                {
                    _dataContext.RegisterModel.Add(register);
                    _dataContext.SaveChanges();
                    ViewBag.Message = "User Added Successfully";
                }
            }
            return RedirectToAction("Index","Home",ViewBag.Message);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInModel loginDetails)
        {
            if (ModelState.IsValid)
            {
                var isExist = _dataContext.RegisterModel.Where(x => x.userName == loginDetails.userName
                            || loginDetails.Email == loginDetails.Email && x.password == loginDetails.password).FirstOrDefault();
                if(isExist!=null)
                {
                    HttpContext.Session.SetString("_UserName", isExist.userName.ToString());
                    HttpContext.Session.SetString("_UserId", isExist.Id.ToString());
                    return RedirectToAction("Index", "Dashboard");
                }
               
            }
            ViewBag.Message = "Invaild login detials";
            return View();
        }
        public IActionResult Profile()
        {
            var CurrentUser = int.Parse(HttpContext.Session.GetString("_UserId"));
            var ProfileData = _dataContext.RegisterModel.FirstOrDefault(x =>x.Id==CurrentUser);
            var userTweets = _dataContext.TweetsModel.Where(x => x.UserId == CurrentUser).OrderByDescending(x=>x.createdAt).ToList();
            if (ProfileData != null)
            {
                ViewBag.UserData = ProfileData;
                ViewBag.userTweets = userTweets;
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserId");
            HttpContext.Session.Remove("_UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}
