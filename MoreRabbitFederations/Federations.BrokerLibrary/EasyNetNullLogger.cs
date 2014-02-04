namespace Federations.BrokerLibrary
{
    using System;

    using EasyNetQ;

    public class EasyNetNullLogger : IEasyNetQLogger
    {
        public void DebugWrite(string format, params object[] args)
        {
        }

        public void InfoWrite(string format, params object[] args)
        {
        }

        public void ErrorWrite(string format, params object[] args)
        {
        }

        public void ErrorWrite(Exception exception)
        {
        }
    }
}