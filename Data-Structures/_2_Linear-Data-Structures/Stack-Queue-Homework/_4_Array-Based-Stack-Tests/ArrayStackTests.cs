using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArrayStackTests
{
    private ArrayBasedStack<int> stack;

    [TestInitialize]
    public void TestInitialize()
    {
        stack = new ArrayBasedStack<int>();
    }

    [TestMethod]
    public void Test_Push_ShouldIncreaseCount()
    {
        var element1 = 1;
        var element2 = 2;

        this.stack.Push(element1);
        this.stack.Push(element2);

        Assert.AreEqual(this.stack.Count, 2, "Push should increase count.");
        Assert.AreEqual(this.stack.Pop(), element2);
    }

    [TestMethod]
    public void Test_Push_ShouldResizeIfFull()
    {
        Assert.AreEqual(this.stack.Capacity, 16, "Initial capacity should be 16.");
        for (int i = 0; i < 17; i++)
        {
            this.stack.Push(1);
        }

        Assert.AreEqual(this.stack.Capacity, 32, "Should resize when full.");
    }

    [TestMethod]
    public void Test_Pop_ShouldDecreaseCount()
    {
        this.stack.Push(20);
        this.stack.Push(21);
        this.stack.Push(22);

        Assert.AreEqual(this.stack.Count, 3);

        this.stack.Pop();

        Assert.AreEqual(this.stack.Count, 2, "Pop should decrease count.");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_Pop_ShouldThrowExceptionIfEmpty()
    {
        this.stack.Pop();
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnArrayWithEqualElements()
    {
        this.stack.Push(20);
        this.stack.Push(21);
        this.stack.Push(22);

        var array = this.stack.ToArray();
        var expectedArray = new [] { 22, 21, 20 };

        CollectionAssert.AreEqual(expectedArray, array, "Should return array with the same elements.");
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnEmptyArrayIfempty()
    {
        Assert.AreEqual(this.stack.Count, 0);
        var array = this.stack.ToArray();

        CollectionAssert.AreEqual(array, new int[0], "Should return empty array if empty.");
    }
}