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
using NpgsqlTypes;

namespace Procwork.CodeGenerator.Classes
{

    public class DataBaseFunctionsGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string DomainModelFN { get { return "{entity_domain}"; } }

        public DataBaseFunctionsGenerator(TreeNode nodeCollection)  : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.Functions.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.Functions.TargetPath}" +
                $"{CustomConfiguration.DataBaseConfig.Functions.TargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.Functions.TargetPath}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeDomainModelFN(sbTemplateMerged, this.SelectedNode.Text);

                return sbTemplateMerged;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override bool SaveToFile() => base.SaveToFile();

        #region Assets Merge

        private StringBuilder MergeDomainModel(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModel,Domain.ToLower());
            return partialMergeFile;
        }

        private StringBuilder MergeDomainModelFN(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModelFN, base.SelectedNode.Text);
            return partialMergeFile;
        }

        #endregion


        #endregion


    }
}

