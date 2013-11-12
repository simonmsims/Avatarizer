namespace Avatarizer.Engine
{
  using System;
  using System.Drawing;
  using System.Drawing.Imaging;
  using System.IO;

  public abstract class AvatarGeneratorAbstract
  {
    protected string FirstName { get; private set; }

    protected string LastName { get; private set; }

    protected AvatarOptions Options { get; private set; }

    protected AvatarGeneratorAbstract(string firstName, string lastName, AvatarOptions options)
    {
      if (string.IsNullOrWhiteSpace(firstName))
        throw new ArgumentException("First name cannot be null or whitespace");

      if (string.IsNullOrWhiteSpace(lastName))
        throw new ArgumentException("Last name cannot be null or whitespace");

      if (options == null)
        throw new ArgumentNullException("options");

      this.FirstName = firstName;
      this.LastName = lastName;
      this.Options = options;
    }

    public abstract FileInfo GetAvatar();

    protected FileInfo GetFile(Image image)
    {
      using (var memoryStream = new MemoryStream())
      {
        var imageFormat = ImageFormat.Png;
        image.Save(memoryStream, imageFormat);
        
        return new FileInfo { ContentType = imageFormat.GetMimeType(), Blob = memoryStream.ToArray() };
      }
    }
  }
}