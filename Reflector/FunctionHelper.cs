using System;
using System.Text;

namespace DynamicReflector
{
    internal static class FunctionHelper
    {
        public static ErrorStatus Run(Func<int> func, string errorDescription)
        {
            try
            {
                int errCode = func();
                if (errCode == 0)
                    return new ErrorStatus();

                StringBuilder description = new StringBuilder($@"Operation failed, error code: {errCode}");

                if (!string.IsNullOrWhiteSpace(errorDescription))
                {
                    description.Append(", ");
                    description.Append(errorDescription);
                }
                description.Append('.');

                return new ErrorStatus(description.ToString(), errCode);
            }
            catch (Exception ex)
            {
                return new ErrorStatus(ex.Message, 1);
            }
        }

        internal readonly struct ErrorStatus
        {
            public ErrorStatus(string errText, int errorCode)
            {
                ErrorText = errText;
                ErrorCode = errorCode;
            }

            public int ErrorCode { get; }
            public string ErrorText { get; }
            public override string ToString() => ErrorText;
        }
    }
}