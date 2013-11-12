namespace Avatarizer.Generator.Engine
{
  using System;
  using System.Drawing;
  using System.Drawing.Imaging;
  using System.IO;

  /// <summary>
  /// Avatar generator abstract class.
  /// </summary>
  internal abstract class AvatarGeneratorAbstract
  {
    /// <summary>
    /// Initializes a new instance of the AvatarGeneratorAbstract class.
    /// </summary>
    /// <param name="firstName">User's first name.</param>
    /// <param name="lastName">User's last name.</param>
    /// <param name="options">Additional avatar options.</param>
    protected AvatarGeneratorAbstract(string firstName, string lastName, AvatarOptions options)
    {
      if (string.IsNullOrWhiteSpace(firstName))
      {
        throw new ArgumentException("First name cannot be null or whitespace");
      }

      if (string.IsNullOrWhiteSpace(lastName))
      {
        throw new ArgumentException("Last name cannot be null or whitespace");
      }

      this.FirstName = firstName;
      this.LastName = lastName;
      this.Options = options;
    }

    /// <summary>
    /// Gets user's first name.
    /// </summary>
    protected string FirstName { get; private set; }

    /// <summary>
    /// Gets user's last name.
    /// </summary>
    protected string LastName { get; private set; }

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