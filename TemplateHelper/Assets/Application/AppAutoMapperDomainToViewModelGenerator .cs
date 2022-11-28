using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Data;
using Procwork.CodeGenerator.Extensions;
using Procwork.CodeGenerator.TemplateHelper.Base;

namespace Procwork.CodeGenerator.Classes
{

    public class AppAutoMapperDomainToViewModelGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string DomainMapping { get { return "{DomainMapping}"; } }
        string AppendTag { get { return CustomConfiguration.ApplicationConfig.AutoMapper.AppendTag; } }
        

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

        public override bool SaveToFile() => base.AppendToClass(this.AppendTag);

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

