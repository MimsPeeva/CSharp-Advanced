namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const string name="Gosho";
        private const int damage = 20;
        private const int hp = 200;
        private const int minAttackHP = 30;
        private Warrior warrior;
        private Warrior opponent;
        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(name,damage,hp);
        }

        [Test]
        public void Constructor_HappyPath()
        {
            Assert.AreEqual(warrior.Name,name);
            Assert.AreEqual(warrior.Damage,damage); 
            Assert.AreEqual(warrior.HP,hp);
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void IncorrectName_ThrowsEx(string incorrectName)
        {
            ArgumentException ex =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior(incorrectName, 50, 300), "Name should not be empty or whitespace!");
        }
        [TestCase(-140)]
        [TestCase(0)]
        public void IncorrectDamage_ThrowsEx(int incorrectDamage)
        {
            ArgumentException ex =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior("Gosho", incorrectDamage, 300), "Damage value should be positive!");
        }
        [TestCase(-14)]
        [TestCase(-20)]
        public void IncorrectHP_ThrowsEx(int incorrectHP)
        {
            ArgumentException ex =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior("Gosho", 25, incorrectHP), "HP should not be negative!");
        }
        [Test]
        public void Attack_HappyPath()
        {
            Warrior warrior = new Warrior("Gosho", damage, hp);
            Warrior opponent = new Warrior("Pesho", 10, hp);
            warrior.Attack(opponent);

            Assert.AreEqual(hp - opponent.Damage, warrior.HP);
        }

        [TestCase(30)]
        [TestCase(20)]
        public void MinHPWhenAttackOpponent_ThrowsEx(int HP)
        {
            warrior = new Warrior("Gosho", 15, HP);
            Warrior opponent = new Warrior("Kiki", 12, 320);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(opponent), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(20)]
        public void MinOpponentHPWhenAttackWhenTryToAttack_ThrowsEx(int HP)
        {
            warrior = new Warrior("Gosho", 15, 200);
            Warrior opponent = new Warrior("Kiki", 12, HP);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(opponent), $"Enemy HP must be greater than {minAttackHP} in order to attack him!");
        }
        //[TestCase(20)]
        //[TestCase(3)]
        [Test]
        public void TryToAttackTooStronglyEnemy_ThrowsEx()
        {
            warrior = new Warrior("Gosho", 50, 200);
            Warrior opponent = new Warrior("Kiki", 40000000, 20);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(opponent), "You are trying to attack too strong enemy");
        }
        [TestCase(60)]
        [TestCase(100)]
        public void TryToAttackTooWeakEnemy_ThrowsEx(int damage)
        {
            warrior = new Warrior("Gosho", damage, 200);
            Warrior opponent = new Warrior("Kiki", 10, 50);
            warrior.Attack(opponent);
            Assert.AreEqual(0, opponent.HP);
        }

    }
}