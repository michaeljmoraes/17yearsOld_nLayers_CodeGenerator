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

    public class DataCommandsRepositoryGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string SPDomain { get { return "{sp_domain}"; } }
        string FNDomain { get { return "{fn_domain}"; } }
        string InsertParameters { get { return "{InsertParameters}"; } }
        string UpdateParameters { get { return "{UpdateParameters}"; } }

        public DataCommandsRepositoryGenerator(TreeNode nodeCollection)  : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.CommandsTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.TargetPath.Replace(this.DomainModel, this.Domain)}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.CommandsTargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.TargetPath.Replace(this.DomainModel, this.Domain)}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeSPDomain(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeFNDomain(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeInsertParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeUpdateParameters(sbTemplateMerged, this.SelectedNode.Nodes);

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
            partialMergeFile.Replace(this.DomainModel, domainName.FormatToCamelCaseRemoveUnderline());
            return partialMergeFile;
        }

        private StringBuilder MergeSPDomain(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.SPDomain, domainName.ToLower());
            return partialMergeFile;
        }
        
        private StringBuilder MergeFNDomain(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.FNDomain, domainName.ToLower());
            return partialMergeFile;
        }


        private StringBuilder MergeInsertParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            //cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);

            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"cmd.Parameters.AddWithValue(\"_{node.Text}\", NpgsqlDbType.{node.Tag.ToString().FormatToParameterCommandType()}, entity.{node.Text.FormatToCamelCaseRemoveUnderline()});");

            }
            return partialMergeFile.Replace(this.InsertParameters, sbProperties.ToString());
        }

        private StringBuilder MergeUpdateParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();

            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"cmd.Parameters.AddWithValue(\"_{node.Text}\", NpgsqlDbType.{node.Tag.ToString().FormatToParameterCommandType()}, entity.{node.Text.FormatToCamelCaseRemoveUnderline()});");
            }
            return partialMergeFile.Replace(this.UpdateParameters, sbProperties.ToString());
        }

        #endregion


        #endregion


    }
}

