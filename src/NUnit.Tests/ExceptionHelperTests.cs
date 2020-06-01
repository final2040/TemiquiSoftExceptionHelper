using NUnit.Framework;
using ExceptionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHelper.Tests
{
    [TestFixture()]
    public class ExceptionHelperTests
    {
        /// <summary>
        /// Given: code is called using try
        /// When: code is provided
        /// Then: should execute the providen code
        /// </summary>
        [Test()]
        public void Try_ShouldExecuteGivenCode()
        {
            // arrange
            var helper = new ExceptionHelper();
            var current = false;
            var expected = true;

            // act
            helper.Try(() => current = true);

            // assert
            Assert.That(current, Is.EqualTo(expected));
        }

        /// <summary>
        /// Given: a catch behavior is defined for an exception
        /// When: executed code throws an exception
        /// Then: should execute providen code for exception
        /// </summary>
        [Test()]
        public void Try_ShouldExecuteExceptionCode()
        {
            // arrange
            var helper = new ExceptionHelper();
            var current = false;
            var expected = true;

            helper.AddBehaviorFor(typeof(Exception), (e) => current = true);

            // act
            helper.Try(() => throw new Exception());

            // assert
            Assert.That(current, Is.EqualTo(expected));
        }

        /// <summary>
        /// Given: a catch behavior is defined for an exception
        /// When: executed code throws an exception
        /// Then: pass the original exception to callback code
        /// </summary>
        [Test()]
        public void Try_ShouldPassOriginalExceptionParameter()
        {
            // arrange
            var helper = new ExceptionHelper();
            Exception current = null;
            var expected = new Exception("Test exception");

            helper.AddBehaviorFor(typeof(Exception), (e) => current = e);

            // act
            helper.Try(() => throw expected);

            // assert
            Assert.That(current, Is.EqualTo(expected));
        }

        /// <summary>
        /// Given: a catch behavior is defined for an exception
        /// When: executed code throws a not defined exception
        /// Then: rethrow the not defined exception
        /// </summary>
        [Test()]
        public void Try_ShouldRethrowANotDefinedException()
        {
            // arrange
            var helper = new ExceptionHelper();
            var expected = new ArgumentException("Test exception");


            // act


            // assert
            Assert.Throws<ArgumentException>(() => helper.Try(() => throw expected));
        }

        /// <summary>
        /// Given: a catch behavior is defined for an exception
        /// When: user try to add same behavior twice
        /// Then: throws InvalidOperationException 
        /// </summary>
        [Test()]
        public void Try_ShouldThrowInvalidOperationExceptionWhenTryToAddRepeatedBehavior()
        {
            // arrange
            var helper = new ExceptionHelper();
            Exception current = null;
            var expected = new Exception("Test exception");

            helper.AddBehaviorFor(typeof(Exception), (e) => current = e);


            // act
            Assert.Throws<InvalidOperationException>(() =>
                helper.AddBehaviorFor(typeof(Exception), (e) => current = e));
        }

        /// <summary>
        /// Given: a catch behavior is defined for an exception with the Generic Method
        /// When: executed code throws an exception
        /// Then: should execute the code for exception
        /// </summary>
        [Test()]
        public void Try_AddBehaviorWithGenericShouldExecuteExceptionCode()
        {
            // arrange
            var helper = new ExceptionHelper();
            var current = false;
            var expected = true;

            helper.AddBehaviorFor<Exception>((e) => current = true);

            // act
            helper.Try(() => throw new Exception());

            // assert
            Assert.That(current, Is.EqualTo(expected));
        }

        /// <summary>
        /// Given: code is called using try
        /// When: code that returns a value is provided
        /// Then: should execute the providen code and return the valur
        /// </summary>
        [Test()]
        public void Try_ShouldExecuteGivenCodeAndReturnResult()
        {
            // arrange
            var helper = new ExceptionHelper();
            var current = false;
            var expected = true;

            // act
            current = helper.Try(() => true);

            // assert
            Assert.That(current, Is.EqualTo(expected));
        }
    }
}