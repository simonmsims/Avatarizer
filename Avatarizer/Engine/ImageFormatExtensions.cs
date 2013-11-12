namespace Avatarizer.Engine
{
  using System.Drawing.Imaging;
  using System.Linq;

  internal static class ImageFormatExtensions
  {
    internal static string GetMimeType(this ImageFormat imageFormat)
    {
      var codecs = ImageCodecInfo.GetImageEncoders();
      return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
    }
  }
}