using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class AppAutoMapperDomainToViewModelGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";
        string DomainMapping => "{DomainMapping}";
        string AppendTag => CustomConfiguration.ApplicationConfig.AutoMapper.AppendTag;


        public AppAutoMapperDomainToViewModelGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.AutoMapper.DomainToViewTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.AutoMapper.TargetPath}" +
                $"{CustomConfiguration.ApplicationConfig.AutoMapper.DomainToViewTargetFile}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.ApplicationConfig.AutoMapper.TargetPath}";

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
                sbTemplateMerged = MergeDomainMapping(sbTemplateMerged, this.SelectedNode.Text);

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

        private StringBuilder MergeDomainMapping(StringBuilder partialMergeFile, string domainName)
        {
            StringBuilder sbProperties = new StringBuilder();
            sbProperties.AppendLine($"CreateMap<{domainName.FormatToCamelCaseRemoveUnderline()}, " +
                $"{domainName.FormatToCamelCaseRemoveUnderline()}ViewModel>();");
            return partialMergeFile.Replace(this.DomainMapping, sbProperties.ToString());
        }


        #endregion


        #endregion


    }
}

