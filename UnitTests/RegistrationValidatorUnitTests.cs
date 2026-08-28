/******************************************************************************
 * Filename    = RegistrationValidatorUnitTests.cs
 *
 * Author      = Sangam(112201006)
 *
 * Product     = SoftwareDesignPrinciples
 *
 * Project     = UnitTests
 *
 * Description = Unit tests for registration validation.
 *****************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrationValidation;

namespace UnitTests
{
    /// <summary>
    /// Tests the registration validator and its standard rules.
    /// </summary>
    [TestClass]
    public sealed class RegistrationValidatorUnitTests
    {
        /// <summary>
        /// Verifies that valid registration data produces no errors.
        /// </summary>
        [TestMethod]
        [Owner("Sangam")]
        [Priority(1)]
        public void ValidRegistrationReturnsNoErrors()
        {
            Registration registration = new Registration("Sangam Rao", 21, "112201006@smail.iitpkd.ac.in");

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            Assert.AreEqual(0, errors.Count);
        }

        /// <summary>
        /// Verifies that an invalid name produces the useful name error.
        /// </summary>
        [TestMethod]
        [Owner("Sangam")]
        [Priority(1)]
        public void InvalidNameReturnsNameError()
        {
            Registration registration = new Registration(" ", 21, "112201006@smail.iitpkd.ac.in");

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Name is required.", errors[0]);
        }

        /// <summary>
        /// Verifies that ages below zero and above one hundred are rejected.
        /// </summary>
        /// <param name="age">The invalid age under test.</param>
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(101)]
        [Owner("Sangam")]
        [Priority(1)]
        public void AgeOutsideAllowedRangeReturnsAgeError(int age)
        {
            Registration registration = new Registration(
                "Sangam Rao",
                age,
                "112201006@smail.iitpkd.ac.in");

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            CollectionAssert.AreEqual(
                new[] { "Age must be between 0 and 100." },
                errors.ToArray());
        }

        /// <summary>
        /// Verifies that the age range boundaries are accepted.
        /// </summary>
        /// <param name="age">The boundary age under test.</param>
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(100)]
        [Owner("Sangam")]
        [Priority(2)]
        public void AgeAtAllowedBoundaryReturnsNoErrors(int age)
        {
            Registration registration = new Registration(
                "Sangam Rao",
                age,
                "112201006@smail.iitpkd.ac.in");

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            Assert.AreEqual(0, errors.Count);
        }

        /// <summary>
        /// Verifies that an invalid email address produces the useful email error.
        /// </summary>
        [TestMethod]
        [Owner("Sangam")]
        [Priority(1)]
        public void InvalidEmailReturnsEmailError()
        {
            Registration registration = new Registration("Sangam Rao", 21, "not-an-email");

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            CollectionAssert.AreEqual(
                new[] { "A valid email address is required." },
                errors.ToArray());
        }

        /// <summary>
        /// Verifies that the validator collects every error in rule order.
        /// </summary>
        [TestMethod]
        [Owner("Sangam")]
        [Priority(1)]
        public void InvalidRegistrationReturnsAllErrorsInOrder()
        {
            Registration registration = new Registration(null, -1, null);
            string[] expectedErrors =
            {
                "Name is required.",
                "Age must be between 0 and 100.",
                "A valid email address is required.",
            };

            IReadOnlyList<string> errors = CreateValidator().Validate(registration);

            CollectionAssert.AreEqual(expectedErrors, errors.ToArray());
        }

        /// <summary>
        /// Verifies that a new rule extends validation without changing the validator.
        /// </summary>
        [TestMethod]
        [Owner("Sangam")]
        [Priority(1)]
        public void NewRuleExtendsValidatorWithoutModification()
        {
            IRegistrationRule[] rules =
            {
                new AgeValidationRule(),
                new MinimumEventAgeRule(),
            };
            RegistrationValidator validator = new RegistrationValidator(rules);

            IReadOnlyList<string> errors = validator.Validate(
                new Registration("Sangam Rao", 17, "112201006@smail.iitpkd.ac.in"));

            CollectionAssert.AreEqual(
                new[] { "Attendee must be at least 18 years old." },
                errors.ToArray());
        }

        private static RegistrationValidator CreateValidator()
        {
            IRegistrationRule[] rules =
            {
                new NameValidationRule(),
                new AgeValidationRule(),
                new EmailValidationRule(),
            };

            return new RegistrationValidator(rules);
        }

        private sealed class MinimumEventAgeRule : IRegistrationRule
        {
            /// <summary>
            /// Requires an attendee to be at least eighteen years old.
            /// </summary>
            public string? Validate(Registration registration)
            {
                return registration.Age >= 18
                    ? null
                    : "Attendee must be at least 18 years old.";
            }
        }
    }
}
