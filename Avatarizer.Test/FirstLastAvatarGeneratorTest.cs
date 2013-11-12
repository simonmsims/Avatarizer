namespace Avatarizer.Test
{
  using FluentAssertions;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class FirstLastAvatarGeneratorTest
  {
    [TestMethod]
    public void CreateInstanceTest()
    {
      var generator = new FirstLastAvatarGeneratorTest();
      generator.Should().NotBeNull();
    }
  }
}
