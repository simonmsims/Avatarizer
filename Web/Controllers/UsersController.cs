namespace Web.Controllers
{
  using System.Drawing;
  using System.Web.Mvc;

  using Avatarizer;

  using Web.Helper;

  public class UsersController : Controller
  {
    [HttpGet]
    public FileContentResult Avatar(int id)
    {
      // Avatarizer uses only first letter so we don't need to mock entire names
      var generator = new RandomLetterGenerator();
      var firstName = generator.GetRandomCharacter();
      var lastName = generator.GetRandomCharacter();

      var avatarGenerator = new AvatarFactory(firstName, lastName, this.GetAvatarOptions());
      var file = avatarGenerator.GetAvatar();
      return this.File(file.Blob, file.ContentType);
    }

    [NonAction]
    private AvatarOptions GetAvatarOptions()
    {
      var options = new AvatarOptions();
      options.Size = new Size(40, 40);
      options.Font = new Font("Arial", 14, FontStyle.Bold);
      return options;
    }
  }
}
