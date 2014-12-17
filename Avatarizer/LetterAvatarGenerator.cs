namespace Avatarizer
{
  using System;
  using System.Drawing;
  using System.Drawing.Drawing2D;
  using System.Drawing.Text;
  using System.Linq;

  /// <summary>
  /// Generates avatar with two initials.
  /// </summary>
  public class LetterAvatarGenerator : AvatarGeneratorAbstract
  {
    #region Fields

    /// <summary>
    /// Avatar style.
    /// </summary>
    private readonly AvatarStyle style;

    /// <summary>
    /// Displayed text on the avatar.
    /// </summary>
    private readonly string text;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the LetterAvatarGenerator class.
    /// </summary>
    /// <param name="initials">User's initials.</param>
    /// <param name="options">Additional avatar options.</param>
    public LetterAvatarGenerator(char[] initials, AvatarOptions options)
      : base(initials, options)
    {
      this.text = this.GetText();
      this.style = this.GetStyle();
    }

    /// <summary>
    /// Initializes a new instance of the LetterAvatarGenerator class.
    /// </summary>
    /// <param name="initials">User's initials.</param>
    public LetterAvatarGenerator(char[] initials)
      : this(initials, new AvatarOptions())
    {
    }

    #endregion
    
    #region Overriden

    /// <summary>
    /// Generates and returns avatar based on user initials.
    /// </summary>
    /// <returns>Avatar blob and content type.</returns>
    public override Avatar GetAvatar()
    {
      using (var bitmap = new Bitmap(this.Options.Size.Width, this.Options.Size.Height))
      {
        this.DrawAvatar(bitmap);

        return this.ToAvatar(bitmap);
      }
    }

    #endregion
    
    #region Private

    /// <summary>
    /// Draws avatar on a given bitmap.
    /// </summary>
    /// <param name="bitmap">Given bitmap.</param>
    private void DrawAvatar(Bitmap bitmap)
    {
      using (var graphics = Graphics.FromImage(bitmap))
      {
        // Use anti aliasing for high resolution avatar rendering
        if (this.Options.UseHighQuality)
        {
          graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        // Draw background ...
        using (var brush = new SolidBrush(this.style.BackgroundColor))
        {
          graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
        }

        var rectangle = new RectangleF(0, 0, this.Options.Size.Width, this.Options.Size.Height);

        var format = new StringFormat
        {
          LineAlignment = StringAlignment.Center,
          Alignment = StringAlignment.Center
        };

        // Draw shadow if needed
        if (this.Options.TextShadow)
        {
          // Draw shadow below text ...
          using (var brush = new SolidBrush(Color.FromArgb(140, 0, 0, 0)))
          {
            const int ShadowSize = 1;
            var shadowRectangle = new RectangleF(
              rectangle.X + ShadowSize,
              rectangle.Y + ShadowSize,
              rectangle.Size.Width + ShadowSize,
              rectangle.Height + ShadowSize);
            graphics.DrawString(this.text, this.Options.Font, brush, shadowRectangle, format);
          }
        }

        // Draw text ...
        using (var brush = new SolidBrush(this.style.TextColor))
        {
          graphics.DrawString(this.text, this.Options.Font, brush, rectangle, format);
        }
      }
    }
    
    /// <summary>
    /// Gets text displayed on the avatar.
    /// </summary>
    /// <returns>Avatar text.</returns>
    private string GetText()
    {
      return string.Join(string.Empty, this.Initials.Take(2));
    }
    
    /// <summary>
    /// Gets style for the avatar.
    /// </summary>
    /// <returns>Avatar style.</returns>
    private AvatarStyle GetStyle()
    {
      var styles = this.Options.Styles;

      var characters = this.text.ToCharArray();
      var sumAscii = characters.Sum(character => Convert.ToInt32(character));

      var index = sumAscii % styles.Count;

      if (index < 0 || index >= styles.Count)
      {
        throw new InvalidOperationException("Invalid avatar style index");
      }

      return styles[index];
    }

    #endregion
  }
}
