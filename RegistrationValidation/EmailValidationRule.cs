/******************************************************************************
 * Filename    = EmailValidationRule.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Validates a registration email address.
 *****************************************************************************/

using System.Net.Mail;

namespace RegistrationValidation
{
    /// <summary>
    /// Requires a registration to contain a valid email address.
    /// </summary>
    public sealed class EmailValidationRule : IRegistrationRule
    {
        /// <summary>
        /// Requires a registration to contain a valid email address.
        /// </summary>
        public string? Validate(Registration registration)
        {
            bool isValid = MailAddress.TryCreate(registration.Email, out MailAddress? emailAddress)
                && emailAddress.Address == registration.Email;

            return isValid ? null : "A valid email address is required.";
        }
    }
}
