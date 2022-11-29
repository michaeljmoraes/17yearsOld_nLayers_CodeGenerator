using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class DomainRepositoryQueryInterfaceGenerator : FileGeneratorBase, IFileGenerator
    {
        string DomainModel => "{DomainModel}";

        public DomainRepositoryQueryInterfaceGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {

            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.QueryTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.TargetPath.Replace(this.DomainModel, base.Domain)}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.QueryTargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.TargetPath.Replace(this.DomainModel, this.Domain)}";

            this.SetTemplateFile();

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

        public StringBuilder MergeDomainModel(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModel, domainName.FormatToCamelCaseRemoveUnderline());
            return partialMergeFile;
        }

        #endregion


    }
}

