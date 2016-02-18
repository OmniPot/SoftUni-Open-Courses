using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedQueueTests
{
    private LinkedQueue<int> linkedQueue;

    [TestInitialize]
    public void TestInitialize()
    {
        this.linkedQueue = new LinkedQueue<int>();
    }

    [TestMethod]
    public void Test_Enqueue_ShouldIncreaseCount()
    {
        var element1 = 1;
        var element2 = 2;

        this.linkedQueue.Enqueue(element1);
        this.linkedQueue.Enqueue(element2);

        Assert.AreEqual(this.linkedQueue.Count, 2, "Enqueue should increase count.");
        Assert.AreEqual(this.linkedQueue.Dequeue(), element1, "Dequeue should return the first element.");
    }

    [TestMethod]
    public void Test_Dequeue_ShouldDecreaseCount()
    {
        this.linkedQueue.Enqueue(20);
        this.linkedQueue.Enqueue(21);
        this.linkedQueue.Enqueue(22);

        Assert.AreEqual(this.linkedQueue.Count, 3);

        this.linkedQueue.Dequeue();

        Assert.AreEqual(this.linkedQueue.Count, 2, "Pop should decrease count.");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_Dequeue_ShouldThrowExceptionIfEmpty()
    {
        this.linkedQueue.Dequeue();
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnArrayWithEqualElements()
    {
        this.linkedQueue.Enqueue(20);
        this.linkedQueue.Enqueue(21);
        this.linkedQueue.Enqueue(22);
        this.linkedQueue.Enqueue(23);

        var array = this.linkedQueue.ToArray();
        var expectedArray = new[] { 20, 21, 22, 23 };

        CollectionAssert.AreEqual(expectedArray, array, "Should return array with the same elements.");
    }

    [TestMethod]
    public void Test_ToArray_ShouldReturnEmptyArrayIfempty()
    {
        Assert.AreEqual(this.linkedQueue.Count, 0);
        var array = this.linkedQueue.ToArray();

        CollectionAssert.AreEqual(array, new int[0], "Should return empty array if empty.");
    }
}

