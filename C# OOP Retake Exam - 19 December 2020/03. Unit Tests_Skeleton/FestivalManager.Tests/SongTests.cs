// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SongTests
    {
        private Song song;

        [SetUp]
        public void Initialize()
        {
            song = new Song("Gossip", new TimeSpan(0, 3, 0));
        }

        [Test]
        public void Song_Ctor_Initialises_Object_Successfully()
        {
            Assert.NotNull(song);
        }

        [Test]
        public void Song_Duration_Property_Returns_Correct_Song_Duration()
        {
            Assert.AreEqual(song.Name,"Gossip");
        }

        [Test]
        public void Song_Name_Property_Returns_Correct_Song_Name()
        {
            Assert.AreEqual(song.Duration, new TimeSpan(0, 3, 0));
        }

        [Test]
        public void Song_ToString_Method_Should_Return_Song_Data_In_Correct_Format()
        {
            string expectedReturn = $"{song.Name} ({song.Duration:mm\\:ss})";
            string actualReturn = song.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}