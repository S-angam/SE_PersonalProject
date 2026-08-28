/******************************************************************************
 * Filename    = IRegistrationRule.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Defines a rule for validating a registration.
 *****************************************************************************/

namespace RegistrationValidation
{
    /// <summary>
    /// Defines one independently extensible registration validation rule.
    /// </summary>
    public interface IRegistrationRule
    {
        /// <summary>
        /// Validates a registration against this rule.
        /// </summary>
        /// <param name="registration">The registration to validate.</param>
        string? Validate(Registration registration);
    }
}
