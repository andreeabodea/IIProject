using System.Threading.Tasks;

namespace AirlinesApp.Db
{
    interface IDBSeeder
    {
        Task EnsureInitialData();
    }
}
