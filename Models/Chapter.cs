namespace Biblie_Filled.Models;
internal class Chapter
{
    public int Number { get; set; }
    public IEnumerable<Verse> Verses { get; set; } = [];
}
