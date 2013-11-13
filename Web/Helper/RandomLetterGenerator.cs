namespace Web.Helper
{
  using System;

  internal class RandomLetterGenerator
  {
    private static readonly Random Random = new Random();

    private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string GetRandomCharacter()
    {
      return this.GetRandomString(1);
    }

    private string GetRandomString(int size)
    {
      var buffer = new char[size];

      for (int i = 0; i < size; i++)
      {
        buffer[i] = characters[Random.Next(characters.Length)];
      }

      return new string(buffer);
    }
  }
}