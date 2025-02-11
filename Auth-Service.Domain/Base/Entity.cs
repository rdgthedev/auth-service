namespace Auth_Service.Domain.Base;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    protected Entity()
    {
        CreatedAt = DateTime.Now;
    }
}