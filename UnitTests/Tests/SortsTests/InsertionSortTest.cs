using Alghoritms.Classes;

namespace UnitTests.Tests.SortsTests;

[TestClass]
public class InsertionSortTest
{
    [TestMethod]
    public void CorrectSortTest()
    {
        CollectionAssert.AreEqual(Sorts.InsertionSort(
                new int[] { 9, 0, 1, 8, 7, 5 }),
            new int[] { 0, 1, 5, 7, 8, 9 });
    }

    [TestMethod]
    public void OneElementArrayTest()
    {
        CollectionAssert.AreEqual(Sorts.InsertionSort(
                new int[] { 9 }),
            new int[] { 9 });
    }

    [TestMethod]
    public void OnlyOneNumberRepeatsTest()
    {
        CollectionAssert.AreEqual(Sorts.InsertionSort(
                new int[] { 9, 9, 9, 9, 9, 9, 9 }),
            new int[] { 9, 9, 9, 9, 9, 9, 9 });
    }

    [TestMethod]
    public void EvenNumberOfElementsArrayTest()
    {
        CollectionAssert.AreEqual(Sorts.InsertionSort(
                new int[] { 1, 3, 1, 2, 3, 9, 0, 23}),
            new int[] { 0, 1, 1, 2, 3, 3, 9, 23});
    } 
    
    [TestMethod]
    public void OddNumberOfElementsArrayTest()
    {
        CollectionAssert.AreEqual(Sorts.InsertionSort(
                new int[] { 1, 3, 1, 2, 9, 0, 23}),
            new int[] { 0, 1, 1, 2, 3, 9, 23});
    } 
}