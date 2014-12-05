namespace Web.Controllers
{
  using System;
  using System.Drawing;
  using System.Web.Mvc;

  using Avatarizer;

  using Web.Helper;

  public class UsersController : Controller
  {
    [HttpGet]
    public FileContentResult Avatar(long id, int? width, int? height)
    {
      var initials = RandomLetterGenerator.GetRandomCharacters(2);
      var avatarGenerator = new LetterAvatarGenerator(initials, this.GetAvatarOptions(width, height));
      var file = avatarGenerator.GetAvatar();
      return this.File(file.Blob, file.ContentType);
    }

    [HttpGet]
    public ActionResult Profile(long id)
    {
      return this.View("~/Views/User/Index.cshtml");
    }

    [NonAction]
    private AvatarOptions GetAvatarOptions(int? width, int? height)
    {
      var options = new AvatarOptions();
      options.Size = new Size(width ?? 40, height ?? 40);

      var fontSize = (int)Math.Floor(Math.Min(options.Size.Width, options.Size.Height) / 2.8);
      options.Font = new Font("Arial", fontSize, FontStyle.Bold);

      return options;
    }
  }
}
