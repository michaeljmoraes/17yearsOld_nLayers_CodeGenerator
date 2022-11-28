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

    public class DataQueryRepostiroyGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string SPDomain { get { return "{sp_domain}"; } }
        string FNDomain { get { return "{fn_domain}"; } }

        string MapParameters { get { return "{map_parameters}"; } }
        string MapsParameters { get { return "{maps_parameters}"; } }

        public DataQueryRepostiroyGenerator(TreeNode nodeCollection)  : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.QueryTemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.TargetPath.Replace(this.DomainModel, this.Domain)}" +
                $"{CustomConfiguration.DataConfig.RepositoryImplementation.QueryTargetFile.Replace(this.DomainModel, this.Domain)}";

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
                StringBuilder domainParameters = new StringBuilder();

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeSPDomain(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeFNDomain(sbTemplateMerged, this.SelectedNode.Text);

                sbTemplateMerged = MergeMapParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeMapsParameters(sbTemplateMerged, this.SelectedNode.Nodes);

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

        private StringBuilder MergeMapParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            //cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);

            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"{node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter()}: Convert.{node.Tag.ToString().FormatToDotNetType()}(reader[\"{node.Text.ToLower()}\"].ToString()),");
            }
            return partialMergeFile.Replace(this.MapParameters, sbProperties.ToString());
        }

        private StringBuilder MergeMapsParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();

            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"{node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter()}: Convert.{node.Tag.ToString().FormatToDotNetType()}(reader[\"{node.Text.ToLower()}\"].ToString()),");
            }
            return partialMergeFile.Replace(this.MapsParameters, sbProperties.ToString());
        }

        #endregion


        #endregion


    }
}

