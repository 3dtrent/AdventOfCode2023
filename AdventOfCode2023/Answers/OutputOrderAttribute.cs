namespace Answers;

[AttributeUsage(AttributeTargets.Class)]
internal class OutputOrderAttribute : Attribute
{
    public OutputOrderAttribute(double sortOrder)
    {
        SortOrder = sortOrder;
    }

    public double SortOrder { get; set; }
}
