using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class AppDomainServiceInterfaceGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";

        public AppDomainServiceInterfaceGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.DomainAppService.InterfaceTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.DomainAppService.TargetPath.Replace(this.DomainModel, this.Domain)}" +
                $"{CustomConfiguration.ApplicationConfig.DomainAppService.InterfaceTargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.DomainAppService.TargetPath.Replace(this.DomainModel, this.Domain)}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;
                StringBuilder domainParameters = new StringBuilder();

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
            return base.SaveToFile();
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

