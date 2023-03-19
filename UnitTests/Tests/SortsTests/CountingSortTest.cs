using Alghoritms.Classes;

namespace UnitTests.Tests.SortsTests;

[TestClass]
public class CountingSortTest
{
    [TestMethod]
    public void CorrectSortTest()
    {
        CollectionAssert.AreEqual(Sorts.CountingSort(
                new int[] { 9, 0, 1, 8, 7, 5 }),
            new int[] { 0, 1, 5, 7, 8, 9 });
    }
    
    [TestMethod]
    public void OneElementArrayTest()
    {
        CollectionAssert.AreEqual(Sorts.CountingSort(
                new int[]{9}),
            new int[]{9});
    }
    
    [TestMethod]
    public void IncorrectSortTest()
    {
        Assert.AreEqual(Sorts.CountingSort(
                new int[] { 9, 0, 1, 8, 7, 5, 82 }),
            null);
    }
}