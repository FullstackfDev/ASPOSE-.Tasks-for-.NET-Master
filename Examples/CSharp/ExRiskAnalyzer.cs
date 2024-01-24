﻿namespace Aspose.Tasks.Examples.CSharp
{
    using System;
    using NUnit.Framework;
    using RiskAnalysis;

    [TestFixture]
    public class ExRiskAnalyzer : ApiExampleBase
    {
        [Test]
        public void PrepareRiskAnalyzer()
        {
            // ExStart:AnalyzeRisks
            // ExFor: RiskAnalyzer
            // ExFor: RiskAnalyzer.#ctor(RiskAnalysisSettings)
            // ExFor: RiskAnalyzer.Analyze(Project)
            // ExFor: RiskAnalyzer.Settings
            // ExFor: RiskAnalysis.ConfidenceLevel
            // ExFor: ProbabilityDistributionType
            // ExSummary: Shows how to start analysis of risks by using <see cref="Aspose.Tasks.RiskAnalysis.RiskAnalysisSettings" />.
            var settings = new RiskAnalysisSettings
            {
                IterationsCount = 200
            };

            var project = new Project(DataDir + "Software Development Plan-1.mpp");
            var task = project.RootTask.Children.GetById(17);

            // Initialize a risk pattern
            var pattern = new RiskPattern(task)
            {
                // Select a distribution type for the random number generator to generate possible values from (only two types currently supported, namely normal and uniform)            
                // For more details see here: https://en.wikipedia.org/wiki/Normal_distribution)
                Distribution = ProbabilityDistributionType.Normal,

                // Set the percentage of the most likely task duration which can happen in the best possible project scenario 
                // The default value is 75, which means that if the estimated specified task duration is 4 days then the optimistic duration will be 3 days
                Optimistic = 70,

                // Set the percentage of the most likely task duration which can happen in the worst possible project scenario 
                // The default value is 125, which means that if the estimated specified task duration is 4 days then the pessimistic duration will be 5 days.
                Pessimistic = 130,

                // Set a confidence level that correspond to the percentage of the time the actual values will be within optimistic and pessimistic estimates. 
                // You can think of it as a value of standard deviation: the more uncertain about your estimates you are, the more the value of standard deviation used in random number generator is
                ConfidenceLevel = ConfidenceLevel.CL75
            };
            settings.Patterns.Add(pattern);

            // Analyze the project risks
            var analyzer = new RiskAnalyzer(settings);
            var analysisResult = analyzer.Analyze(project);
            var earlyFinish = analysisResult.GetRiskItems(RiskItemType.EarlyFinish).Get(project.RootTask);

            Console.WriteLine("Expected value: {0}", earlyFinish.ExpectedValue);
            Console.WriteLine("StandardDeviation: {0}", earlyFinish.StandardDeviation);
            Console.WriteLine("10% Percentile: {0}", earlyFinish.GetPercentile(10));
            Console.WriteLine("50% Percentile: {0}", earlyFinish.GetPercentile(50));
            Console.WriteLine("90% Percentile: {0}", earlyFinish.GetPercentile(90));
            Console.WriteLine("Minimum: {0}", earlyFinish.Minimum);
            Console.WriteLine("Maximum: {0}", earlyFinish.Maximum);

            settings = new RiskAnalysisSettings
            {
                IterationsCount = 300
            };

            // change settings
            analyzer.Settings = settings;

            analysisResult = analyzer.Analyze(project);
            earlyFinish = analysisResult.GetRiskItems(RiskItemType.EarlyFinish).Get(project.RootTask);

            Console.WriteLine("Expected value: {0}", earlyFinish.ExpectedValue);
            Console.WriteLine("StandardDeviation: {0}", earlyFinish.StandardDeviation);
            Console.WriteLine("10% Percentile: {0}", earlyFinish.GetPercentile(10));
            Console.WriteLine("50% Percentile: {0}", earlyFinish.GetPercentile(50));
            Console.WriteLine("90% Percentile: {0}", earlyFinish.GetPercentile(90));
            Console.WriteLine("Minimum: {0}", earlyFinish.Minimum);
            Console.WriteLine("Maximum: {0}", earlyFinish.Maximum);

            analysisResult.SaveReport(OutDir + "AnalysisReport_out.pdf");

            // ExEnd:AnalyzeRisks
        }
    }
}