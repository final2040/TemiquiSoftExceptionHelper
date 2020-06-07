using System;

namespace ExceptionHelper
{
    public interface IExceptionHandlers
    {
        Action<Exception> GetBehaviorFor(Exception e);
        bool IsThereABehaviorFor(Type type);
        void AddBehavior(Type type, Action<Exception> handler);
        void AddBehaviorFor<T>(Action<Exception> handler);
    }
}