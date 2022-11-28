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

    public class DomainModelGenerator : FileGeneratorBase, IFileGenerator
    {

        string DomainModel { get { return "{DomainModel}"; } }
        string DomainProperties { get { return "{DomainProperties}"; } }
        string DomainConstructorInsertParameters { get { return "{DomainConstructorInsertParameters}"; } }
        string DomainConstructorUpdateParameters { get { return "{DomainConstructorUpdateParameters}"; } }
        string DomainConstructorUpdateParametersToBase { get { return "{DomainConstructorUpdateParametersToBase}"; } }
        string DomainSettingProperties { get { return "{DomainSettingProperties}"; } }

        public DomainModelGenerator(TreeNode nodeCollection)  : base(nodeCollection)
        {
            base.TemplateFilePath = $"{CustomConfiguration.SolutionConfig.TemplateBasePath}" +
                $"{CustomConfiguration.DomainConfig.Models.TemplateFile}";

            base.TargetFile = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DomainConfig.Models.TargetPath}" +
                $"{CustomConfiguration.DomainConfig.Models.TargetFile.Replace(this.DomainModel, this.Domain)}";

            base.TargetPath = $"{CustomConfiguration.SolutionConfig.TargetBasePath}" +
                $"{CustomConfiguration.DomainConfig.Models.TargetPath}";

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
                sbTemplateMerged = MergeDomainProperties(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeDomainConstructorUpdateParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeDomainConstructorUpdateParametersToBase(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeDomainConstructorInsertParameters(sbTemplateMerged, this.SelectedNode.Nodes);
                sbTemplateMerged = MergeDomainSettingProperties(sbTemplateMerged, this.SelectedNode.Nodes);

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

        private StringBuilder MergeDomainProperties(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;

                sbProperties.AppendLine($"[Column(\"{node.Text}\")]");
                sbProperties.AppendLine($"public {node.Tag.ToString().FormatToDomainType()} {node.Text.FormatToCamelCaseRemoveUnderline()} {{ get; private set; }}");
                sbProperties.AppendLine();
            }
            return partialMergeFile.Replace(this.DomainProperties, sbProperties.ToString());
        }

        private StringBuilder MergeDomainConstructorInsertParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                string fieldType = node.Tag.ToString().FormatToDomainType();
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey))
                    fieldType = $"{fieldType}?";

                sbProperties.Append($"{fieldType} {node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter()},");
            }
            return partialMergeFile.Replace(this.DomainConstructorInsertParameters, sbProperties.ToString().Remove(sbProperties.ToString().LastIndexOf(","), 1));
        }

        private StringBuilder MergeDomainConstructorUpdateParameters(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                //if (node.Text.ToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                //if (node.Text.ToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.Append($"{node.Tag.ToString().FormatToDomainType()} {node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter()},");
            }
            return partialMergeFile.Replace(this.DomainConstructorUpdateParameters, sbProperties.ToString().Remove(sbProperties.ToString().LastIndexOf(","), 1));
        }

        private StringBuilder MergeDomainConstructorUpdateParametersToBase(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey)) continue;
                //if (node.Text.ToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampUpdate)) continue;
                //if (node.Text.ToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.TimeStampInsert)) continue;

                sbProperties.Append($" {node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter()},");
            }
            return partialMergeFile.Replace(this.DomainConstructorUpdateParametersToBase, sbProperties.ToString().Remove(sbProperties.ToString().LastIndexOf(","), 1));
        }


        private StringBuilder MergeDomainSettingProperties(StringBuilder partialMergeFile, TreeNodeCollection nodes)
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (TreeNode node in this.SelectedNode.Nodes)
            {
                string fieldName = node.Text.FormatToCamelCaseRemoveUnderline();
                string fieldValue = node.Text.FormatToCamelCaseRemoveUnderline().FormatToDomainParameter();
                if (node.Text.FormatToCamelCaseRemoveUnderline().Equals(CustomConfiguration.DomainConfig.Models.PrimaryKey))
                    fieldValue = $"{fieldValue}??0";

                sbProperties.AppendLine($"this.{fieldName} = {fieldValue};");
            }
            return partialMergeFile.Replace(this.DomainSettingProperties, sbProperties.ToString());
        }


        #endregion


        #endregion


    }
}

