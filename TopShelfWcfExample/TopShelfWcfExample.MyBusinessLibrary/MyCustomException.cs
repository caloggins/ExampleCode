namespace TopShelfWcfExample.MyBusinessLibrary
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MyCustomException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MyCustomException()
        {
        }

        public MyCustomException(string message) : base(message)
        {
        }

        public MyCustomException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MyCustomException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}