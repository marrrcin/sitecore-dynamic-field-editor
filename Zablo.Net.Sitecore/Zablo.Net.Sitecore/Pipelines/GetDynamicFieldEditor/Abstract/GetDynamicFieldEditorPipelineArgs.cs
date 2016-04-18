using System.Collections.Specialized;
using Sitecore.Pipelines;
using Sitecore.Shell.Applications.WebEdit;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace Zablo.Net.Sitecore.Pipelines.GetDynamicFieldEditor.Abstract
{
    public class GetDynamicFieldEditorPipelineArgs : PipelineArgs
    {
        public GetDynamicFieldEditorPipelineArgs(ClientPipelineArgs args, NameValueCollection form, CommandContext commandContext, PageEditFieldEditorOptions options)
        {
            ClientPipelineArgs = args;
            Form = form;
            CommandContext = commandContext;
            FieldEditorOptions = options;
        }

        public ClientPipelineArgs ClientPipelineArgs { protected set; get; }

        public NameValueCollection Form { protected set; get; }

        public CommandContext CommandContext { protected set; get; }

        public PageEditFieldEditorOptions FieldEditorOptions { protected set; get; }
    }
}
