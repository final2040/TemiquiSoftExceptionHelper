using System;
using ExceptionHelper;

namespace WindowsFormExample
{
    // in the generic we will use the context class in this example i'm using Form1 but you can use an interface to
    // keep things clean
    public class ExampleHandlers: ExceptionHandlers<Form1>
    {
        public ExampleHandlers(Form1 context) : base(context)
        {
        }

        // in this method you can using your context handle the exception as your will
        // the context will be 
        protected override void Configure(Form1 context)
        {
            // here im using the method ShowDialog in the context to manage the error messages
            AddBehaviorFor<DivideByZeroException>((e) => 
                context.ShowDialog("Error", "Ups. It seems that you are trying to divide by zero and that is not posible..."));
            
            AddBehaviorFor<NullReferenceException>((e) => 
                context.ShowDialog("Error", "Whoaaa that object its null you can't do that!!"));
            
            AddBehaviorFor<Exception>((e) => 
                context.ShowDialog("Error", $"Mmmm i don't know that happens but it happens there's is your error: {e.Message}"));
        }
    }

}