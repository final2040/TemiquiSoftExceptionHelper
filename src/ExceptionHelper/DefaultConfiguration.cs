namespace ExceptionHelper
{
    internal class DefaultConfiguration: ExceptionHandlers<object>
    {
        public DefaultConfiguration(object context) : base(context)
        {
        }

        protected override void Configure(object context)
        {
            
        }
    }
}