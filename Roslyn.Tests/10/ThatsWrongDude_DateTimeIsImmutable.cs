public partial class RoslynLearn
{
    [Fact]
    public void _ThatsWrongDude_DateTimeIsImmutable()
    {
        var dateTime = System.DateTime.UtcNow;
        dateTime.AddDays(1);

    }
}
