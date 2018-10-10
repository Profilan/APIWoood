using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Models
{
    public class Log : Entity<int>
    {
        public virtual DateTime TimeStamp { get; protected set; }
        public virtual int Priority { get; protected set; }
        public virtual string Message { get; protected set; }
        public virtual string PriorityName { get; protected set; }
        public virtual string Url { get; protected set; }
        public virtual string Detail { get; protected set; }
        public virtual bool Acknowledged { get; set; }
        public virtual int UserId { get; set; }
        public virtual double Duration { get; set; }

        // Needed for NHibernate
        public Log()
        {

        }

        public Log(DateTime timeStamp,
            int priority,
            string message,
            string priorityName,
            string url,
            string detail,
            bool acknowledged,
            int userId = 1,
            double duration = 0)
        {
            TimeStamp = timeStamp;
            Priority = priority;
            Message = message;
            PriorityName = priorityName;
            Url = url;
            Detail = detail;
            Acknowledged = acknowledged;
            UserId = userId;
            Duration = duration;
        }

        // requestId, targetId, response, properties, referenceId
    }
}
