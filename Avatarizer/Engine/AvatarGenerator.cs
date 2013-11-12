namespace Avatarizer.Engine
{
  using System;
  using System.Drawing;
  using System.Globalization;

  public class AvatarGenerator : AvatarGeneratorAbstract, IDisposable
  {
    #region Constructors

    public AvatarGenerator(string firstName, string lastName, AvatarOptions options)
      : base(firstName, lastName, options)
    {
    }

    #endregion

    #region Overriden

    public override FileInfo GetAvatar()
    {
      using (var bitmap = new Bitmap(this.Options.Size.Width, this.Options.Size.Height))
      {
        this.DrawAvatar(bitmap);

        return this.GetFile(bitmap);
      }
    }

    #endregion

    #region IDisposable implementation

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    // NOTE: Leave out the finalizer altogether if this class doesn't 
    // own unmanaged resources itself, but leave the other methods
    // exactly as they are. 
    ~AvatarGenerator()
    {
      this.Dispose(false);
    }

    // The bulk of the clean-up code is implemented in Dispose(bool)
    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        // free managed resources here ...
      }

      // free native resources if there are any ...
    }

    #endregion

    #region Private

    private void DrawAvatar(Bitmap bitmap)
    {
      using (var graphics = Graphics.FromImage(bitmap))
      {
        // Draw background ...
        var backgroundColor = this.GetBackgroundColor();
        using (var brush = new SolidBrush(backgroundColor))
        {
          graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
        }

        // Draw text ...
        var textColor = this.GetTextColor();
        using (var brush = new SolidBrush(textColor))
        {
          var text = this.GetText();
          var rectangle = new RectangleF(0, 0, this.Options.Size.Width, this.Options.Size.Height);

          var format = new StringFormat
            {
              LineAlignment = StringAlignment.Center,
              Alignment = StringAlignment.Center
            };

          graphics.DrawString(text, this.Options.Font, brush, rectangle, format);
        }
      }
    }
    
    private string GetText()
    {
      var firstLetter = this.FirstName.Substring(0, 1).ToUpperInvariant();
      var secondLetter = this.LastName.Substring(0, 1).ToUpperInvariant();
      return string.Format(CultureInfo.InvariantCulture, "{0}{1}", firstLetter, secondLetter);
    }

    private Color GetBackgroundColor()
    {
      return Color.Chocolate;
    }

    private Color GetTextColor()
    {
      return Color.Black;
    }

    #endregion
  }
}