namespace TopShelfWcfExample.ConsoleApp
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MyConfigurationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MyConfigurationException()
        {
        }

        public MyConfigurationException(string message) : base(message)
        {
        }

        public MyConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MyConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}