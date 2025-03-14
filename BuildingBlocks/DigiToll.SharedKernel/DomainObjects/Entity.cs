namespace DigiToll.SharedKernel.DomainObjects;

public class Entity
{
    public string Id { get; protected set; } = NewGuild.GenerateId();
}

public static class NewGuild 
{
    public static string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}