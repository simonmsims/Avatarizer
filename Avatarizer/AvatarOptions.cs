using System.Drawing;

namespace Avatarizer
{
  using System;
  using System.Collections.Generic;
 

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
      this.TextMargin = new Point(0, 0);

      this.Styles = new List<AvatarStyle>
        {
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#2980b9"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#27ae60"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#e67e22"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#f1c40f"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#8e44ad"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#2c3e50"), TextColor = Color.White },
          new AvatarStyle { BackgroundColor = this.GetHtmlColor("#c0392b"), TextColor = Color.White }
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

    /// <summary>
    /// Gets or sets a boolean flag indicating whether we should draw shadow below the text.
    /// </summary>
    public bool TextShadow { get; set; }

    /// <summary>
    /// Gets or sets a boolean flag indicating whether we want high quality render or not.
    /// </summary>
    public bool UseHighQuality { get; set; }

    /// <summary>
    /// Gets or sets a margin for positioning the text.
    /// </summary>
    public Point TextMargin { get; set; }

    #region Private

    /// <summary>
    /// Gets color from a given html color string.
    /// </summary>
    /// <param name="htmlColor">Html color.</param>
    /// <returns>Color struct.</returns>
    private Color GetHtmlColor(string htmlColor)
    {
      var colorConverter = new ColorConverter();
      var color = colorConverter.ConvertFromString(htmlColor) as Color?;
      if (!color.HasValue)
      {
        throw new ArgumentException("Unable to get color from html string: " + htmlColor);
      }

      return color.Value;
    }

    #endregion
  }
}