namespace Avatarizer.Test
{
  using Avatarizer.Engine;

  using FluentAssertions;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class FirstLastAvatarGeneratorTest : AvatarGeneratorAbstractTest
  {
    [TestMethod]
    public void CreateInstanceTest()
    {
      var generator = new FirstLastAvatarGenerator(FirstNameMock, LastNameMock, null);
      generator.Should().NotBeNull();
    }

    [TestMethod]
    public void GetAvatarTest()
    {
      var generator = new FirstLastAvatarGenerator(FirstNameMock, LastNameMock, null);
      var avatar = generator.GetAvatar();
      avatar.Should().NotBeNull();
    }
  }
}
