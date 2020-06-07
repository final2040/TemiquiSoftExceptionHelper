using System;
using System.Windows.Forms;

namespace WindowsFormExample
{
    public partial class Form1 : Form
    {
        private readonly ExceptionHelper.ExceptionHelper _exceptionHelper;

        public Form1()
        {
            InitializeComponent();
            // here im defining the behavior for error management int the application and providing this form
            // as context for exception management open ExampleHandlers.cs to see the configured behaviors
            _exceptionHelper = new ExceptionHelper.ExceptionHelper(new ExampleHandlers(this));
        }

        private void ThrowDivideByZeroButton_Click(object sender, EventArgs e)
        {
            var number = 10;
            _exceptionHelper.Try(() => number = number / 0);
        }

        // this method will be used by to show the screen messages
        public void ShowDialog(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ThrowNullExceptionButton_Click(object sender, EventArgs e)
        {
            string text = null;
            _exceptionHelper.Try(() => text = text.Substring(10));
        }

        // in this case i will throw an unknown exception for the handler in this cases the handler will use 
        // the Exception Behavior if it is definer otherwise it only rethrow the exception
        private void ThrowGenericExceptionButton_Click(object sender, EventArgs e)
        {
            _exceptionHelper.Try(() => throw new NotImplementedException());
        }
    }
}
