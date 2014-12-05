namespace Avatarizer
{
  /// <summary>
  /// Avatar image.
  /// </summary>
  public class Avatar
  {
    /// <summary>
    /// Gets or sets avatar's image blob.
    /// </summary>
    public byte[] Blob { get; set; }

    /// <summary>
    /// Gets or sets blob's content type.
    /// </summary>
    public string ContentType { get; set; }
  }
}
