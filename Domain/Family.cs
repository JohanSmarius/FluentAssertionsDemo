namespace Domain;

public class Family
{
    private List<Child> _children = new();
    public decimal Budget { get; private set; }

    public string Name { get; set; }
    public string Address { get; set; }

    public Family(decimal budget)
    {
        Budget = budget;
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
}