namespace FluentNHibernateDemo.Entity
{
    class User: BaseEntity
    {
     
        public virtual string account { get; set; }
        public virtual string password { get; set; }
       
    }
}
