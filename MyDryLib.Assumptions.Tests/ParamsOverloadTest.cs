using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDryLib.Assumptions.Tests
{
    [TestClass]
    public class ParamsOverloadTest
    {
        private const String Direct = "Direct: ";
        private const String Params = "Params: ";
        private const String Message = "message";
        private const String Format1 = "Formatted: {0}";
        private const String Format2 = "Formatted: {0}, {1}";
        private readonly List<String> _messages = new List<String>();


        #region suspect

        private void Log(String message)
        {
            _messages.Add(Direct + message);
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        private void Log(String format, params Object[] list)
        // ReSharper restore MethodOverloadWithOptionalParameter
        {
            _messages.Add(Params + String.Format(format, list));
        }

        private void Journalize(String format, params Object[] list)
        {
            _messages.Add(Params + String.Format(format, list));
        }
        #endregion
        

        [TestMethod]
        public void UsesDirectOverloadIfNoArgsGiven()
        {
            Log(Message);
            const String expected = Direct + Message;
            Assert.AreEqual(expected, _messages.Single());
        }

        [TestMethod]
        public void UsesParamsOverloadIfArgGiven()
        {
            Log(Format1, Message);
            var expected = Params + String.Format(Format1, Message);
            Assert.AreEqual(expected, _messages.Single());
        }

        [TestMethod]
        public void UsesParamsOverloadIfArgsGiven()
        {
            Log(Format2, Message, Message);
            var expected = Params + String.Format(Format2, Message, Message);
            Assert.AreEqual(expected, _messages.Single());
        }

        [TestMethod]
        public void UsesParamsOverloadIfArgArrayGiven()
        {
            var messages = new Object[]{Message, Message};
            Log(Format2, messages);
            var expected = Params + String.Format(Format2, Message, Message);
            Assert.AreEqual(expected, _messages.Single());
        }

        // using params without direct overload can be dangerous
        // - maybe performance issue (measure yourself)
        // - tedious as underlying implementation may rely on it
        
        [TestMethod]
        public void UsesParamsIfNoDirectOverloadExists()
        {
            Journalize(Message);
            const String expected = Params + Message;
            Assert.AreEqual(expected, _messages.Single());
        }
        
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void UsesParamsWithoutDirectOverloadIsDangerous()
        {
            Journalize(Format1);// provoke exception
            const String expected = Params + Format1;
            Assert.AreEqual(expected, _messages.Single());
        }
    }
}
