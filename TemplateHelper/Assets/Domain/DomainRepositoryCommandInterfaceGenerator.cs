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

    public class DomainRepositoryCommandInterfaceGenerator : FileGeneratorBase, IFileGenerator
    {
        string DomainModel { get { return "{DomainModel}"; } }

        public DomainRepositoryCommandInterfaceGenerator(TreeNode nodeCollection) : base(nodeCollection) 
        {

            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.CommandsTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.TargetPath.Replace(this.DomainModel,base.Domain)}" +
                $"{CustomConfiguration.DomainConfig.RepositoryInterfaces.CommandsTargetFile.Replace(this.DomainModel, this.Domain)}";

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

        public override bool SaveToFile() => base.SaveToFile();


        public StringBuilder MergeDomainModel(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModel, domainName.FormatToCamelCaseRemoveUnderline());
            return partialMergeFile;
        }

        #endregion


    }
}

