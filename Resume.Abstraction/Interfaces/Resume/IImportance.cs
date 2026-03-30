namespace Resume.Abstraction.Interfaces.Resume;

public interface IImportance : IComparable<IImportance>
{
    public int Importance { get; set; }

    int IComparable<IImportance>.CompareTo(IImportance? other)
    {
        return Importance.CompareTo(other.Importance);
    }
}
