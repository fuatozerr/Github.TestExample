namespace JobAppLibrary.Services
{
    public interface IIdentityValidator
    {
        bool IsValid(string identityNumber);
    }
}