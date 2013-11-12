namespace Avatarizer.Generator.Engine
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Globalization;
  using System.Linq;

  /// <summary>
  /// Generates avatar with first letter of the first name and first letter of the last name.
  /// </summary>
  internal class FirstLastAvatarGenerator : AvatarGeneratorAbstract
  {
    #region Properties

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
    /// Initializes a new instance of the FirstLastAvatarGenerator class.
    /// </summary>
    /// <param name="firstName">User's first name.</param>
    /// <param name="lastName">User's last name.</param>
    /// <param name="options">Additional avatar options.</param>
    public FirstLastAvatarGenerator(string firstName, string lastName, AvatarOptions options)
      : base(firstName, lastName, options)
    {
      this.text = this.GetText();
      this.style = this.GetStyle();
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
        // Draw background ...
        using (var brush = new SolidBrush(this.style.BackgroundColor))
        {
          graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
        }

        // Draw text ...
        using (var brush = new SolidBrush(this.style.TextColor))
        {
          var rectangle = new RectangleF(0, 0, this.Options.Size.Width, this.Options.Size.Height);

          var format = new StringFormat
            {
              LineAlignment = StringAlignment.Center,
              Alignment = StringAlignment.Center
            };

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
      var firstLetter = this.FirstName.Substring(0, 1).ToUpperInvariant();
      var secondLetter = this.LastName.Substring(0, 1).ToUpperInvariant();
      return string.Format(CultureInfo.InvariantCulture, "{0}{1}", firstLetter, secondLetter);
    }
    
    /// <summary>
    /// Gets style for the avatar.
    /// </summary>
    /// <returns>Avatar style.</returns>
    private AvatarStyle GetStyle()
    {
      var styles = new List<AvatarStyle>
        {
          new AvatarStyle { BackgroundColor = Color.OrangeRed, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.Orange, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.Purple, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.DarkSlateGray, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.Green, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.Gold, TextColor = Color.Black },
          new AvatarStyle { BackgroundColor = Color.DodgerBlue, TextColor = Color.Black }
        };

      var avatarText = this.GetText();
      var characters = avatarText.ToCharArray();
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