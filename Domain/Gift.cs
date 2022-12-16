namespace Domain;

public class Gift
{
    public string? Name { get; set; }

    public decimal Price { get; set; }
    public int ProductionDuration { get; private set; }

    public Gift(int productionDuration)
    {
        ProductionDuration = productionDuration;
    }

    public DateTime ReadyAt => DateTime.Today.AddDays(ProductionDuration);
}

