namespace Avatarizer
{
  using System;

  using Avatarizer.Engine;

  /// <summary>
  /// Avatar generator factory.
  /// </summary>
  public sealed class AvatarFactory
  {
    /// <summary>
    /// User's first name.
    /// </summary>
    private readonly string firstName;

    /// <summary>
    /// User's last name.
    /// </summary>
    private readonly string lastName;

    /// <summary>
    /// Avatar options.
    /// </summary>
    private readonly AvatarOptions options = new AvatarOptions();

    /// <summary>
    /// Generator implementation.
    /// </summary>
    private readonly AvatarGeneratorAbstract implementation;
    
    /// <summary>
    /// Initializes a new instance of the AvatarFactory class.
    /// </summary>
    /// <param name="firstName">User's first name.</param>
    /// <param name="lastName">User's last name.</param>
    public AvatarFactory(string firstName, string lastName)
    {
      if (string.IsNullOrWhiteSpace(firstName))
      {
        throw new ArgumentException("First name cannot be null or whitespace");
      }

      if (string.IsNullOrWhiteSpace(lastName))
      {
        throw new ArgumentException("Last name cannot be null or whitespace");
      }

      this.firstName = firstName;
      this.lastName = lastName;

      this.implementation = this.GetImplementation(AvatarGeneratorType.FirstAndLastName);
    }

    /// <summary>
    /// Initializes a new instance of the AvatarFactory class.
    /// </summary>
    /// <param name="firstName">User's first name.</param>
    /// <param name="lastName">User's last name.</param>
    /// <param name="options">Avatar options.</param>
    public AvatarFactory(string firstName, string lastName, AvatarOptions options)
      : this(firstName, lastName)
    {
      this.options = options;

      this.implementation = this.GetImplementation(AvatarGeneratorType.FirstAndLastName);
    }

    /// <summary>
    /// Generates and returns avatar.
    /// </summary>
    /// <returns>Avatar blob and content type.</returns>
    public Avatar GetAvatar()
    {
      return this.implementation.GetAvatar();
    }

    /// <summary>
    /// Gets implementation for a given avatar generator type.
    /// </summary>
    /// <param name="type">Type of the generator.</param>
    /// <returns>Avatar generator instance.</returns>
    private AvatarGeneratorAbstract GetImplementation(AvatarGeneratorType type)
    {
      switch (type)
      {
        case AvatarGeneratorType.FirstAndLastName:
          return new LetterAvatarGenerator(this.firstName, this.lastName, this.options);
        default:
          throw new NotImplementedException();
      }
    }
  }
}
