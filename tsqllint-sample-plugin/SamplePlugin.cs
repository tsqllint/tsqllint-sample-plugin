using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using TSQLLint.Common;

namespace TSQLLint_Sample_Plugin
{
    public class SamplePlugin : IPlugin
    {
        // This method is required but can be a no-op if using the GetRules method to parse code through the plugin's rules.
        public void PerformAction(IPluginContext context, IReporter reporter)
        {
            string line;
            var lineNumber = 0;

            var reader = new StreamReader(File.OpenRead(context.FilePath));

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

        // Starting with TSQLLint.Common version 3.3.0, this method can be used to return rules to be used by the TSQLLint parser.
        public IDictionary<string, ISqlLintRule> GetRules() => new Dictionary<string, ISqlLintRule>
        {
            ["sample-plugin-rule"] = new SampleRule((Action<string, string, int, int>)null)
        };
    }

    public class SampleRuleViolation : IRuleViolation
    {
        public int Column { get; set; }
        public string FileName { get; private set; }
        public int Line { get; set; }
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

    public class SampleRule : TSqlFragmentVisitor, ISqlLintRule
    {
        protected readonly Action<string, string, int, int> ErrorCallback;

        public SampleRule(Action<string, string, int, int> errorCallback)
        {
            ErrorCallback = errorCallback;
        }

        public string RULE_NAME => "sample-plugin-rule";
        public string RULE_TEXT => "Sample plugin rule message text";
        public RuleViolationSeverity RULE_SEVERITY => RuleViolationSeverity.Warning;

        public override void Visit(TSqlScript node)
        {
            var line = 0;
            var column = 0;

            // Logic for testing TSQL code for rule goes here.

            ErrorCallback(RULE_NAME, RULE_TEXT, line, column);
        }

        public void FixViolation(List<string> fileLines, IRuleViolation ruleViolation, FileLineActions actions)
        {
            // Logic for fixing rule violation goes here.
        }
    }
}
