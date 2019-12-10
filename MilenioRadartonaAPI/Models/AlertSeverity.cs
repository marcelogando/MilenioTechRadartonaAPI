using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambdaGetTempo.Model
{
    public enum Severity
    {
        Advisory,
        Watch,
        Warning,
        Unknown
    }

    public static class AlertSeverity
    {
        public static Severity FromString(string severity)
        {
            switch (severity)
            {
                case "advisory":
                    return Severity.Advisory;
                case "watch":
                    return Severity.Watch;
                case "warning":
                    return Severity.Warning;
                default:
                    return Severity.Unknown;
            }
        }

        public static string ToValue(this Severity severity)
        {
            switch (severity)
            {
                case Severity.Advisory:
                    return "advisory";
                case Severity.Watch:
                    return "watch";
                case Severity.Warning:
                    return "warning";
                default:
                    return "unknown";
            }
        }
    }
}
