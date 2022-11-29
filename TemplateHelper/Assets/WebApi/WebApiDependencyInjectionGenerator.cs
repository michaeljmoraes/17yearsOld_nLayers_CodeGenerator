using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class WebApiDependencyInjectionGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";
        string AppendTag => CustomConfiguration.WebApiConfig.DependencyInjection.AppendTag;

        public WebApiDependencyInjectionGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.WebApiConfig.DependencyInjection.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.WebApiConfig.DependencyInjection.TargetPath}" +
                $"{CustomConfiguration.WebApiConfig.DependencyInjection.TargetFile}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.WebApiConfig.DependencyInjection.TargetPath}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);

                return sbTemplateMerged;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override bool SaveToFile()
        {
            return base.AppendToClass(this.AppendTag);
        }

        #region Assets Merge

        private StringBuilder MergeDomainModel(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModel, domainName.FormatToCamelCaseRemoveUnderline());
            return partialMergeFile;
        }



        #endregion


        #endregion


    }
}

