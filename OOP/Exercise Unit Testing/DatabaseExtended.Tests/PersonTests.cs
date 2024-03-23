using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private const string ValidUsername = "m123sar";
        private const long ValidId = 754321;
        [Test]
        public void Constructor_ValidParameters_CreateNewInstance()
        {
            Person person = new Person(ValidId,ValidUsername);
            Assert.IsNotNull(person);
            Assert.That(person.Id,Is.EqualTo(ValidId));
            Assert.That(person.UserName, Is.EqualTo(ValidUsername));

        }
    }
}
