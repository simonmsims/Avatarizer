namespace Avatarizer.Example.Helper
{
  using System;

  internal static class RandomLetterGenerator
  {
    private static readonly Random Random = new Random();

    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    internal static char[] GetRandomCharacters(int count)
    {
      var buffer = new char[count];

      for (int i = 0; i < count; i++)
      {
        buffer[i] = Characters[Random.Next(Characters.Length)];
      }

      return buffer;
    }
  }
}