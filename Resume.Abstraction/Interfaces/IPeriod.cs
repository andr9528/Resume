namespace Resume.Entities.Abstractions.Interfaces;

public interface IPeriod : IComparable<IPeriod>
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    int IComparable<IPeriod>.CompareTo(IPeriod? other)
    {
        return StartDate.CompareTo(other.StartDate);
    }
}
