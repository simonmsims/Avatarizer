namespace Avatarizer
{
  using System.Collections.Generic;
  using System.Drawing;

  /// <summary>
  /// Avatar options.
  /// </summary>
  public class AvatarOptions
  {
    /// <summary>
    /// Initializes a new instance of the AvatarOptions class.
    /// </summary>
    public AvatarOptions()
    {
      this.Size = new Size(100, 100);
      this.Font = new Font("Arial", 24, FontStyle.Bold);

      this.Styles = new List<AvatarStyle>
        {
          new AvatarStyle { BackgroundColor = Color.OrangeRed, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.Orange, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.Purple, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.DarkSlateGray, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.Green, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.Gold, TextColor = Color.White },
          new AvatarStyle { BackgroundColor = Color.DodgerBlue, TextColor = Color.White }
        };
    }

    /// <summary>
    /// Gets or sets size of the avatar.
    /// </summary>
    public Size Size { get; set; }

    /// <summary>
    /// Gets or sets font of the text on the avatar.
    /// </summary>
    public Font Font { get; set; }

    /// <summary>
    /// Gets list of possible avatar styles.
    /// </summary>
    public IList<AvatarStyle> Styles { get; private set; }
  }
}