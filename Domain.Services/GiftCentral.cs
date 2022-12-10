namespace Domain.Services;

public class GiftCentral
{
    private readonly IFamilyRepository _familyRepository;
    private readonly IGiftRepository _giftRepository;

    public GiftCentral(IFamilyRepository familyRepository, IGiftRepository giftRepository)
    {
        _familyRepository = familyRepository;
        _giftRepository = giftRepository;
    }

    public void AddGiftForChild(string familyName, string address, string childName, Gift gift)
    {
        // First get the family
        var family = _familyRepository.GetFamilyByNameAndAddress(familyName, address);

        if (family == null)
        {
            throw new FamilyException("Family not found");
        }

        var child = family.Children().SingleOrDefault(child => string.CompareOrdinal(child.Name, childName) == 0);
        
        if (child is null)
        {
            throw new FamilyException("Child not found");
        }
        
        // Check for budget
        if (family.Budget < family.Budget + gift.Price)
        {
            throw new GiftException("Gift is too expensive for the budget");
        }
        
        // Check for production option
        if (gift.ReadyAt > new DateTime(DateTime.Today.Year, 12, 25))
        {
            throw new GiftException("Gift cannot be produced by the Elves in time");
        }
        

        child.Gift = gift;
    }


}