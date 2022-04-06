namespace Twitter.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Twitter.DataAccess;
    using Twitter.Models;
    using System;
    using Microsoft.AspNetCore.Http;
    using System.Linq;

    public class DashboardController : Controller
    {
        private readonly DataContext _dataContext;
        const string SessionUserName = "_UserName";
        const string SessionUserId = "_UserId";
        public DashboardController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var Id= int.Parse(HttpContext.Session.GetString(SessionUserId));
            var userTweets = _dataContext.TweetsModel.ToList();
            if (userTweets != null && userTweets.Count() != 0)
            {
               ViewBag.userTweets = userTweets;
            }
            return View();
        }

        public IActionResult NewTweet()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewTweet(TweetModel PostedTweet)
        {
            if (ModelState.IsValid)
            {
                PostedTweet.UserId =int.Parse(HttpContext.Session.GetString(SessionUserId));
                PostedTweet.createdAt = DateTime.Now;
                PostedTweet.updatedAt = DateTime.Now;
                _dataContext.TweetsModel.Add(PostedTweet);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}
