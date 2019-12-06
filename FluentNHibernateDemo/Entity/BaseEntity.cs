using System;

namespace FluentNHibernateDemo.Entity
{
    public class BaseEntity
    {
        public virtual int id { get; set; }
        public virtual int updateCount { get; set; }
        public virtual DateTime createData { get; set; }
        public virtual DateTime updateData { get; set; }
    }
}
