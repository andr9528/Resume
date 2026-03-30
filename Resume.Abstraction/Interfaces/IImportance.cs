namespace Resume.Entities.Abstractions.Interfaces;

public interface IImportance : IComparable<IImportance>
{
    public int Importance { get; set; }

    int IComparable<IImportance>.CompareTo(IImportance? other)
    {
        return Importance.CompareTo(other.Importance);
    }
}
