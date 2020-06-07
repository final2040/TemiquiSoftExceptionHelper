using System;

namespace ExceptionHelper
{
    public class ExceptionHelper
    {
        private readonly IExceptionHandlers _exceptionHandlers;

        public ExceptionHelper() : this(new DefaultConfiguration(null))
        {

        }
        public ExceptionHelper(IExceptionHandlers configuration)
        {
            _exceptionHandlers = configuration;
        }

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
            if ( _exceptionHandlers.IsThereABehaviorFor(e.GetType()) )
                _exceptionHandlers.GetBehaviorFor(e).Invoke(e);
            else
                OnException(e);
        }

        protected virtual void OnException(Exception e)
        {
            throw e;
        }

        public void AddBehaviorFor(Type type, Action<Exception> handler)
        {
            _exceptionHandlers.AddBehavior(type, handler);
        }

        public void AddBehaviorFor<T>(Action<Exception> behavior)
        {
            _exceptionHandlers.AddBehaviorFor<T>(behavior);
        }
    }
}
