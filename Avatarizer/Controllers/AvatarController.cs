namespace Avatarizer.Controllers
{
  using System.Collections.Generic;
  using System.Drawing;
  using System.Web.Mvc;

  using Avatarizer.Engine;

  public class AvatarController : Controller
  {
    private static readonly Dictionary<int, string> FirstNames = new Dictionary<int,string>
      {
        { 0, "Miha" },
        { 1, "Andrej" },
        { 2, "Andraz" },
        { 3, "Luka" },
        { 4, "Matjaz" }
      };

    private static readonly Dictionary<int, string> LastNames = new Dictionary<int, string>
      {
        { 0, "Rataj" },
        { 1, "Drobnic" },
        { 2, "Bezek" },
        { 3, "Por" },
        { 4, "Skulj" }
      };

    public FileContentResult User(int id)
    {
      id = id % 5;

      var firstName = FirstNames[id];
      var lastName = LastNames[id];

      using (var avatarGenerator = new AvatarGenerator(firstName, lastName, this.GetAvatarOptions()))
      {
        var file = avatarGenerator.GetAvatar();
        return this.File(file.Blob, file.ContentType);
      }
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
