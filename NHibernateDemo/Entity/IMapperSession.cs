using System.Linq;
using System.Threading.Tasks;

namespace NHibernateDemo.Entity
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Book entity);
        Task Delete(Book entity);

        IQueryable<Book> Books { get; }
    }
}
