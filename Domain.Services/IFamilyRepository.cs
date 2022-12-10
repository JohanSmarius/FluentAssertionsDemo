namespace Domain.Services;

public interface IFamilyRepository
{
    Family GetFamilyByNameAndAddress(string name, string address);
}