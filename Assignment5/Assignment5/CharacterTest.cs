using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        private Character character;

        [SetUp]
        public void SetUp()
        {
            character = new Character("Jim", RaceCategory.Human, 100);
        }

        [Test]
        public void TakeDamage_ReducesHealthCorrectly()
        {
            int damage = 10;

            character.TakeDamage(damage);

            Assert.That(character.Health, Is.EqualTo(character.MaxHealth - damage));
        }

        [Test]
        public void TakeDamage_SetsIsAliveToFalse_WhenHealthIsZero()
        {
            character.Health = 10;
            int damage = 10;

            character.TakeDamage(damage);

            Assert.That(character.IsAlive, Is.False);
        }

        [Test]
        public void RestoreHealth_RestoresCorrectAmount()
        {
            character.Health = 10;
            int restoreAmount = 5;

            character.RestoreHealth(restoreAmount);

            Assert.That(character.Health, Is.EqualTo(15));
        }

        [Test]
        public void RestoreHealth_SetsIsAliveToTrue_WhenHealthIsAboveZero()
        {
            character.IsAlive = false;
            character.Health = 0;
            int restoreAmount = 5;

            character.RestoreHealth(restoreAmount);

            Assert.That(character.IsAlive, Is.True);
        }
    }
}
