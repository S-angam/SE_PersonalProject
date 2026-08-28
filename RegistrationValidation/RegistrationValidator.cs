/******************************************************************************
 * Filename    = RegistrationValidator.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = RegistrationValidation
 *
 * Description = Applies configured validation rules to a registration.
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationValidation
{
    /// <summary>
    /// Validates registrations by applying a configurable collection of rules.
    /// </summary>
    public sealed class RegistrationValidator
    {
        private readonly IRegistrationRule[] _rules;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationValidator"/> class.
        /// </summary>
        /// <param name="rules">The rules to apply to each registration.</param>
        public RegistrationValidator(IEnumerable<IRegistrationRule> rules)
        {
            _rules = rules?.ToArray() ?? throw new ArgumentNullException(nameof(rules));
        }

        /// <summary>
        /// Applies every configured rule to a registration.
        /// </summary>
        /// <param name="registration">The registration to validate.</param>
        public IReadOnlyList<string> Validate(Registration registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException(nameof(registration));
            }

            List<string> errors = new List<string>();
            foreach (IRegistrationRule rule in _rules)
            {
                string? error = rule.Validate(registration);
                if (error != null)
                {
                    errors.Add(error);
                }
            }

            return errors;
        }
    }
}
