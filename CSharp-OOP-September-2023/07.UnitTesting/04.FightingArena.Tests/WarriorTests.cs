namespace Tests;

using FightingArena;
using NUnit.Framework;
using System;

[TestFixture]
public class WarriorTests
{
    [Test]
    public void WarriorConstructorShouldWorkCorrectly()
    {
        string expectedName = "Pesho";
        int expectedDamage = 15;
        int expectedHP = 100;

        Warrior warrior = new(expectedName, expectedDamage, expectedHP);

        Assert.AreEqual(expectedName, warrior.Name);
        Assert.AreEqual(expectedDamage, warrior.Damage);
        Assert.AreEqual(expectedHP, warrior.HP);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("     ")]
    public void WarriorConstructorShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Warrior(name, 25, 50));

        Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-20)]
    public void WarriorConstructorShouldThrowExceptionIfDamageIsNotPositive(int damage)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Warrior("Pesho", damage, 50));

        Assert.AreEqual("Damage value should be positive!", exception.Message);
    }

    [TestCase(-1)]
    [TestCase(-20)]
    public void WarriorConstructorShouldThrowExceptionIfHPIsNegative(int hp)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Warrior("Pesho", 25, hp));

        Assert.AreEqual("HP should not be negative!", exception.Message);
    }

    [Test]
    public void AttackMethodShouldWorkCorrectly()
    {
        int expectedAtackerHp = 95;
        int expectedDefenderHp = 80;

        Warrior attacker = new("Pesho", 10, 100);
        Warrior defender = new("Gosho", 5, 90);

        attacker.Attack(defender);

        Assert.AreEqual(expectedAtackerHp, attacker.HP);
        Assert.AreEqual(expectedDefenderHp, defender.HP);
    }

    [TestCase(30)]
    [TestCase(29)]
    [TestCase(10)]
    public void WarriorShouldNotAttackIfHisHPIsEqualOrLessThan30(int hp)
    {
        Warrior attacker = new("Pesho", 10, hp);
        Warrior defender = new("Gosho", 5, 90);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => attacker.Attack(defender));

        Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
    }

    [TestCase(30)]
    [TestCase(29)]
    [TestCase(10)]
    public void WarriorShouldNotAttackEnemyWith30HpOrLess(int hp)
    {
        Warrior attacker = new("Pesho", 10, 90);
        Warrior defender = new("Gosho", 5, hp);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => attacker.Attack(defender));

        Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
    }

    [Test]
    public void WarriorShouldNotAttackEnemyWithBiggerDamageThanHisHealth()
    {
        Warrior attacker = new("Pesho", 10, 35);
        Warrior defender = new("Gosho", 45, 100);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => attacker.Attack(defender));

        Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
    }

    [Test]
    public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
    {
        Warrior attacker = new("Pesho", 50, 100);
        Warrior defender = new("Gosho", 45, 40);

        int expectedAttackerHp = 55;
        int expectedDefenderHp = 0;

        attacker.Attack(defender);

        Assert.AreEqual(expectedAttackerHp, attacker.HP);
        Assert.AreEqual(expectedDefenderHp, defender.HP);
    }
}