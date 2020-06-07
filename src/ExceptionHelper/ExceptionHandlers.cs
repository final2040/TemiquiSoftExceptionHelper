using System;
using System.Collections.Generic;

namespace ExceptionHelper
{
    public abstract class ExceptionHandlers<T> : IExceptionHandlers where T : class
    {
        private readonly Dictionary<Type, Action<Exception>> _behaviors = new Dictionary<Type, Action<Exception>>();

        protected ExceptionHandlers(T context)
        {
            Configure(context);
        }

        public Action<Exception> GetBehaviorFor(Exception e)
        {
            Action<Exception> behavior = null;
            if ( _behaviors.ContainsKey(e.GetType()) )
                behavior = _behaviors[e.GetType()];
            else if ( _behaviors.ContainsKey(typeof(Exception)) )
                behavior = _behaviors[typeof(Exception)];

            return behavior;
        }

        public bool IsThereABehaviorFor(Type type)
        {
            return _behaviors.ContainsKey(type) || _behaviors.ContainsKey(typeof(Exception));
        }

        public void AddBehavior(Type type, Action<Exception> handler)
        {
            try
            {
                _behaviors.Add(type, handler);
            }
            catch ( ArgumentException e )
            {
                throw new InvalidOperationException($"A behavior for {type.Name} exception has been already defined.");
            }
        }

        public void AddBehaviorFor<T>(Action<Exception> handler)
        {
            AddBehavior(typeof(T), handler);
        }

        protected abstract void Configure(T context);
    }
}