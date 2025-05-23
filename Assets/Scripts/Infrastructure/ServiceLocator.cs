using System;
using System.Collections.Generic;
using Interfaces;

namespace Infrastructure
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> _services = new();
        
        public void Register<TService>(TService service)
        {
            Type type = typeof(TService);
            if (_services.ContainsKey(type))
                throw new Exception($"Service {type} already registered");
            
            _services[typeof(TService)] = service;
        }

        public TService Resolve<TService>()
        {
            if (_services.TryGetValue(typeof(TService), out var service)) 
                return (TService)service;
            
            throw new Exception($"Service of type {typeof(TService)} not found");
        }
    }
}