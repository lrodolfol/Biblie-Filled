using Biblie_Filled.Models;

namespace Biblie_Filled.Builders;
internal class BookBuilders
{
    private Dictionary<string, int> Books = new Dictionary<string, int>
{
    { "Genesis", 50 },
    { "Exodo", 40 },
    { "Levitico", 27 },
    { "Numeros", 36 },
    { "Deuteronomio", 34 },
    { "Josue", 24 },
    { "Juizes", 21 },
    { "Rute", 4 },
    { "1_Samuel", 31 },
    { "2_Samuel", 24 },
    { "1_Reis", 22 },
    { "2_Reis", 25 },
    { "1_Cronicas", 29 },
    { "2_Cronicas", 36 },
    { "Esdras", 10 },
    { "Neemias", 13 },
    { "Ester", 10 },
    { "Jo", 42 },
    { "Salmos", 150 },
    { "Proverbios", 31 },
    { "Eclesiastes", 12 },
    { "Canticos", 8 },
    { "Isaias", 66 },
    { "Jeremias", 52 },
    { "Lamentacoes_de_Jeremias", 5 },
    { "Ezequiel", 48 },
    { "Daniel", 12 },
    { "Oseias", 14 },
    { "Joel", 3 },
    { "Amos", 9 },
    { "Obadias", 1 },
    { "Jonas", 4 },
    { "Miqueias", 7 },
    { "Naum", 3 },
    { "Habacuque", 3 },
    { "Sofonias", 3 },
    { "Ageu", 2 },
    { "Zacarias", 14 },
    { "Malaquias", 4 },
    { "Mateus", 28 },
    { "Marcos", 16 },
    { "Lucas", 24 },
    { "Joao", 21 },
    { "Atos", 28 },
    { "Romanos", 16 },
    { "1_Corintios", 16 },
    { "2_Corintios", 13 },
    { "Galatas", 6 },
    { "Efesios", 6 },
    { "Filipenses", 4 },
    { "Colossenses", 4 },
    { "1_Tessalonicenses", 5 },
    { "2_Tessalonicenses", 3 },
    { "1_Timoteo", 6 },
    { "2_Timoteo", 4 },
    { "Tito", 3 },
    { "Filemom", 1 },
    { "Hebreus", 13 },
    { "Tiago", 5 },
    { "1_Pedro", 5 },
    { "2_Pedro", 3 },
    { "1_Joao", 5 },
    { "2_Joao", 1 },
    { "3_Joao", 1 },
    { "Judas", 1 },
    { "Apocalipse", 22 }
};
    private static int NumberOfObjectsCreated;

    public BookBuilders()
    {
        if(Books.Count != 66)
            throw new Exception("The number of books is not 66.");
    }

    public Book? CreateNew()
    {
        if (NumberOfObjectsCreated == Books.Count)
            return null;

        var book = this.Books.ElementAt(NumberOfObjectsCreated);
        
        var newBook = new Book()
        {
            Name = book.Key,
            Chapters = new List<Chapter>(book.Value),
            Number = NumberOfObjectsCreated + 1
        };

        NumberOfObjectsCreated++;

        return newBook;
    }
}
