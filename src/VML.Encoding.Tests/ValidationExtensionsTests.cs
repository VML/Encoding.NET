// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidationExtensionsTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>01/24/2014 12:31 PM</created>
//  <updated>01/28/2014 6:00 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VML.Encoding.Model.Validation;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.Encoding.Tests
{
    public class ValidationExtensionsTests
    {
        #region Public Properties

        public static IEnumerable<object[]> InvalidTestingObjects
        {
            get
            {
                return new[]
                    {
                        new object[] { new TestingObject { Name = "HelloHelloHello" } }
                    };
            }
        }

        public static IEnumerable<object[]> ValidTestingObjects
        {
            get
            {
                return new[]
                    {
                        new object[] { new TestingObject { Name = "Hello" } },
                        new object[] { new TestingObject { Name = "Bob" } },
                        new object[] { new TestingObject { Name = "" } },
                        new object[] { new TestingObject { Name = "H" } },
                        new object[] { new TestingObject { Name = "1212oh" } }
                    };
            }
        }

        #endregion

        #region Public Methods

        [Theory]
        [PropertyData("InvalidTestingObjects")]
        public void IsValid_Invalid_ReturnsFalse(TestingObject obj)
        {
            Assert.False(obj.IsValid());
        }

        [Theory]
        [PropertyData("InvalidTestingObjects")]
        public void IsValid_Invalid_Throws(TestingObject obj)
        {
            Assert.Throws<ValidationException>(() => obj.Validate());
        }

        [Theory]
        [PropertyData("ValidTestingObjects")]
        public void IsValid_Valid_DoesNotThrow(TestingObject obj)
        {
            Assert.DoesNotThrow(obj.Validate);
        }

        [Theory]
        [PropertyData("ValidTestingObjects")]
        public void IsValid_Valid_ReturnsTrue(TestingObject obj)
        {
            Assert.True(obj.IsValid());
        }

        #endregion

        public class TestingObject
        {
            #region Public Properties

            [StringLengthValidator(10)]
            public string Name { get; set; }

            #endregion
        }
    }
}