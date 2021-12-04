// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Performer performer;
        private Song song;
        private Stage stage;

        [SetUp]
        public void Initialize()
        {
            performer = new Performer("Doncho", "Donev", 29);
            song = new Song("Gossip", new TimeSpan(0, 3, 0));
            stage = new Stage();
        }

        [Test]
        public void Stage_Ctor_Initialises_Object_Successfully()
        {
            Assert.NotNull(stage);
        }

        [Test]
        public void Stage_Ctor_Initialises_Internal_Performers_Collection_Successfully()
        {
            Assert.NotNull(stage.Performers);
        }

        [Test]
        public void Stage_Ctor_Initialises_Internal_Performers_Collection_Successfully_With_Empty_Collection()
        {
            Assert.AreEqual(stage.Performers, new List<Performer>().AsReadOnly());
        }

        [Test]
        public void AddPerformer_Should_Throw_Exception_When_Provided_Null_Method_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void AddPerformer_Should_Throw_Exception_When_Provided_Performer_Is_Under_18_Years_Old()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("a", "b", 17)));
        }

        [Test]
        public void AddPerformer_Should_Add_Performer_Successfully_To_Internal_Collection()
        {
            stage.AddPerformer(performer);

            Assert.True(stage.Performers.Any(x => x.FullName == performer.FullName));
        }

        [Test]
        public void AddSong_Should_Throw_Exception_When_Provided_Null_Method_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

        [Test]
        public void AddSong_Should_Throw_Exception_When_Provided_A_Song_Shorter_Than_1_Minute()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("a", new TimeSpan(0, 0, 59))));
        }

        [Test]
        public void AddSong_Should_Successfully_Add_Song_To_Internal_Collection()
        {
            stage.AddPerformer(performer);

            Assert.DoesNotThrow(() => stage.AddSong(song));
            Assert.DoesNotThrow(() => stage.AddSongToPerformer(song.Name,performer.FullName));
        }

        [Test]
        public void AddSongToPerformer_Should_Throw_Exception_When_Provided_Null_SongName()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,"asd"));
        }

        [Test]
        public void AddSongToPerformer_Should_Throw_Exception_When_Provided_Null_Performer_FullName_And_Song_Null_Name()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("asd", null));
        }


        [Test]
        public void AddSongToPeformer_Should_Add_Song_To_Performer_Successfully()
        {
            stage.AddSong(song);
            stage.AddPerformer(performer);

            stage.AddSongToPerformer(song.Name,performer.FullName);

            Assert.True(stage
                .Performers
                .Where(x => x.SongList.Contains(song))
                .Contains(performer));
        }

        [Test]
        public void AddSongToPeformer_Should_Return_Correct_String()
        {
            stage.AddSong(song);
            stage.AddPerformer(performer);


            string expectedReturnString = $"{song} will be performed by {performer}";

            string actualReturnString = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual(expectedReturnString,actualReturnString);
        }

        [Test]

        public void Play_Should_Return_Correct_Performers_And_Songs_Count()
        {
            string expectedMessage = $"{stage.Performers.Count} performers played {stage.Performers.Sum(y => y.SongList.Count)} songs";

            string actualMessage = stage.Play();

            Assert.AreEqual(expectedMessage,actualMessage);
        }
    }
}