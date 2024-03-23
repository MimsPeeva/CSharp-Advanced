using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Constrictor_HappyPath()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Count_HappyPath()
        {
            Warrior warrior1 = new Warrior("Pesho", 15, 200);
            Warrior warrior2 = new Warrior("Gosho", 20, 300);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Count, 2);
        }

        [Test]
        public void Enroll_HappyPath()
        {
            Warrior warrior = new Warrior("Ana", 12, 145);
            arena.Enroll(warrior);
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void Enroll_ThrowsEx()
        {
            Warrior warrior = new Warrior("Ana", 12, 145);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_HappyPath()
        {
            Warrior attacker = new Warrior("Pesho", 15, 200);
            Warrior defender = new Warrior("Gosho", 20, 300);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name,defender.Name);
            Assert.AreEqual(attacker.HP,180);
            Assert.AreEqual(defender.HP,285);
        }

        [Test]
        public void Attack_NullAttacker()
        {
            Warrior defender = new Warrior("Gosho", 20, 300);
            arena.Enroll(defender);
           Exception ex = Assert.Throws<InvalidOperationException>(()=> arena.Fight("Pesho","Gosho")) ;
          Assert.AreEqual(ex.Message, "There is no fighter with name Pesho enrolled for the fights!");
        }
        [Test]
        public void Attack_NullDefender()
        {
            Warrior attacker = new Warrior("Pesho", 15, 234);
            arena.Enroll(attacker);
           Exception ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Gosho"));
            Assert.AreEqual(ex.Message, "There is no fighter with name Gosho enrolled for the fights!");
        }
    }
}
