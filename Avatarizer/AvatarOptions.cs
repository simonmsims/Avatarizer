namespace Avatarizer
{
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
    }

    /// <summary>
    /// Gets or sets size of the avatar.
    /// </summary>
    public Size Size { get; set; }

    /// <summary>
    /// Gets or sets font of the text on the avatar.
    /// </summary>
    public Font Font { get; set; }
  }
}