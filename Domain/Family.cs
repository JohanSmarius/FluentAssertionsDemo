namespace Domain;

public class Family
{
    private readonly List<Child> _children = new();
    public decimal Budget { get; private set; }

    public string Name { get; set; }
    public string Address { get; set; }

    public Family(decimal budget, string name, string address)
    {
        Budget = budget;
        Name = name;
        Address = address;
    }

    public void AddChild(Child child)
    {
        _children.Add(child);
    }

    public IEnumerable<Child> Children()
    {
        foreach (var child in _children)
        {
            // Use yield on purpose to show the support for yield.
            yield return child;
        }
    }

    public void AddGiftForChild(Child child, Gift gift)
    {
        var childInList =
            _children.SingleOrDefault(childToFind => string.CompareOrdinal(child.Name, childToFind.Name) == 0);

        if (childInList is null)
        {
            throw new ArgumentException("Child not found");
        }

        var currentExpenses = _children.Sum(childToFind => childToFind.Gift?.Price ?? 0);

        if (currentExpenses + gift.Price > Budget)
        {
            throw new GiftException("Gift is too expensive");
        }
        
        if (gift.ReadyAt > new DateTime(DateTime.Today.Year, 12, 25))
        {
            throw new GiftException("Gift cannot be produced by the Elves in time");
        }

        // Yeah I can give this child the gift
        childInList.Gift = gift;
    }

    public decimal AverageGiftAmount => _children.Average(child => child.Gift?.Price ?? 0); 
}