using System;

namespace NHibernateDemo.Entity
{
    public class Book
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
    }
}
