namespace Avatarizer.Test
{
  using Avatarizer.Engine;

  using FluentAssertions;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class LetterAvatarGeneratorTest : AvatarGeneratorAbstractTest
  {
    [TestMethod]
    public void CreateInstanceTest()
    {
      var generator = new LetterAvatarGenerator(FirstNameMock, LastNameMock, new AvatarOptions());
      generator.Should().NotBeNull();
    }

    [TestMethod]
    public void GetAvatarTest()
    {
      var generator = new LetterAvatarGenerator(FirstNameMock, LastNameMock, new AvatarOptions());
      var avatar = generator.GetAvatar();
      avatar.Should().NotBeNull();
      avatar.Blob.Should().NotBeEmpty();
      avatar.ContentType.Should().NotBeNullOrEmpty();
    }
  }
}
