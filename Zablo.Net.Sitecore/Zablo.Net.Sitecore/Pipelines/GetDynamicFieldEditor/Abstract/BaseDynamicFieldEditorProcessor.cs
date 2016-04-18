using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.WebEdit;
using Sitecore.Text;

namespace Zablo.Net.Sitecore.Pipelines.GetDynamicFieldEditor.Abstract
{
    public abstract class BaseDynamicFieldEditorProcessor : IGetDynamicFieldEditorProcessor
    {
        protected abstract ID RenderingId { get; }
        public virtual void Process(GetDynamicFieldEditorPipelineArgs args)
        {
            var parameters = args.ClientPipelineArgs.Parameters;
            var renderingId = parameters.Get("renderingId");
            var options = args.FieldEditorOptions;

            if (string.IsNullOrEmpty(renderingId) || ID.Parse(renderingId) != RenderingId)
            {
                return;
            }
            var datasourceUri = parameters["uri"];
            Item datasource = null;
            if (datasourceUri != null)
            {
                datasource = Database.GetItem(ItemUri.Parse(datasourceUri));
            }
            ProvideDynamicFields(args, options, parameters, datasource);
        }

        /// <summary>
        /// Provide custom logic for displaying fields here
        /// </summary>
        /// <param name="args"></param>
        /// <param name="options"></param>
        /// <param name="parameters"></param>
        /// <param name="datasource"></param>
        protected abstract void ProvideDynamicFields(GetDynamicFieldEditorPipelineArgs args,
            PageEditFieldEditorOptions options, NameValueCollection parameters, Item datasource);
    }
}
