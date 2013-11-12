namespace Avatarizer.Generator.Engine
{
  using System.Drawing.Imaging;
  using System.Linq;

  /// <summary>
  /// Image format extensions.
  /// </summary>
  internal static class ImageFormatExtensions
  {
    /// <summary>
    /// Gets mime type for a given image format.
    /// </summary>
    /// <param name="imageFormat">Given image format.</param>
    /// <returns>Mime type.</returns>
    internal static string GetMimeType(this ImageFormat imageFormat)
    {
      var codecs = ImageCodecInfo.GetImageEncoders();
      return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
    }
  }
}