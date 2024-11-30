namespace Biblie_Filled.Models;
internal class Book
{
    public string Name { get; set; } = null!;
    public int Number { get; set; }
    public List<Chapter> Chapters { get; set; } = null!;
}
