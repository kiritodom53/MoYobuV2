using System;
using System.Collections.Generic;
using FFImageLoading.Helpers;

namespace MoYobuV2.Helpers
{
    public class CustomFFLoger : IMiniLogger
    {
        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine("=== Debug ===");
            System.Diagnostics.Debug.WriteLine(message);
            System.Diagnostics.Debug.WriteLine("%%% Debug %%%");
        }

        public void Error(string errorMessage)
        {
            // Insights.Report(errorMessage);
            System.Diagnostics.Debug.WriteLine("=== Error ===");
            System.Diagnostics.Debug.WriteLine(errorMessage);
            System.Diagnostics.Debug.WriteLine("%%% Error %%%");
        }

        public void Error(string errorMessage, Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("=== Error ===");
            System.Diagnostics.Debug.WriteLine(ex + "\n");
            System.Diagnostics.Debug.WriteLine(errorMessage);
            System.Diagnostics.Debug.WriteLine("%%% Error %%%");
            // Insights.Report(ex, new Dictionary <string, string> { {"message", errorMessage} });
        }
    }
}