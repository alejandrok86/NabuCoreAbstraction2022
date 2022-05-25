using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EventSubscriptionDOL : BaseDOL
    {
        public EventSubscriptionDOL() : base ()
        {
        }

        public EventSubscriptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EventSubscription Get(int? pEventSubscriptionID)
        {
            return null;
        }

        public EventSubscription[] List()
        {
            return null;
        }

        public EventSubscription Insert(EventSubscription pEventSubscription)
        {
            return null;
        }

        public EventSubscription Update(EventSubscription pEventSubscription)
        {
            return null;
        }

        public EventSubscription Delete(EventSubscription pEventSubscription)
        {
            return null;
        }
    }
}
