using System.Threading.Tasks;
using TheBestCloth.DAL.Data;

namespace TheBestCloth.DAL.Extensions
{
    public static class PostgresContextExtensions
    {
        public async static Task<bool> SaveChangesAndCheckSuccessAsync(this PostgresContext context)
        {
            return (await context.SaveChangesAsync() > 0)? true : false;
        }
    }
}
