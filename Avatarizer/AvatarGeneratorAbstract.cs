namespace Avatarizer
{
  using System;
  using System.Drawing;
  using System.Drawing.Imaging;
  using System.IO;

  /// <summary>
  /// Avatar generator abstract class.
  /// </summary>
  public abstract class AvatarGeneratorAbstract
  {
    /// <summary>
    /// Initializes a new instance of the AvatarGeneratorAbstract class.
    /// </summary>
    /// <param name="initials">User's initials.</param>
    /// <param name="options">Additional avatar options.</param>
    protected AvatarGeneratorAbstract(char[] initials, AvatarOptions options)
    {
      if (initials == null)
      {
        throw new ArgumentNullException("initials");
      }
      
      this.Initials = initials;
      this.Options = options;
    }

    /// <summary>
    /// Gets user's first name.
    /// </summary>
    protected char[] Initials { get; private set; }

    /// <summary>
    /// Gets avatar options.
    /// </summary>
    protected AvatarOptions Options { get; private set; }

    /// <summary>
    /// Generates and returns avatar.
    /// </summary>
    /// <returns>Avatar blob and content type.</returns>
    public abstract Avatar GetAvatar();

    /// <summary>
    /// Converts given image to the avatar object.
    /// </summary>
    /// <param name="image">Given image.</param>
    /// <returns>Image blob and content type.</returns>
    protected Avatar ToAvatar(Image image)
    {
      using (var memoryStream = new MemoryStream())
      {
        var imageFormat = ImageFormat.Png;
        image.Save(memoryStream, imageFormat);
        
        return new Avatar { ContentType = imageFormat.GetMimeType(), Blob = memoryStream.ToArray() };
      }
    }
  }
}
