namespace Biblie_Filled.Models;
internal class Chapter
{
    public int Number { get; set; }
    public LinkedList<Verse> Verses { get; set; } = [];
}
