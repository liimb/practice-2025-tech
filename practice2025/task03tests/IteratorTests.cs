using task03;

namespace task03tests;

public class IteratorTests
{
    [Fact]
    public void CustomCollection_GetEnumerator_ReturnsAllItems()
    {
        var collection = new CustomCollection<int> { 1, 2 };

        var result = collection.ToList();

        Assert.Equal([1, 2], result);
    }

    [Fact]
    public void GetReverseEnumerator_ReturnsItemsInReverseOrder()
    {
        var collection = new CustomCollection<int> { 1, 2 };

        var result = collection.GetReverseEnumerator().ToList();
        Assert.Equal([2, 1], result);
    }

    [Fact]
    public void GenerateSequence_ReturnsCorrectSequence()
    {
        var sequence = CustomCollection<int>.GenerateSequence(5, 3).ToList();
        Assert.Equal([5, 6, 7], sequence);
    }
    
    [Fact]
    public void FilterAndSort_ReturnsFilteredAndSortedItems()
    {
        var collection = new CustomCollection<int> { 3, 1, 2 };
    
        var result = collection.FilterAndSort(x => x > 1, x => x).ToList();
        Assert.Equal([2, 3], result);
    }
}
