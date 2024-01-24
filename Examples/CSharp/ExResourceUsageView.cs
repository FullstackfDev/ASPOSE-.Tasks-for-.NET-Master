﻿namespace Aspose.Tasks.Examples.CSharp
{
    using System;
    using NUnit.Framework;
    using Saving;
    using Visualization;

    [TestFixture]
    public class ExResourceUsageView : ApiExampleBase
    {
        [Test]
        public void RenderResourceUsageView()
        {
            // ExStart:RenderResourceUsageView
            // ExFor: ResourceUsageView
            // ExSummary: Shows how to render resource usage view.
            var project = new Project(DataDir + "ResourceUsageView.mpp");

            // Define the SaveOptions with required TimeScale settings as Days
            SaveOptions options = new PdfSaveOptions
            {
                Timescale = Timescale.Days,

                // Set the Presentation format to ResourceUsage
                PresentationFormat = PresentationFormat.ResourceUsage
            };

            project.Save(OutDir + "ResourceUsage_days_out.pdf", options);

            // ExEnd:RenderResourceUsageView
        }

        [Test]
        public void ReadFieldCollectionOfTaskUsageView()
        {
            // ExStart
            // ExFor: ResourceUsageView.FieldCollection
            // ExFor: ResourceUsageViewField
            // ExSummary: Shows how to read resource usage view fields.
            var project = new Project(DataDir + "ResourceUsageView.mpp");

            var view = (ResourceUsageView)project.Views.ToList()[2];
            foreach (var field in view.FieldCollection)
            {
                Console.WriteLine("Field: " + field);
            }

            // ExEnd
        }
    }
}