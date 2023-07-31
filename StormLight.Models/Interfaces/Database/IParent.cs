namespace StormLight.Models.Interfaces.Database;

public interface IParent {

    public IParent? Parent { get; }
}

public interface IParent<T>
    : IParent
{
    public new T? Parent { get; }
}