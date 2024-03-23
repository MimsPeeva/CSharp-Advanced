namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int InvalidPeopleCount = 22;
        private const int maxPeopleCount = 16;
        private const string AddRangeExpectedEx = "Provided data length should be in range [0..16]!";
        private const string AddMethodCapacityExpectedEx = "Array's capacity must be exactly 16 integers!";
        private const string CheckUsernameExpectedEx = "There is already user with this username!";
        private const string CheckIdExpectedEx = "There is already user with this Id!";
        private const string nullUsernameEx = "Username parameter is null!";
        private const string doNotHavePersonWithSameUsernameEx = "No user is present by this username!";
       private const string notPositiveIdEx = "Id should be a positive number!";
        private const string noUserWithSameIdEx = "No user is present by this ID!";
        private const string ValidUsernameBobo = "m123sar";
        private const long ValidIdBobo = 754321;
        private const string ValidUsernameDidi = "dribf764";
        private const long ValidIdDidi = 5783099;
        private Database sut;
        [SetUp]
        public void SetUp()
        {
            Person Bobo = new Person(ValidIdBobo, ValidUsernameBobo);
            Person Didi = new Person(ValidIdDidi, ValidUsernameDidi);
            Person[] people = new Person[] { Bobo, Didi };
            sut = new Database(people);

        }
        [Test]
        public void Constructor_EmptyValidParameters_CreateNewInstance()
        {
            Database database = new();
            Assert.IsNotNull(database);
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void Constructor_ValidParameters_CreateNewInstance()
        {

            Assert.IsNotNull(sut);
            Assert.That(sut.Count, Is.EqualTo(2));
        }
        [Test]
        public void Constructor_TooManyPeople_ThrowEx()
        {
            Person[] tooManyPeople = new Person[InvalidPeopleCount];
            for (int i = 0; i < InvalidPeopleCount; i++)
            {
                tooManyPeople[i] = new Person(ValidIdBobo + i, $"{ValidIdBobo}-i");
            }
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Database(tooManyPeople));
            Assert.That(ex.Message, Is.EqualTo(AddRangeExpectedEx));
        }
        [Test]
        public void AddMethod_AddNewPerson()
        {
            Person Ema = new Person(4231, "ema432");
            sut.Add(Ema);
            Assert.That(sut.Count, Is.EqualTo(3));
        }
        [Test]
        public void AddMethod_FullDatabase_ThrowEx()
        {
            for (int i = sut.Count; i < maxPeopleCount; i++)
            {
                sut.Add(new Person(43641 + i, $"Wisi-{i}"));
            }
            Exception ex = Assert.Throws<InvalidOperationException>(() => sut.Add(new Person(065632, "vgreges4")));
            Assert.That(ex.Message, Is.EqualTo(AddMethodCapacityExpectedEx));
        }
        [Test]
        public void AddMethod_CheckIsThereIsPersonWithSameUsermame_ThrowEx()
        {

            Exception ex = Assert.Throws<InvalidOperationException>(() => sut.Add(new Person(065642, ValidUsernameDidi)));
            Assert.That(ex.Message, Is.EqualTo(CheckUsernameExpectedEx));
        }
        [Test]
        public void AddMethod_CheckIsThereIsPersonWithSameId_ThrowEx()
        {

            Exception ex = Assert.Throws<InvalidOperationException>(() => sut.Add(new Person(ValidIdBobo, "cdsfewf")));
            Assert.That(ex.Message, Is.EqualTo(CheckIdExpectedEx));
        }
        [Test]
        public void FindByUserName()
        {
            Person DidiFound = sut.FindByUsername(ValidUsernameDidi);
            Assert.IsNotNull(DidiFound);
            Assert.That(DidiFound.UserName,Is.EqualTo(ValidUsernameDidi));
            Assert.That(DidiFound.Id,Is.EqualTo(ValidIdDidi));
        }
        [Test]
        public void NullUserName_ThrowEx()
        {
         
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(()=>sut.FindByUsername(null));
        }

        [Test]
        public void NoUserWithSameUserName_ThrowEx()
        {
            Person DidiFound = sut.FindByUsername(ValidUsernameDidi);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.FindByUsername("aaa"));
            Assert.That(ex.Message, Is.EqualTo(doNotHavePersonWithSameUsernameEx));
        }
        [Test]
        public void FindById()
        {
            Person DidiFound = sut.FindById(ValidIdDidi);
            Assert.IsNotNull(DidiFound);
            Assert.That(DidiFound.UserName, Is.EqualTo(ValidUsernameDidi));
            Assert.That(DidiFound.Id, Is.EqualTo(ValidIdDidi));
        }
        [Test]
        public void NegativeId_ThrowEx()
        {

            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.FindById(-14));
        }
        [Test]
        public void NoUserWithSameId_ThrowEx()
        {
            Person DidiFound = sut.FindById(ValidIdDidi);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.FindById(100));
            Assert.That(ex.Message, Is.EqualTo(noUserWithSameIdEx));
        }
        [Test]
        public void RemovePersoncorrectly()
        {
            sut.Remove();
            Assert.That(sut.Count,Is.EqualTo(1));
        }
        [Test]
        public void RemovePersonFromNullCollection_ThrowRx()
        {
            sut.Remove();
            sut.Remove();
            Assert.Throws<InvalidOperationException>(()=>sut.Remove());
        }
    }
}