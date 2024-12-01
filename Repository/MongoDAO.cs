using Biblie_Filled.Models;
using MongoDB.Driver;

namespace Biblie_Filled.Repository;
internal class MongoDAO
{
    private string ConnectionString = "mongodb://mongoadmin:passMongoDb123@localhost:27017/";
    private string SchemaName = "biblia";
    
    private MongoClient Client;
    private IMongoDatabase DataBase;
    private IMongoCollection<Book> Collection;

    public MongoDAO()
    {
        Client = new MongoClient(ConnectionString);
        DataBase = Client.GetDatabase(SchemaName);
    }

    public async Task Insert(Book book)
    {
        Collection = DataBase.GetCollection<Book>("books");
        await Collection.InsertOneAsync(book);
    }
}
