using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class WebApiControllerGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";
        string ApiVersion => "{ApiVersion}";
        string ApiVersionNameSpace => "{ApiVersionNameSpace}";


        public WebApiControllerGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.WebApiConfig.Controllers.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.WebApiConfig.Controllers.TargetPath.Replace(this.ApiVersionNameSpace, CustomConfiguration.WebApiConfig.Controllers.ApiVersionNameSpace)}" +
                $"{CustomConfiguration.WebApiConfig.Controllers.TargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.WebApiConfig.Controllers.TargetPath.Replace(this.ApiVersionNameSpace, CustomConfiguration.WebApiConfig.Controllers.ApiVersionNameSpace)}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;
                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeApiVersion(sbTemplateMerged);
                sbTemplateMerged = MergeApiVersionNameSpace(sbTemplateMerged);

                return sbTemplateMerged;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override bool SaveToFile()
        {
            return base.SaveToFile();
        }

        #region Assets Merge

        private StringBuilder MergeDomainModel(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModel, domainName.FormatToCamelCaseRemoveUnderline());
            return partialMergeFile;
        }

        private StringBuilder MergeApiVersion(StringBuilder partialMergeFile)
        {
            partialMergeFile.Replace(this.ApiVersion,
                CustomConfiguration.WebApiConfig.Controllers.ApiVersion);
            return partialMergeFile;
        }

        private StringBuilder MergeApiVersionNameSpace(StringBuilder partialMergeFile)
        {
            partialMergeFile.Replace(this.ApiVersionNameSpace,
                CustomConfiguration.WebApiConfig.Controllers.ApiVersionNameSpace);
            return partialMergeFile;
        }


        #endregion


        #endregion


    }
}

