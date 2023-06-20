using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace HelloWorldTest.BusinessLogic
{
    public class MessageTests
    {
        [Fact]
        public void Greeting_InEnglish()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Hello World";
            string actual = messages.Greeting("en");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_InSpanish()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Hola Mundo";
            string actual = messages.Greeting("es");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_InPortuguese()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            string expected = "Ola Mundo";
            string actual = messages.Greeting("pt");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Greeting_Invalid()
        {
            ILogger<Messages> logger = new NullLogger<Messages>();
            Messages messages = new(logger);

            Assert.Throws<InvalidOperationException>(
                () => messages.Greeting("test")
                );
        }
    }
}
