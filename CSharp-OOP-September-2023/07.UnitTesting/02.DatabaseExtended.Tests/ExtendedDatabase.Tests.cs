namespace DatabaseExtended.Tests;

using ExtendedDatabase;
using NUnit.Framework;
using System;

[TestFixture]
public class ExtendedDatabaseTests
{
    private Database database;

    [SetUp]
    public void Setup()
    {
        Person[] persons =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

        database = new Database(persons);
    }

    [Test]
    public void CreatingDatabaseCountShouldBeCorrect()
    {
        int expectedResult = 11;
        Assert.AreEqual(expectedResult, database.Count);
    }

    [Test]
    public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16()
    {

        Person[] persons =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko"),
            new Person(12, "Moshko"),
            new Person(13, "Foshko"),
            new Person(14, "Loshko"),
            new Person(15, "Roshko"),
            new Person(16, "Boshko"),
            new Person(17, "Kokoshko")
        };

        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => database = new Database(persons));

        Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
    }

    [Test]
    public void DatabaseCountShouldWorkCorrectly()
    {
        int expectedResult = 11;
        int actualResult = database.Count;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseAddMethodShouldIncreaseCount()
    {
        var person = new Person(12, "Paul");

        database.Add(person);

        int expectedResult = 12;
        int actualResult = database.Count;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseAddMethodShouldWorkCorrectly()
    {
        var person = new Person(12, "Paul");

        database.Add(person);

        int expectedResult = 12;
        int actualResult = database.Count;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseAddMethodShouldThrowExceptionIfCountIsMoreThan16()
    {
        Person person1 = new(12, "John");
        Person person2 = new(13, "Paul");
        Person person3 = new(14, "Green");
        Person person4 = new(15, "Brown");
        Person person5 = new(16, "Killer");

        database.Add(person1);
        database.Add(person2);
        database.Add(person3);
        database.Add(person4);
        database.Add(person5);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(new Person(17, "Destroyer")));

        Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
    }

    [Test]
    public void DatabaseShouldThrowExceptionIfPersonWithSameUsernameIsAdded()
    {
        Person person = new(12, "Pesho");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(person), "There is already user with this username!");

        Assert.AreEqual("There is already user with this username!", exception.Message);
    }

    [Test]
    public void DatabaseShouldThrowExceptionIfPersonWithSameIdIsAdded()
    {
        Person person = new(1, "John");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(person));

        Assert.AreEqual("There is already user with this Id!", exception.Message);
    }

    [Test]
    public void DatabaseRemoveMethodShouldWorkCorrectly()
    {
        int expectedResult = 10;

        database.Remove();

        Assert.AreEqual(expectedResult, database.Count);
    }

    [Test]
    public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
    {
        Database database = new();

        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    public void DatabaseFindByUsernameMethodShouldWorkCorrectly()
    {
        string expectedResult = "Pesho";
        string actualResult = database.FindByUsername("Pesho").UserName;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseFindByUsernameMethodShouldBeCaseSensitive()
    {
        string expectedResult = "peShO";
        string actualResult = database.FindByUsername("Pesho").UserName;

        Assert.AreNotEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameIsNull(string username)
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("Username parameter is null!", exception.ParamName);
    }

    [Test]
    [TestCase("Kiro")]
    [TestCase("Paul")]
    public void DatabaseFindByUsernameMethodShouldThrowExceptionIfUsernameIsNotFound(string username)
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("No user is present by this username!", exception.Message);
    }

    [Test]
    public void DatabaseFindByIdMethodShouldWorkCorrectly()
    {
        string expectedResult = "Gosho";
        string actualResult = database.FindById(2).UserName;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNegative()
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => database.FindById(-1));

        Assert.AreEqual("Id should be a positive number!", exception.ParamName);
    }

    [Test]
    public void DatabaseFindByIdMethodShouldThrowExceptionIfIdIsNotFound()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindById(25));

        Assert.AreEqual("No user is present by this ID!", exception.Message);
    }
}