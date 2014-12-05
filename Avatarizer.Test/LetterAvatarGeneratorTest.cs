namespace Avatarizer.Test
{
  using FluentAssertions;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class LetterAvatarGeneratorTest : AvatarGeneratorAbstractTest
  {
    protected char[] OneInitialMock = { 'M' };

    protected char[] TwoInitialsMock = { 'M', 'F' };

    protected char[] ThreeInitialsMock = { 'M', 'F', 'R' };

    [TestMethod]
    public void CreateInstanceTest()
    {
      var generator = new LetterAvatarGenerator(this.TwoInitialsMock, new AvatarOptions());
      generator.Should().NotBeNull();
    }

    [TestMethod]
    public void GetAvatarWithOneInitialTest()
    {
      GetAvatarTest(this.OneInitialMock);
    }

    [TestMethod]
    public void GetAvatarWithTwoInitialsTest()
    {
      GetAvatarTest(this.TwoInitialsMock);
    }

    [TestMethod]
    public void GetAvatarWithThreeInitialsTest()
    {
      GetAvatarTest(this.ThreeInitialsMock);
    }

    private static void GetAvatarTest(char[] initials)
    {
      var generator = new LetterAvatarGenerator(initials, new AvatarOptions());
      var avatar = generator.GetAvatar();
      avatar.Should().NotBeNull();
      avatar.Blob.Should().NotBeEmpty();
      avatar.ContentType.Should().NotBeNullOrEmpty();
    }
  }
}
