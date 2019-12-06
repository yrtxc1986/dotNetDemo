using FluentNHibernate.Mapping;
using FluentNHibernateDemo.Entity;

namespace FluentNHibernateDemo.ClassMap
{
    public class BaseMap<T>: ClassMap<T> where T:BaseEntity
    {
        public BaseMap()
        {
            this.Id(db => db.id).Column("id");
            this.Map(db => db.updateData);
            this.Map(db => db.createData);
            this.Version(db => db.updateCount);
            
        }
    }
}
