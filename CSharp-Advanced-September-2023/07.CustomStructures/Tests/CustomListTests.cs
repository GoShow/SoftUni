using System;
using System.Reflection;
using Xunit;

namespace CustomStructures.Tests;

public class CustomListTests
{
    private readonly int initialCapacity;

    public CustomListTests()
    {
        Type type = typeof(CustomList);
        FieldInfo fieldInfo = type.GetField("InitialCapacity", BindingFlags.NonPublic | BindingFlags.Static);
        initialCapacity = (int)fieldInfo.GetValue(new CustomList());
    }

    [Fact]
    public void Count_NewList_ShouldBeZero()
    {
        // Arrange
        var list = new CustomList();

        // Act
        int count = list.Count;

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public void Add_SingleItem_CountShouldIncreaseByOne()
    {
        // Arrange
        var list = new CustomList();

        // Act
        list.Add(42);

        // Assert
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Add_MultipleItems_CountShouldIncrease()
    {
        // Arrange
        var list = new CustomList();

        // Act
        list.Add(1);
        list.Add(2);
        list.Add(3);

        // Assert
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Add_GetItemAtIndex_ShouldReturnCorrectValue()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        int itemAtIndex1 = list[1];

        // Assert
        Assert.Equal(20, itemAtIndex1);
    }

    [Fact]
    public void Add_RemoveItem_CountShouldDecreaseByOne()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        int removedItem = list.RemoveAt(1);

        // Assert
        Assert.Equal(20, removedItem);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Add_InsertItem_ShouldShiftItems()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        list.InsertAt(1, 15);

        // Assert
        Assert.Equal(4, list.Count);
        Assert.Equal(10, list[0]);
        Assert.Equal(15, list[1]);
        Assert.Equal(20, list[2]);
        Assert.Equal(30, list[3]);
    }

    [Fact]
    public void Contains_ExistingItem_ShouldReturnTrue()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        bool contains = list.Contains(20);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Contains_NonExistingItem_ShouldReturnFalse()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        bool contains = list.Contains(40);

        // Assert
        Assert.False(contains);
    }

    [Fact]
    public void Swap_Items_ShouldBeSwapped()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Act
        list.Swap(0, 2);

        // Assert
        Assert.Equal(30, list[0]);
        Assert.Equal(10, list[2]);
    }

    [Fact]
    public void Resize_WhenAddingManyItems_ShouldResizeCorrectly()
    {
        // Arrange
        var list = new CustomList();
        int initialCapacity = this.initialCapacity;
        // Act
        for (int i = 0; i < initialCapacity * 2 + 1; i++)
        {
            list.Add(i);
        }

        // Assert
        Assert.Equal(initialCapacity * 2 + 1, list.Count);
        Assert.Equal(initialCapacity * 2 * 2, GetPrivateField(list, "items").Length);
    }

    [Fact]
    public void Shrink_WhenRemovingItems_ShouldShrinkCorrectly()
    {
        // Arrange
        var list = new CustomList();
        int initialCapacity = this.initialCapacity;

        // Add more items than the initial capacity
        for (int i = 0; i < initialCapacity * 4; i++)
        {
            list.Add(i);
        }

        // Act
        for (int i = 0; i < initialCapacity * 3; i++)
        {
            list.RemoveAt(0);
        }

        // Assert
        Assert.Equal(initialCapacity, list.Count);
        Assert.Equal(initialCapacity * 2, GetPrivateField(list, "items").Length);
    }

    [Fact]
    public void RemoveAt_IndexOutOfRange_ShouldThrowIndexOutOfRangeException()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(2));
    }

    [Fact]
    public void InsertAt_IndexOutOfRange_ShouldThrowIndexOutOfRangeException()
    {
        // Arrange
        var list = new CustomList();
        list.Add(10);
        list.Add(20);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(3, 30));
    }

    // Helper method to access private fields using reflection
    private int[] GetPrivateField(CustomList obj, string fieldName)
    {
        var fieldInfo = obj.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int[])fieldInfo.GetValue(obj);
    }
}