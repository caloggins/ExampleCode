namespace TddExamples.Naming.Tests
{
    using System;

    public static class Capture
    {
        public static Exception Exception(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
    }
}