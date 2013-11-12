namespace Avatarizer.Engine
{
  using System.Drawing;

  public class AvatarOptions
  {
    public Size Size { get; set; }

    public Font Font { get; set; }

    public AvatarOptions()
    {
      this.Size = new Size(100, 100);
      this.Font = new Font("Arial", 24, FontStyle.Bold);
    }
  }
}