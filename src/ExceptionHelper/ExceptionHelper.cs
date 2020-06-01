using System;
using System.Collections.Generic;

namespace ExceptionHelper
{
    public class ExceptionHelper
    {
        private readonly Dictionary<Type, Action<Exception>> _behaviors = new Dictionary<Type, Action<Exception>>();

        public T Try<T>(Func<T> function)
        {
            try
            {
                return function.Invoke();
            }
            catch ( Exception e )
            {
                HandleException(e);
            }

            return default;
        }

        public void Try(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch ( Exception e )
            {
                HandleException(e);
            }
        }

        private void HandleException(Exception e)
        {
            if (_behaviors.ContainsKey(e.GetType()))
                _behaviors[e.GetType()].Invoke(e);
            else if(_behaviors.ContainsKey(typeof(Exception)))
                _behaviors[typeof(Exception)].Invoke(e);
            else
                OnException(e);

        }

        protected virtual void OnException(Exception e)
        {
            throw e;
        }

        public void AddBehaviorFor(Type type, Action<Exception> handler)
        {
            try
            {
                _behaviors.Add(type, handler);
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException($"A behavior for {type.Name} exception has been already defined.");
            }
        }

        public void AddBehaviorFor<T>(Action<Exception> behavior)
        {
            AddBehaviorFor(typeof(T), behavior);
        }
    }
}
