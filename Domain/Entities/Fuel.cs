using Core.Persistence.Repository;

namespace Domain.Entities;

public class Fuel : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; }
    public Fuel()
    {
        Models = new HashSet<Model>();
    }

    public Fuel(string name,Guid id)
    {
        Id = id;
        Name = name;
    }
}
