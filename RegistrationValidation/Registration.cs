/******************************************************************************
 * Filename    = Registration.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Stores the information supplied for a user registration.
 *****************************************************************************/

namespace RegistrationValidation
{
    /// <summary>
    /// Represents the information supplied to register a user.
    /// </summary>
    public sealed class Registration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Registration"/> class.
        /// </summary>
        /// <param name="name">The user's name.</param>
        /// <param name="age">The user's age.</param>
        /// <param name="email">The user's email address.</param>
        public Registration(string? name, int age, string? email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the user's age.
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// Gets the user's email address.
        /// </summary>
        public string? Email { get; }
    }
}
