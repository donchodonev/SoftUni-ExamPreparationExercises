namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {

        private Bag bag;
        private Present present;

        [SetUp]
        public void Initialize()
        {
            string presentName = "me";
            double magic = 100;

            present = new Present(presentName, magic);

            bag = new Bag();
        }

        [Test]
        public void Ctor_Initializes_Object_Successfully()
        {
            Assert.NotNull(new Bag());
        }

        [Test]
        public void Ctor_Initializes_Internal_Collection_Successfully()
        {
            Assert.NotNull(bag.GetPresents());
        }

        [Test]
        public void Create_Throws_Exception_When_Method_Parameter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null), "Present is null");
        }

        [Test]
        public void Create_Throws_Exception_When_Present_Already_Exists()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present), "This present already exists!");
        }

        [Test]
        public void Create_Adds_Present_To_Internal_Collection_Correctly()
        {
            bag.Create(present);
            Assert.AreEqual(bag.GetPresent(present.Name), present);
        }

        [Test]
        public void Create_Returns_Correct_String_When_Present_Gets_Successfully_added()
        {
            Assert.AreEqual(bag.Create(present), $"Successfully added present {present.Name}.");
        }

        [Test]
        public void Remove_Should_Remove_Present_From_Internal_Collection()
        {
            bag.Create(present);

            int presentsCountBeforeRemoval = bag.GetPresents().Count;

            bag.Remove(present);

            int presentsCountAfterRemoval = bag.GetPresents().Count;

            Assert.AreNotEqual(presentsCountBeforeRemoval, presentsCountAfterRemoval);
        }

        [Test]
        public void GetPresentWithLeastMagic_Should_Return_Accordingly()
        {
            bag.Create(present);

            var expectedPresent = new Present("somename", 50);

            bag.Create(expectedPresent);

            var actualPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void GetPresent_Should_Return_Accordingly()
        {
            bag.Create(present);

            var expectedPresent = present;

            var actualPresent = bag.GetPresent(present.Name);

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void GetPresents_Should_Return_AllPresents()
        {
            var otherPresent = new Present("somePresent", 200);

            bag.Create(present);
            bag.Create(otherPresent);

            var presentList = new List<Present>() { present, otherPresent };

            Assert.AreEqual(presentList.AsReadOnly(), bag.GetPresents());
        }
    }
}
