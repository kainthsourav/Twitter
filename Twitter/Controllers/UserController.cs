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
        const string SessionUserName = "_UserName";
        const string SessionUserId = "_UserId";
       
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
                    ViewBag.Message = "Cannot create signup";
                }
                else
                {
                    _dataContext.RegisterModel.Add(register);
                    _dataContext.SaveChanges();
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
               var  isExist=_dataContext.RegisterModel.FirstOrDefault(x => x.userName == loginDetails.userName 
                             || x.Email==loginDetails.userName && x.password==x.password);
                if(isExist!=null)
                {
                    HttpContext.Session.SetString(SessionUserName, isExist.userName.ToString());
                    HttpContext.Session.SetString(SessionUserId, isExist.Id.ToString());
                    return RedirectToAction("Index", "Dashboard");
                }
               
            }
            return View();
        }
        public IActionResult Profile()
        {
            var CurrentUser = int.Parse(HttpContext.Session.GetString(SessionUserId));
            var ProfileData = _dataContext.RegisterModel.FirstOrDefault(x =>x.Id==CurrentUser);
            var userTweets = _dataContext.TweetsModel.Where(x => x.UserId == CurrentUser).ToList();
            if (ProfileData != null)
            {
                ViewBag.UserData = ProfileData;
                ViewBag.userTweets = userTweets;
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
