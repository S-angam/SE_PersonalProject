/******************************************************************************
 * Filename    = AgeValidationRule.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Validates that a registration age is within the allowed range.
 *****************************************************************************/

namespace RegistrationValidation
{
    /// <summary>
    /// Requires a registration age to be between zero and one hundred.
    /// </summary>
    public sealed class AgeValidationRule : IRegistrationRule
    {
        /// <summary>
        /// Validates that a registration age is within the allowed range.
        /// </summary>
        public string? Validate(Registration registration)
        {
            return registration.Age < 0 || registration.Age > 100
                ? "Age must be between 0 and 100."
                : null;
        }
    }
}
