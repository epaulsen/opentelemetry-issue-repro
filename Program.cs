using System;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace opentelemetry_issue_repro
{
    class Program
    {
        public static ActivitySource Source = new ActivitySource("ReproSource");

        static void Main(string[] args)
        {
            using var tracer = Sdk.CreateTracerProviderBuilder()
                .AddSource("ReproSource")
                .AddOtlpExporter()
                .Build();
            using (Source.StartActivity("Test"))
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
