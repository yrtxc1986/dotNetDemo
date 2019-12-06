using FluentNHibernateDemo.Entity;
using NHibernate.Event;
using NHibernate.Persister.Entity;
using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace FluentNHibernateDemo.Config
{
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as BaseEntity;
            if (audit == null)
                return false;

            var time = DateTime.Now;
            //var name = WindowsIdentity.GetCurrent().Name;

            Set(@event.Persister, @event.State, "UpdatedAt", time);
            //Set(@event.Persister, @event.State, "UpdatedBy", name);

            audit.updateData = time;
            //audit.UpdatedBy = name;

            return false;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var audit = @event.Entity as BaseEntity;
            if (audit == null)
                return false;


            var time = DateTime.Now;
            //var name = WindowsIdentity.GetCurrent().Name;

            Set(@event.Persister, @event.State, "CreatedAt", time);
            Set(@event.Persister, @event.State, "UpdatedAt", time);
            //Set(@event.Persister, @event.State, "CreatedBy", name);
            //Set(@event.Persister, @event.State, "UpdatedBy", name);

            audit.createData = time;
            //audit.CreatedBy = name;
            audit.updateData = time;
            //audit.UpdatedBy = name;

            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public static void Register(NHibernate.Cfg.Configuration configuration)
        {
            AuditEventListener listener = new AuditEventListener();
            configuration.SetListener(ListenerType.PreInsert, listener);
            configuration.SetListener(ListenerType.PreUpdate, listener);
        }
    }
}
