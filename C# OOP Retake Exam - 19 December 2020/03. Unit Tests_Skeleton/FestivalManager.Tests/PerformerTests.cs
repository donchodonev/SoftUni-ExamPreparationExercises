// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PerformerTests
    {
        private Performer performer;

        [SetUp]
        public void Initialize()
        {
            performer = new Performer("d", "d", 29);
        }

        [Test]
        public void Performer_Ctor_Initialises_Object_Successfully()
        {
            Assert.NotNull(performer);
        }

        [Test]
        public void Performer_FullName_Property_Returns_FirstAndLastName_Concatenated()
        {
            string expectedFullName = "d d";
            string actualFullName = performer.FullName;
            Assert.AreEqual(expectedFullName, actualFullName);
        }

        [Test]
        public void Performer_Age_Property_Should_Return_Age_Given_From_Constructor()
        {
            int expectedAge = 29;
            int actualAge = performer.Age;
            Assert.AreEqual(expectedAge, actualAge);
        }

        [Test]
        public void Performer_SongList_Should_Return_Empty_List_Of_Songs()
        {
            Assert.AreEqual(performer.SongList,new List<Song>().AsReadOnly());
        }

        [Test]
        public void Performer_ToString_Should_Return_Performer_FullName()
        {
            Assert.AreEqual(performer.FullName, performer.ToString());
        }
    }
}