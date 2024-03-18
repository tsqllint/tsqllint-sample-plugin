using System;
using TSQLLint.Common;
using System.IO;

namespace TSQLLint.Tests.UnitTests.PluginHandler
{
    public class SamplePlugin : IPlugin
    {
        public void PerformAction(IPluginContext context, IReporter reporter)
        {
            string line;
            var lineNumber = 0;

            using var reader = new StreamReader(File.OpenRead(context.FilePath));

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                var column = line.IndexOf("\t", StringComparison.Ordinal);
                reporter.ReportViolation(new SampleRuleViolation(
                    context.FilePath,
                    "prefer-tabs",
                    "Should use spaces rather than tabs",
                    lineNumber,
                    column,
                    RuleViolationSeverity.Warning));
            }
        }
    }

    public class SampleRuleViolation : IRuleViolation
    {
        public int Column { get; private set; }
        public string FileName { get; private set; }
        public int Line { get; private set; }
        public string RuleName { get; private set; }
        public RuleViolationSeverity Severity { get; private set; }
        public string Text { get; private set; }

        public SampleRuleViolation(string fileName, string ruleName, string text, int lineNumber, int column, RuleViolationSeverity ruleViolationSeverity)
        {
            FileName = fileName;
            RuleName = ruleName;
            Text = text;
            Line = lineNumber;
            Column = column;
            Severity = ruleViolationSeverity;
        }
    }
}
