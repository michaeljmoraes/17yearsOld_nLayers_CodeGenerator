using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Procwork.CodeGenerator.TemplateHelper.Base;
using Procwork.CodeGenerator.Extensions;

namespace Procwork.CodeGenerator.Classes
{
    /// <summary>
    /// Summary description for GeraArquivo.
    /// </summary>
    public abstract class FileGeneratorBase : IFileGenerator
    {
        protected virtual string Domain { get; set; }

        public virtual TreeNode SelectedNode { get; set; }
        public virtual StringBuilder TemplateFileContent { get; set; } = new StringBuilder();
        public virtual string TemplateFilePath { get; set; } = String.Empty;
        
        public virtual string TargetPath { get; set; } = String.Empty;
        public virtual string TargetFile { get; set; } = String.Empty;

        //public FileGeneratorBase() { }

        public FileGeneratorBase(TreeNode nodeCollection)
        {
            this.SelectedNode = nodeCollection;
            Domain = this.SelectedNode.Text.FormatToCamelCaseRemoveUnderline();
            SelectedNode = nodeCollection;
        }

        public virtual void SetTemplateFile()
        {
            try
            {
                if (!File.Exists(TemplateFilePath) && !CustomConfiguration.SolutionConfig.ForceCreateFile) throw new FileNotFoundException(TemplateFilePath);
                TemplateFileContent.Clear();
                TemplateFileContent.Append(File.ReadAllText(TemplateFilePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool SaveToFile()
        {
            try
            {

                StringBuilder mergedTemplate = MergeTemplate();

                if (File.Exists(TargetFile) && !CustomConfiguration.SolutionConfig.ForceCreateFile) throw new Exception($"File already exist: {TargetFile}");

                if (!Directory.Exists(TargetPath) && CustomConfiguration.SolutionConfig.ForceCreateFolder)
                    Directory.CreateDirectory(TargetPath);

                StreamWriter file = new StreamWriter(TargetFile);

                file.Write(mergedTemplate.ToString());

                file.Close();
                file = null;

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool AppendToClass(string appendTag)
        {
            try
            {
                StringBuilder mergedTemplate = MergeTemplate();

                mergedTemplate.AppendLine();
                mergedTemplate.AppendLine(appendTag);
                mergedTemplate.AppendLine();

                if (!File.Exists(TargetFile)) throw new FileNotFoundException($"{TargetFile}");

                StreamReader reader = new StreamReader(this.TargetFile);
                StringBuilder sbAllText = new StringBuilder(reader.ReadToEnd());
                sbAllText.Replace(appendTag, mergedTemplate.ToString());

                reader.Close();
                reader = null;

                StreamWriter writter = new StreamWriter(TargetFile);
                writter.Write(sbAllText.ToString());
                writter.Close();
                writter = null;

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual StringBuilder MergeTemplate() => throw new NotImplementedException();

    }
}
