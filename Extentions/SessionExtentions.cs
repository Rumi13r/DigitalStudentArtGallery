using DigitalStudentArtGallery.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using DigitalStudentArtGallery.Entities;
using System.Text.Json;

namespace DigitalStudentArtGallery.Extentions
{
    

    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult MyProfile()
        {
            User loggedUser = HttpContext.Session.GetObject<User>("loggedUser");
            MyProfileVM User = new MyProfileVM();

            User.FirstName = loggedUser.FirstName;
            User.LastName = loggedUser.LastName;
            User.Username = loggedUser.Username;
            User.Password = loggedUser.Password;

            return View(User);
        }

    }
}

