using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Framework
{
    public static class SoftAssert
    {
        private static List<string> _errors = new List<string>();
        public static Logger Log = new Logger();

        public static void AssertEqual(object expected, object actual, string message)
        {
            if (!expected.Equals(actual))
            {
                AddError(message);
            }
            else
            {
                Log.Info(" Assert:[" + message + "]");
            }
        }

        public static void AddError(string message)
        {
            _errors.Add("Soft Assert Error:"
                + DateTime.Now.ToShortDateString()
                + DateTime.Now.ToShortTimeString() +
                ": " + message + "\n");
        }

        public static void AllErrors()
        {
            if (_errors.Count > 0)
            {
                Log.Error("All Soft Assert errors: ");
                var allErrors = string.Join(" \n - ", _errors);
                Assert.IsTrue(false, allErrors);
            }
            Log.Info("Don't critical errors");
        }
    }
}