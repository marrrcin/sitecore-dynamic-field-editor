using System.Collections.Specialized;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.WebEdit;
using Zablo.Net.Sitecore.Pipelines.GetDynamicFieldEditor.Abstract;

namespace Zablo.Net.Sitecore.Pipelines.GetDynamicFieldEditor
{
    public class SampleRenderingFieldProcessor : BaseDynamicFieldEditorProcessor
    {
        protected override ID RenderingId { get { return ID.Parse("{493B3A83-0FA7-4484-8FC9-4680991CF743}"); } }

        protected override void ProvideDynamicFields(GetDynamicFieldEditorPipelineArgs args, PageEditFieldEditorOptions options,
            NameValueCollection parameters, Item datasource)
        {
            options.Fields.Clear();
            if (datasource.TemplateID == ID.Parse("{76036F5E-CBCE-46D1-AF0A-4143F9B557AA}"))
            {
                options.ShowSections = false;
                options.PreserveSections = false;
                options.Fields.Add(new FieldDescriptor(datasource,"Title"));
            }
            else
            {
                options.ShowSections = true;
                options.PreserveSections = true;
                options.Fields.Add(new FieldDescriptor(datasource, "SomeOtherField"));
            }
        }
    }
}
