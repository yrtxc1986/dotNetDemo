using NHibernate.Dialect;

namespace FluentNHibernateDemo.Config
{
    public class ParaDMMsSql2012Dialect : MsSql2012Dialect
    {
        public ParaDMMsSql2012Dialect()
        {
            /*
            RegisterFunction(
                "recent_date",
                new SQLFunctionTemplate(
                    NHibernateUtil.Date,
                    "dateadd(day, -15, getdate())"
                    )
                );
                */
        }


    }
}
