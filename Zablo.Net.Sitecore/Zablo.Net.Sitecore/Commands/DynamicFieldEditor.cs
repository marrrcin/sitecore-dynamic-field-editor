using System.Collections.Specialized;
using Sitecore.Pipelines;
using Sitecore.Shell.Applications.WebEdit;
using Sitecore.Shell.Applications.WebEdit.Commands;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Zablo.Net.Sitecore.Pipelines.GetDynamicFieldEditor.Abstract;

namespace Zablo.Net.Sitecore.Commands
{
    public class DynamicFieldEditor : FieldEditor
    {
        protected CommandContext CommandContext;

        public override void Execute(CommandContext context)
        {
            CommandContext = context;
            base.Execute(context);
        }

        protected override PageEditFieldEditorOptions GetOptions(ClientPipelineArgs args, NameValueCollection form)
        {
            var options = base.GetOptions(args, form);
            var pipelineArgs = new GetDynamicFieldEditorPipelineArgs(args, form, CommandContext, options);
            CorePipeline.Run("getDynamicFieldEditor", pipelineArgs, false);
            return options;
        }
    }
}
