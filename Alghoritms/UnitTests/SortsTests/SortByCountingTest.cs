using Alghoritms.Classes;

namespace UnitTests.SortsTests;

[TestClass]
public class SortByCountingTest
{
    [TestMethod]
    public void CorrectSortTest()
    {
        CollectionAssert.AreEqual(Sorts.SortByCounting(
                new int[] { 9, 0, 1, 8, 7, 5 }),
            new int[] { 0, 1, 5, 7, 8, 9 });
    }
    
    [TestMethod]
    public void IncorrectSortTest()
    {
        Assert.AreEqual(Sorts.SortByCounting(
                new int[] { 9, 0, 1, 8, 7, 5, 82 }),
            null);
    }
}