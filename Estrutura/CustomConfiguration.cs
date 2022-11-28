using System;
using System.Collections;
using System.Configuration;
using System.Xml;

namespace Procwork.CodeGenerator
{


    /// <summary>
    /// Summary description for Configuration.
    /// </summary>
    public static class CustomConfiguration
	{

        
        public static string GetConnectionString()
		{
            string strConnectionstring = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString; //"Host=localhost;Username=postgres;Password=cyber2010!;Database=dbdocstorage01;Port=5433;Pooling=true;SearchPath=public;IncludeErrorDetails=true";
			return strConnectionstring;
        }

        #region Solution Definitions
        public static class SolutionConfig
        {
            static IDictionary config = GetSectionConfig("Solution");
            public static string BaseNameSpace
            {
                get { return Convert.ToString(config["baseNameSpace"]); }
            }
            
            public static string TargetBasePath
            {
                get { return Convert.ToString(config["targetBasePath"]); }
            }

            public static string TemplateBasePath
            {
                get { return Convert.ToString(config["templateBasePath"]); }
            }

            public static bool ForceCreateFolder
            {
                get { return Convert.ToBoolean(config["forceCreateFolder"]); }
            }

            public static bool ForceCreateFile
            {
                get { return Convert.ToBoolean(config["forceCreateFile"]); }
            }
        }

        #endregion

        #region Domain Definitions
        public static class DomainConfig
        {
            public static class Models
            {
                static IDictionary config = GetSectionConfig("Domain.Models");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static string PrimaryKey
                {
                    get { return Convert.ToString(config["primaryKey"]); }
                }

                public static string TimeStampInsert
                {
                    get { return Convert.ToString(config["timeStampInsert"]); }
                }

                public static string TimeStampUpdate
                {
                    get { return Convert.ToString(config["timeStampUpdate"]); }
                }

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }
            }

            public static class RepositoryInterfaces
            {
                static IDictionary config = GetSectionConfig("Domain.RepositoryInterfaces");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                /// <summary>
                /// This property need to replace {0} to domain
                /// </summary>
                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static bool GenerateQuery
                {
                    get { return Convert.ToBoolean(config["generateQuery"]); }
                }

                public static bool GenerateCommands
                {
                    get { return Convert.ToBoolean(config["generateCommands"]); }
                }

                public static string QueryTemplateFile
                {
                    get { return Convert.ToString(config["queryTemplateFile"]); }
                }

                public static string CommandsTemplateFile
                {
                    get { return Convert.ToString(config["commandsTemplateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string QueryTargetFile
                {
                    get { return Convert.ToString(config["queryTargetFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string CommandsTargetFile
                {
                    get { return Convert.ToString(config["commandsTargetFile"]); }

                }
            }
        }

        #endregion

        #region Data Definitions
        public static class DataConfig
        {
            public static class Migration
            {
                static IDictionary config = GetSectionConfig("Data.Migration");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }
                
                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }
            }

            public static class RepositoryImplementation
            {
                static IDictionary config = GetSectionConfig("Data.RepositoryImplementation");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static bool GenerateQuery
                {
                    get { return Convert.ToBoolean(config["generateQuery"]); }
                }

                public static bool GenerateCommands
                {
                    get { return Convert.ToBoolean(config["generateComands"]); }
                }

                public static string QueryTemplateFile
                {
                    get { return Convert.ToString(config["queryTemplateFile"]); }
                }

                public static string CommandsTemplateFile
                {
                    get { return Convert.ToString(config["commandsTemplateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string QueryTargetFile
                {
                    get { return Convert.ToString(config["queryTargetFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string CommandsTargetFile
                {
                    get { return Convert.ToString(config["commandsTargetFile"]); }
                }
            }
        }

        #endregion

        #region Application Definitions
        public static class ApplicationConfig
        {
            public static class ViewModels
            {
                static IDictionary config = GetSectionConfig("Application.ViewModels");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }
            }

            public static class DomainAppService
            {
                static IDictionary config = GetSectionConfig("Application.DomainAppService");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static bool GenerateInterface
                {
                    get { return Convert.ToBoolean(config["generateInterface"]); }
                }

                public static bool GenerateImplementation
                {
                    get { return Convert.ToBoolean(config["generateImplementation"]); }
                }
                
                public static string InterfaceTemplateFile
                {
                    get { return Convert.ToString(config["interfaceTemplateFile"]); }
                }

                public static string ImplementationTemplateFile
                {
                    get { return Convert.ToString(config["implementationTemplateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string InterfaceTargetFile
                {
                    get { return Convert.ToString(config["interfaceTargetFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string ImplementationTargetFile
                {
                    get { return Convert.ToString(config["implementationTargetFile"]); }
                }
            }

            public static class AutoMapper
            {
                static IDictionary config = GetSectionConfig("Application.AutoMapper");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static string DomainToViewTargetFile
                {
                    get { return Convert.ToString(config["domainToViewTargetFile"]); }
                }

                public static string ViewToDomainTargetFile
                {
                    get { return Convert.ToString(config["viewToDomainTargetFile"]); }
                }


                public static string DomainToViewTemplateFile
                {
                    get { return Convert.ToString(config["domainToViewTemplateFile"]); }
                }

                public static string ViewToDomainTemplateFile
                {
                    get { return Convert.ToString(config["viewToDomainTemplateFile"]); }
                }


                public static string AppendTag
                {
                    get { return Convert.ToString(config["appendTagString"]); }
                }
            }
        }

        #endregion

        #region WebApi Definitions
        public static class WebApiConfig
        {
            public static class Controllers
            {
                static IDictionary config = GetSectionConfig("WebApi.Controllers");

                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{String.Format(Convert.ToString(config["nameSpace"]), ApiVersion)}"; }
                }


                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                /// <summary>
                /// This property need to replace {ApiVersion} to ApiVersion
                /// </summary>
                public static string ApiVersion
                {
                    get { return Convert.ToString(config["apiVersion"]); }
                }

                public static string ApiVersionNameSpace
                {
                    get { return Convert.ToString(config["apiVersionNameSpace"]); }
                }

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }
            }

            public static class DependencyInjection
            {
                static IDictionary config = GetSectionConfig("WebApi.DependencyInjection");
                public static string NameSpace
                {
                    get { return $"{SolutionConfig.BaseNameSpace}.{Convert.ToString(config["nameSpace"])}"; }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }

                public static string AppendTag
                {
                    get { return Convert.ToString(config["appendTagString"]); }
                }
            }
        }

        #endregion

        #region DataBase Definitions
        public static class DataBaseConfig
        {
            public static class StoredProcedures
            {
                static IDictionary config = GetSectionConfig("DataBase.StoredProcedures");

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }

            }

            public static class Functions
            {
                static IDictionary config = GetSectionConfig("DataBase.Functions");

                public static string TemplateFile
                {
                    get { return Convert.ToString(config["templateFile"]); }
                }

                public static string TargetPath
                {
                    get { return Convert.ToString(config["targetPath"]); }
                }

                /// <summary>
                /// This property need to replace {DomainModel} to domain
                /// </summary>
                public static string TargetFile
                {
                    get { return Convert.ToString(config["targetFile"]); }
                }
            }
        }

        #endregion

        private static IDictionary GetSectionConfig(string section)
        {
            IDictionary result = (IDictionary)ConfigurationManager.GetSection(section);
            return result;
        }



        public static string ObterParametroDoXML(string parametro_)
		{

			XmlTextReader xmlArquivo = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + "\\xml\\setup.xml") ;
			string strRetorno = "";
			while(xmlArquivo.Read())
			{
				
				if(xmlArquivo.NodeType == XmlNodeType.Element)
				{
					strRetorno = xmlArquivo[parametro_];
					if(strRetorno != "" && strRetorno != null) { break; } else { continue; };
				}
			}

			return strRetorno;

		}


	}

}
