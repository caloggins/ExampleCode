namespace TopShelfWcfExample.MyBusinessLibrary.UnitTests
{
    using System;

    // found @ http://www.jamesthigpen.com/blog/2008/10/06/captureexception-bdd-esque-w-nunit-or-the-ikea-nightstand/
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