using ProductivityTools.CodeGenerator.Extensions;
using ProductivityTools.CodeGenerator.TemplateHelper.Base;
using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{

    public class DataBaseStoredProceduresGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel => "{DomainModel}";
        string DomainModelSP => "{entity_domain}";

        string InsertParameters => "{insert_parameters}";
        string InsertFields => "{insert_fields}";
        string InsertValues => "{insert_values}";

        string UpdateParameters => "{update_parameters}";
        string UpdateValues => "{update_values}";




        public DataBaseStoredProceduresGenerator(TreeNode nodeCollection) : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.StoredProcedures.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.StoredProcedures.TargetPath}" +
                $"{CustomConfiguration.DataBaseConfig.StoredProcedures.TargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DataBaseConfig.StoredProcedures.TargetPath}";

            base.SetTemplateFile();
        }

        #region Template Merge

        public override StringBuilder MergeTemplate()
        {
            try
            {
                StringBuilder sbTemplateMerged = TemplateFileContent;

                sbTemplateMerged = MergeDomainModel(sbTemplateMerged, this.SelectedNode.Text);
                sbTemplateMerged = MergeDomainModelSP(sbTemplateMerged, this.SelectedNode.Text);

                sbTemplateMerged = MergeInsertParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeInsertFields(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeInsertValues(sbTemplateMerged, this.SelectedNode.Nodes);

                sbTemplateMerged = MergeUpdateParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeUpdateValues(sbTemplateMerged, this.SelectedNode.Nodes);


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
            partialMergeFile.Replace(this.DomainModel, Domain.ToLower());
            return partialMergeFile;
        }

        private StringBuilder MergeDomainModelSP(StringBuilder partialMergeFile, string domainName)
        {
            partialMergeFile.Replace(this.DomainModelSP, base.SelectedNode.Text);
            return partialMergeFile;
        }



        private StringBuilder MergeInsertParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                if (node.Tag.ToString().FormatToSPParameterType().Equals("VARCHAR"))
                    sbProperties.AppendLine($"_{node.Text} {node.Tag.ToString().FormatToSPParameterType()}({node.ToolTipText}),");
                else
                    sbProperties.AppendLine($"_{node.Text} {node.Tag.ToString().FormatToSPParameterType()},");
            }

            return partialMergeFile.Replace(this.InsertParameters, sbProperties.ToString());
        }


        private StringBuilder MergeInsertFields(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"{node.Text},");
            }

            return partialMergeFile.Replace(this.InsertFields, sbProperties.ToString());
        }



        private StringBuilder MergeInsertValues(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.AppendLine($"_{node.Text},");
            }
            return partialMergeFile.Replace(this.InsertValues, sbProperties.ToString());
        }



        private StringBuilder MergeUpdateParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                if (node.Tag.ToString().FormatToSPParameterType().Equals("VARCHAR"))
                    sbProperties.AppendLine($"_{node.Text} {node.Tag.ToString().FormatToSPParameterType()}({node.ToolTipText}),");
                else
                    sbProperties.AppendLine($"_{node.Text} {node.Tag.ToString().FormatToSPParameterType()},");

            }
            return partialMergeFile.Replace(this.UpdateParameters, sbProperties.ToString());
        }


        private StringBuilder MergeUpdateValues(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;
                sbProperties.AppendLine($"{node.Text} = _{node.Text},");
            }
            return partialMergeFile.Replace(this.UpdateValues, sbProperties.ToString());
        }


        #endregion


        #endregion


    }
}

