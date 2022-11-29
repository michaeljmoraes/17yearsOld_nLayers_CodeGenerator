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

namespace ProductivityTools.CodeGenerator.Classes
{

	public class GeraArquivoMapper: FileGenerator
	{
		
		public TreeNode trnProcedureSelect;
		public TreeNode trnProcedureInsert;
		public TreeNode trnProcedureUpdate;
		public TreeNode trnProcedureDelete;
		
		public GeraArquivoMapper()
		{
		}

		public string GeraArquivo()
		{
			try
			{
				#region Código da classe

				string strCodigo = "";
				
				strCodigo  = @"using System;
using System.Data;
using Avanade.ACA.Data;
using Avanade.ACA.Data.CommandWriter;
using Carrefour.Entidade.Corporativo.Seguranca.ControleAcesso;
using Carrefour.C4A.BusinessComponents;
using Carrefour.C4A.PersistenceFunctions;
using Carrefour.C4A.PersistableObjectManager;
using System.Collections;

namespace " + this.Namespace + @" 
{
	/// <summary>
	/// " + this.Classe + @"Mapper
	/// </summary>
	/// <remarks>
	/// @LastUpdate: " + DateTime.Now.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToString("hh:mm") + @"
	/// </remarks>	
	public class " + this.Classe + @"Mapper : AMapper
	{
		public " + this.Classe + @"Mapper(System.Type objType_): base(objType_)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override IDbObject ConvertFromDB(ResultSetRow rs_)
		{
			" + this.Classe + @"EO objEO = new " + this.Classe + @"EO();
			" + this.ScriptCampos() + @"

			return objEO;
		}

		public override string GetDefaultQuery()
		{
			string SQL = @""" + (char)13 + this.ScriptGetDefatultQuery() + @""";
			return SQL;
		}

		public override string GetDefaultCountQuery()
		{
			return """";
		}
		" + (char)13 + this.ScriptCommands() + @"

	}

}";

				#endregion

				return strCodigo;

			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message,ex);
				return "";

			}
		}

		public string ScriptCampos()
		{
			string strCampos = "" + (char)13;

			//foreach(TreeNode campo in this.ColecaoNodes.Nodes)
			//{
			//	strCampos += "			objEO." + this.AcertarNomeCampo(campo) + (char)13;
			//}
			
			return strCampos;
		}

		private string AcertarNomeCampo(TreeNode noCampo_)
		{
			string strRetorno = "";
			string[] strTag = noCampo_.Tag.ToString().Split('|');
			
			string strDataType = this.ObterTipoCampo(strTag);

			string[] strCampo = noCampo_.Text.Split('_');

			strRetorno = this.ObterNomeCampo(noCampo_.Text);
			
			switch(strDataType.ToLower())
			{

				case "long":
					strRetorno += " = rs_.GetLong(\"" + noCampo_.Text + "\");";
					break;
				case "float":
					strRetorno += " = Convert.ToSingle(rs_.GetFloat(\"" + noCampo_.Text + "\"));";
					break;
				case "string":
					strRetorno += " = rs_.GetString(\"" + noCampo_.Text + "\");";
					break;
				case "date":
					strRetorno += " = rs_.GetDate(\"" + noCampo_.Text + "\");";
					break;
				default:
					strRetorno += " = rs_.GetString(\"" + noCampo_.Text + "\");";
					break;
			}
			
			return strRetorno;
		}
		
		public string ScriptGetDefatultQuery()
		{
		
			string strQuery = "";
			//strQuery = "				SELECT " + (char)13;
			//foreach(TreeNode campo in this.ColecaoNodes.Nodes)
			//{
			//	strQuery += "						" + campo.Text  + ", " + (char)13;
			//}
			
			//strQuery = strQuery.Remove(strQuery.Length-3,3) + (char)13;
			
			//strQuery += "				 FROM " + this.ColecaoNodes.Text;

			return strQuery;

		}

		public string ScriptKeySelectCommand()
		{
			
			string strCommand = "";

				// -------------------------------------------
				// CODIGO A SER ESCRITO DO COMANDO KEY SELECT
				// -------------------------------------------
			if(this.GeraKeySelectCommand)
			{
				strCommand = @"

		public override IDbCommandWriter GetKeySelectCommand(IDbObject obj_)
		{
			" + this.Classe + @"EO obj = (" + this.Classe + @"EO) obj_;
			string sql = this.GetDefaultQuery(); 
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter(sql, CommandType.Text);
			return cw;

		} 

		";
				//--------------------------------------------
			}
			return strCommand;

		}
		
		public string ScriptInsertCommand()
		{
			string strCommand = "";

			if(this.GeraInsertCommand) 
			{
				// -------------------------------------------
				// CODIGO A SER ESCRITO DO COMANDO INSERT
				// -------------------------------------------
				strCommand = @"

		public override IDbCommandWriter GetInsertCommand(string userName_, IEntityObject obj_)
		{
			" + this.Classe + @"EO obj = (" + this.Classe + @"EO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter(""" + this.trnProcedureInsert.Text + @""", CommandType.StoredProcedure);
			" + this.ScriptCamposInsert() + @" 
			return cw;	
		}

		";
				//--------------------------------------------
			}
			return strCommand;

		}

		public string ScriptUpdateCommand()
		{
			string strCommand = "";

			if(this.GeraUpdateCommand) 
			{
				// -------------------------------------------
				// CODIGO A SER ESCRITO DO COMANDO UPDATE
				// -------------------------------------------
				strCommand = @"

		public override IDbCommandWriter GetUpdateCommand(string userName_, IEntityObject obj_)
		{
			" + this.Classe + @"EO obj = (" + this.Classe + @"EO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter(""" + this.trnProcedureUpdate.Text + @""", CommandType.StoredProcedure);
			" + this.ScriptCamposUpdate() + @"
			return cw;	
		}

		";
				//--------------------------------------------
			}
			return strCommand;

		}

		public string ScriptDeleteCommand()
		{
			string strCommand = "";

			if(this.GeraDeleteCommand) 
			{
				// -------------------------------------------
				// CODIGO A SER ESCRITO DO COMANDO DELETE
				// -------------------------------------------
				strCommand = @"

		public override IDbCommandWriter GetDeleteCommand(string userName_, IEntityObject obj_)
		{
			" + this.Classe + @"EO obj = (" + this.Classe + @"EO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter(""" + this.trnProcedureDelete.Text + @""", CommandType.StoredProcedure);
			" + this.ScriptCamposDelete() + @"
			return cw;	
		}

		";
				//--------------------------------------------
			}
			return strCommand;

		}


		public string ScriptCommands()
		{
			string strCommand = "";

			strCommand += this.ScriptInsertCommand();

			strCommand += this.ScriptUpdateCommand();

			strCommand += this.ScriptDeleteCommand();

			return strCommand;

		}

		public string ScriptCampos(TreeNode procedure_)
		{
			string strCampos = "";
			string strDBType = "";
			string strDBLength = "";
			string strDBScale = "";
			string strINOUT = "";
			string strSetOnDB = "";
			string strCampoClasse= "";

			foreach(TreeNode campo in procedure_.Nodes)
			{
				string[] strTag = campo.Tag.ToString().Split('|');
				
				strDBType = strTag[0];
				strDBLength = strTag[1];
				strDBScale = strTag[2];
				strINOUT = strTag[3];
				strCampoClasse = this.ObterNomeCampo(campo.Text);
				/*
				 SetDateTimeOnDB 
				 SetDecimalOnDB 
				 SetDoubleOnDB 
				 SetIntOnDB 
				 SetLongOnDB 
				 SetSafeOnDB 
				 SetShortOnDB
				 SetSingleOnDB 
				 SetStringOnDB 
				 */

				switch(strDBType.ToLower())
				{

					case "number":
						if(strDBScale == "")
						{
							strDBType = "Int64";
							strSetOnDB = "SetLongOnDB";
						}
						else
						{
							strDBType = "Double";
							strSetOnDB = "SetDoubleOnDB";
						}
						break;
					case "varchar2":
						strDBType = "String";
						strSetOnDB = "SetStringOnDB";
						break;
					case "date":
						strDBType = "DateTime";
						strSetOnDB = "SetDateTimeOnDB";
						break;
					default:
						strDBType = "String";
						strSetOnDB = "SetStringOnDB";
						break;
				}

				if(strINOUT == "IN")
				{
					strCampos += @"cw.AddInParam(""" + campo.Text + @""", DbType." + strDBType + @",PersistenceHelper." + strSetOnDB + @"(obj." + strCampoClasse + @"));
			";
				}
				else
				{
					if(campo.Text.Substring(2) == this.CampoTimeStamp) strCampoClasse = "TimeStamp";
					strCampos += @"cw.AddParam(""" + campo.Text + @""", DbType." + strDBType + @", ParameterDirection.InputOutput, """ + campo.Text + @""", DataRowVersion.Default, obj." + strCampoClasse + @");
			";

				}
			}
			return strCampos;

		}

		public string ScriptCamposSelect()
		{
			return this.ScriptCampos(this.trnProcedureSelect);
		}
		
		public string ScriptCamposInsert()
		{
			return this.ScriptCampos(this.trnProcedureInsert);
		}


		public string ScriptCamposUpdate()
		{
			return this.ScriptCampos(this.trnProcedureUpdate);
		}


		public string ScriptCamposDelete()
		{
			return this.ScriptCampos(this.trnProcedureDelete);
		}


	}
}

