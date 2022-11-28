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

    public class WebApiDependencyInjectionGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string AppendTag { get { return CustomConfiguration.WebApiConfig.DependencyInjection.AppendTag; } }

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

        public override bool SaveToFile() => base.AppendToClass(this.AppendTag);

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

