namespace Web.Controllers
{
  using System.Collections.Generic;
  using System.Drawing;
  using System.Web.Mvc;

  using Avatarizer.Generator;

  public class UsersController : Controller
  {
    private static readonly Dictionary<int, string> FirstNames = new Dictionary<int,string>
      {
        { 0, "Matt" },
        { 1, "Ben" },
        { 2, "Nick" },
        { 3, "Karen" },
        { 4, "Gerry" }
      };

    private static readonly Dictionary<int, string> LastNames = new Dictionary<int, string>
      {
        { 0, "Jones" },
        { 1, "Martin" },
        { 2, "Smith" },
        { 3, "Thompson" },
        { 4, "Baley" }
      };

    [HttpGet]
    public FileContentResult Avatar(int id)
    {
      id = id % 5;

      var firstName = FirstNames[id];
      var lastName = LastNames[id];

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
