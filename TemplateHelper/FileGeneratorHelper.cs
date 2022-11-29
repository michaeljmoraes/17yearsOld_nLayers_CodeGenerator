using System;
using System.Text;
using System.Windows.Forms;

namespace ProductivityTools.CodeGenerator.Classes
{
    /// <summary>
    /// Summary description for GeraArquivo.
    /// </summary>
    public class FileGeneratorHelper
    {
        //private TreeNodeCollection AllNodes;

        public TreeNode SelectedNode { get; internal set; }

        public FileGeneratorHelper(TreeNode node)
        {
            this.SelectedNode = node;
        }

        public StringBuilder MergeAllAssets()
        {
            StringBuilder sbAll = new StringBuilder();
            sbAll.Append(this.MergeTemplateDomain());
            sbAll.Append(this.MergeTemplateData());
            sbAll.Append(this.MergeTemplateApplication());
            sbAll.Append(this.MergeTemplateDataBase());

            return sbAll;
        }

        public bool SaveAllAssets()
        {
            bool blnResult = false;
            blnResult = this.SaveMergedTemplateDomain();
            blnResult = this.SaveMergedTemplateData();
            blnResult = this.SaveMergedTemplateApplication();
            blnResult = this.SaveMergedTemplateWebApi();
            blnResult = this.SaveMergedTemplateDataBase();

            return blnResult;
        }

        #region Domain 

        /// <summary>
        /// Perform Domain Templates Merge
        /// </summary>
        /// <returns></returns>
        public StringBuilder MergeTemplateDomain()
        {
            StringBuilder sbMerged = new StringBuilder();

            //========== Domain ======================
            sbMerged.Append(new DomainModelGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new DomainRepositoryQueryInterfaceGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new DomainRepositoryCommandInterfaceGenerator(this.SelectedNode).MergeTemplate());

            return sbMerged;
        }

        /// <summary>
        /// Save Merged Template to Solution 
        /// </summary>
        /// <returns></returns>
        public bool SaveMergedTemplateDomain()
        {
            try
            {
                bool blnOK = false;

                blnOK = new DomainModelGenerator(this.SelectedNode).SaveToFile();
                blnOK = new DomainRepositoryCommandInterfaceGenerator(this.SelectedNode).SaveToFile();
                blnOK = new DomainRepositoryQueryInterfaceGenerator(this.SelectedNode).SaveToFile();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Data

        /// <summary>
        /// Perform Data Templates Merge
        /// </summary>
        /// <returns></returns>
        public StringBuilder MergeTemplateData()
        {
            StringBuilder sbMerged = new StringBuilder();

            //========== Domain ======================
            sbMerged.Append(new DataCommandsRepositoryGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new DataQueryRepostiroyGenerator(this.SelectedNode).MergeTemplate());


            return sbMerged;
        }

        /// <summary>
        /// Save Merged Template to Solution 
        /// </summary>
        /// <returns></returns>
        public bool SaveMergedTemplateData()
        {
            try
            {
                bool blnOK = false;

                blnOK = new DataCommandsRepositoryGenerator(this.SelectedNode).SaveToFile();
                blnOK = new DataQueryRepostiroyGenerator(this.SelectedNode).SaveToFile();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Application

        /// <summary>
        /// Perform Data Templates Merge
        /// </summary>
        /// <returns></returns>
        public StringBuilder MergeTemplateApplication()
        {
            StringBuilder sbMerged = new StringBuilder();

            //========== Domain ======================
            sbMerged.Append(new AppViewModelGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new AppDomainServiceInterfaceGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new AppDomainServiceImplementationGenerator(this.SelectedNode).MergeTemplate());

            sbMerged.Append(new AppAutoMapperViewToDomainModelGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new AppAutoMapperDomainToViewModelGenerator(this.SelectedNode).MergeTemplate());

            return sbMerged;
        }

        /// <summary>
        /// Save Merged Template to Solution 
        /// </summary>
        /// <returns></returns>
        public bool SaveMergedTemplateApplication()
        {
            try
            {
                bool blnOK = false;

                blnOK = new AppViewModelGenerator(this.SelectedNode).SaveToFile();
                blnOK = new AppDomainServiceInterfaceGenerator(this.SelectedNode).SaveToFile();
                blnOK = new AppDomainServiceImplementationGenerator(this.SelectedNode).SaveToFile();

                blnOK = new AppAutoMapperViewToDomainModelGenerator(this.SelectedNode).SaveToFile();
                blnOK = new AppAutoMapperDomainToViewModelGenerator(this.SelectedNode).SaveToFile();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region WebApi

        /// <summary>
        /// Perform Data Templates Merge
        /// </summary>
        /// <returns></returns>
        public StringBuilder MergeTemplateWebApi()
        {
            StringBuilder sbMerged = new StringBuilder();

            //========== Domain ======================
            sbMerged.Append(new WebApiControllerGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new WebApiDependencyInjectionGenerator(this.SelectedNode).MergeTemplate());

            return sbMerged;
        }

        /// <summary>
        /// Save Merged Template to Solution 
        /// </summary>
        /// <returns></returns>
        public bool SaveMergedTemplateWebApi()
        {
            try
            {
                bool blnOK = false;

                blnOK = new WebApiControllerGenerator(this.SelectedNode).SaveToFile();
                blnOK = new WebApiDependencyInjectionGenerator(this.SelectedNode).SaveToFile();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion

        #region DataBase

        /// <summary>
        /// Perform Data Templates Merge
        /// </summary>
        /// <returns></returns>
        public StringBuilder MergeTemplateDataBase()
        {
            StringBuilder sbMerged = new StringBuilder();

            //========== Domain ======================
            sbMerged.Append(new DataBaseFunctionsGenerator(this.SelectedNode).MergeTemplate());
            sbMerged.Append(new DataBaseStoredProceduresGenerator(this.SelectedNode).MergeTemplate());

            return sbMerged;
        }

        /// <summary>
        /// Save Merged Template to Solution 
        /// </summary>
        /// <returns></returns>
        public bool SaveMergedTemplateDataBase()
        {
            try
            {
                bool blnOK = false;

                blnOK = new DataBaseFunctionsGenerator(this.SelectedNode).SaveToFile();
                blnOK = new DataBaseStoredProceduresGenerator(this.SelectedNode).SaveToFile();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion
    }
}
