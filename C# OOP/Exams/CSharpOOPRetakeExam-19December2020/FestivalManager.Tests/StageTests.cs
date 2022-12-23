// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
        }

        [Test]
        public void AddPerformerShouldAddPerformer()
        {
            Performer performer = new Performer("Dimitar", "Dimitrov", 38);

            stage.AddPerformer(performer);

            CollectionAssert.Contains(stage.Performers, performer);
        }

        [Test]
        [TestCase(null)]
        public void CheckForNull(string name)
        {
            Performer nullPerformer = null;
            Song nullSong = null;

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(nullPerformer));
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(nullSong));
        }

        [Test]
        public void PerformerAgeIsUnder18ThrowAnException()
        {
            var performer = new Performer("Dimitar", "Dimitrov", 17);

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void AddSongShouldAddSong()
        {
            Song song = new Song("Song", new TimeSpan(0, 1, 55));
            Performer performer = new Performer("Dimitar", "Dimitrov", 38);

            stage.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.That(stage.Play(), Is.EqualTo($"{stage.Performers.Count} performers played {1} songs"));
        }

        [Test]
        public void SongDurationIfLessThan1MinutesThrowAnException()
        {
            Song song = new Song("Song", new TimeSpan(0, 0, 55));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformerShouldWorkCorrectly()
        {
            Song song = new Song("Song", new TimeSpan(0, 1, 55));
            Performer performer = new Performer("Dimitar", "Dimitrov", 38);

            stage.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.That(stage.AddSongToPerformer(song.Name, performer.FullName), Is.EqualTo($"{song} will be performed by {performer}"));
        }

        [Test]
        public void GetPerformerThrowAnExceptionIfIsNull()
        {
            Song song = new Song("Song", new TimeSpan(0, 1, 55));

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "NoExist"));
        }

        [Test]
        public void SongGetPerformerThrowAnExceptionIfIsNull()
        {
            Performer performer = new Performer("Dimitar", "Dimitrov", 20);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("NoExist", performer.FullName));
        }
    }
}