using System;
using System.Text;

namespace DynamicReflector
{
    internal static class FunctionHelper
    {
        public static ErrorStatus Run(Func<int> func, string errorDescription)
        {
            string errString = string.Empty, errStopped = string.Empty;
            bool exStopped = false;

            try
            {
                int errCode = func();
                if (errCode == 0)
                    return new ErrorStatus();

                StringBuilder description = new StringBuilder($@"Operation failed, error code: {errCode}");

                if (string.IsNullOrWhiteSpace(errorDescription))
                {
                    description.Append('.');
                    return new ErrorStatus(description.ToString(), true);
                }

                description.Append(", ");
                description.Append(errorDescription);
                description.Append('.');

                return new ErrorStatus(description.ToString(), true);
            }
            catch (Exception ex)
            {
                try
                {
                    errString = ex.Message;
                }
                catch (Exception ex1)
                {
                    errStopped = ex1.Message;
                    exStopped = true;
                }
            }

            return new ErrorStatus(exStopped ? $@"{errString}{Environment.NewLine}{errStopped}" : errString, true);
        }

        internal readonly struct ErrorStatus
        {
            public ErrorStatus(string errText, bool statusError)
            {
                ErrorText = errText;
                StatusError = statusError;
            }

            public string ErrorText { get; }
            public bool StatusError { get; }
        }
    }
}