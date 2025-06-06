using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEventAggregator
    {
        void Subscribe<T>(Action<T> action);
        void Unsubscribe<T>(Action<T> action);
        void Publish<T>(T eventData);
        void RemoveEvent<T>();
        void RemoveAllEvents();
        List<Type> GetAllEvents();
        List<Delegate> GetSubscribers<T>();
        void LogAllEvents();
        void LogAllSubscribers();
    }
}