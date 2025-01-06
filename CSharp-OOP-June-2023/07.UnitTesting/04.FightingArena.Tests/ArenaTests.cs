namespace Tests;

using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

public class ArenaTests
{
    private Arena arena;

    [SetUp]
    public void Setup()
    {
        arena = new Arena();
    }

    [Test]
    public void ArenaConstructorShouldWorkCorrectly()
    {
        Assert.IsNotNull(arena);
        Assert.IsNotNull(arena.Warriors);
    }

    [Test]
    public void ArenaCountShouldWorkCorrectly()
    {
        int expectedResult = 1;

        Warrior warrior = new("Gosho", 5, 100);

        arena.Enroll(warrior);

        Assert.IsNotEmpty(arena.Warriors);
        Assert.AreEqual(expectedResult, arena.Count);
    }

    [Test]
    public void ArenaEnrollShouldWorkCorrectly()
    {
        Warrior warrior = new("Gosho", 5, 100);

        arena.Enroll(warrior);

        Assert.IsNotEmpty(arena.Warriors);
        Assert.AreEqual(warrior, arena.Warriors.Single());
    }

    [Test]
    public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
    {
        Warrior warrior = new("Gosho", 5, 100);

        arena.Enroll(warrior);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
           => arena.Enroll(warrior));

        Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
    }


    [Test]
    public void ArenaFightShouldWorkCorrectly()
    {
        Warrior attacker = new("Gosho", 15, 100);
        Warrior defender = new("Pesho", 5, 50);

        arena.Enroll(attacker);
        arena.Enroll(defender);

        arena.Fight(attacker.Name, defender.Name);

        int expectedAttackerHp = 95;
        int expectedDefenderHp = 35;

        Assert.AreEqual(expectedAttackerHp, attacker.HP);
        Assert.AreEqual(expectedDefenderHp, defender.HP);
    }

    [Test]
    public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
    {
        Warrior attacker = new("Gosho", 15, 100);
        Warrior defender = new("Pesho", 5, 50);

        arena.Enroll(defender);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
           => arena.Fight(attacker.Name, defender.Name));

        Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
    }

    [Test]
    public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
    {
        Warrior attacker = new("Gosho", 15, 100);
        Warrior defender = new("Pesho", 5, 50);

        arena.Enroll(attacker);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
           => arena.Fight(attacker.Name, defender.Name));

        Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
    }
}

