namespace Domain;

public class Child
{
    public string? Name { get; set; }

    public int Age { get; set; }
    
    public Gift? Gift { get; set; }

    public Gender Gender { get; set; }
    
    public bool HasGift() => Gift is not null;

    public override string ToString()
    {
        return $"{Name?.ToUpper()} - {Age}";
    }
}