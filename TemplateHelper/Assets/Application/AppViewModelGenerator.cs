using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class AppViewModelGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";
        string DomainProperties => "{DomainProperties}";

        public AppViewModelGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.ViewModels.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.ViewModels.TargetPath}" +
                $"{CustomConfiguration.ApplicationConfig.ViewModels.TargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.ViewModels.TargetPath}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeDomainProperties(sbTemplateMerged, this.SelectedNode.Nodes);

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

        private StringBuilder MergeDomainProperties(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                sbProperties.AppendLine($"public {node.Tag.ToString().FormatToDomainType()} {node.Text.FormatToCamelCaseRemoveUnderline()} {{ get; set; }}");
                sbProperties.AppendLine();
            }
            return partialMergeFile.Replace(this.DomainProperties, sbProperties.ToString());
        }

        #endregion


        #endregion


    }
}

