/******************************************************************************
 * Filename    = NameValidationRule.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Validates that a registration has a name.
 *****************************************************************************/

namespace RegistrationValidation
{
    /// <summary>
    /// Requires a registration to contain a name.
    /// </summary>
    public sealed class NameValidationRule : IRegistrationRule
    {
        /// <summary>
        /// Validates that a registration has a name.
        /// </summary>
        public string? Validate(Registration registration)
        {
            return string.IsNullOrWhiteSpace(registration.Name)
                ? "Name is required."
                : null;
        }
    }
}
