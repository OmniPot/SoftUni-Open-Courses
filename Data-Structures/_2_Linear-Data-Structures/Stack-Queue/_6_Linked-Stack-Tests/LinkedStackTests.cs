using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class LinkedStackTests
{
    private LinkedStack<int> linkedStack;

    [TestInitialize]
    public void TestInitialize()
    {
        this.linkedStack = new LinkedStack<int>();
    }

    [TestMethod]
    public void Test_Push_ShouldIncreaseCount()
    {
        var element1 = 1;
        var element2 = 2;

        this.linkedStack.Push(element1);
        this.linkedStack.Push(element2);

        Assert.AreEqual(this.linkedStack.Count, 2, "Push should increase count.");
        Assert.AreEqual(this.linkedStack.Pop(), element2);
    }

    [TestMethod]
    public void Test_Pop_ShouldDecreaseCount()
    {
        this.linkedStack.Push(20);
        this.linkedStack.Push(21);
        this.linkedStack.Push(22);

        Assert.AreEqual(this.linkedStack.Count, 3);

        this.linkedStack.Pop();

        Assert.AreEqual(this.linkedStack.Count, 2, "Pop should decrease count.");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_Pop_ShouldThrowExceptionIfEmpty()
    {
        this.linkedStack.Pop();
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnArrayWithEqualElements()
    {
        this.linkedStack.Push(20);
        this.linkedStack.Push(21);
        this.linkedStack.Push(22);

        var array = this.linkedStack.ToArray();
        var expectedArray = new[] { 20, 21, 22 };

        CollectionAssert.AreEqual(expectedArray, array, "Should return array with the same elements.");
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnEmptyArrayIfempty()
    {
        Assert.AreEqual(this.linkedStack.Count, 0);
        var array = this.linkedStack.ToArray();

        CollectionAssert.AreEqual(array, new int[0], "Should return empty array if empty.");
    }
}

