using FluentNHibernateDemo.Entity;
using FluentNHibernateDemo.ClassMap;

namespace DV_Service.NHibernate
{
    class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            this.Map(db => db.account).Column("account");
            this.Map(db => db.password).Column("password");
        }
    }

}
