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

namespace Procwork.CodeGenerator.Classes
{

	public class GeraArquivoEORO: FileGenerator
	{
		
		// Tipo de objeto a ser usado EO ou RO
		protected string Tipo = "";
		
		public GeraArquivoEORO()
		{
		}

		public GeraArquivoEORO(string tipo_)
		{
			this.Tipo = tipo_;
		}

		public string GeraArquivo()
		{
			try
			{
				#region Código da classe

				string strCodigo = "";
				
				strCodigo  = @"using System;
using System.Collections; 
using System.Data;
using Avanade.ACA.Data;
using Avanade.ACA.Data.CommandWriter;
using Carrefour.C4A.Attribute;
using Carrefour.C4A.Cache;
using Carrefour.C4A.BusinessComponents;
using Carrefour.C4A.PersistenceFunctions;
using Carrefour.C4A.PersistableObjectManager;
using Carrefour.Entidade.Corporativo.Seguranca.ControleAcesso;

namespace " + this.Namespace + @"
{
	/// <summary>
	/// Summary description for " + this.Classe + this.Tipo + @"
	/// </summary>
	public class " + this.Classe + this.Tipo + " : " + Convert.ToString((this.Tipo == "EO")?"AEntityObject":"AReportObject") + @"
	{
		#region campos privados
		" + this.ScriptCampos(enuTipoCampo.PropriedadesPrivadasEORO) + (char)13 + @"		
		#endregion

		#region construtores
		public " + this.Classe + this.Tipo + @"()
		{
			" + this.ScriptCampos(enuTipoCampo.ConstrutorEORO) + (char)13 + @"
		}
		#endregion

		#region Propriedades
		" + this.ScriptCampos(enuTipoCampo.AtributosEORO) + (char)13 + @"
		#endregion

		#region Metodo Publico
		" + this.ScriptGetDefatultMapper() + (char)13 + @"
		#endregion
	}
}
";
			  
				#endregion

				return strCodigo;

			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message,ex);
				return "";

			}
		}

		//public string ScriptCampos(enuTipoCampo tipocampo_)
		//{

		//	string strCampos = "" + (char)13;

		//	//foreach(TreeNode campo in this.ColecaoNodes.Nodes)
		//	//{
		//	//	if(tipocampo_ == enuTipoCampo.PropriedadesPrivadasEORO)
		//	//	{
		//	//		strCampos += "		" + this.AcertarNomeCampoPrivado(campo) + (char)13;
		//	//	}
		//	//	if(tipocampo_ == enuTipoCampo.ConstrutorEORO)
		//	//	{
		//	//		strCampos += "			" + this.AcertarNomeCampoConstrutor(campo) + (char)13;
		//	//	}
		//	//	if(tipocampo_ == enuTipoCampo.AtributosEORO)
		//	//	{
		//	//		strCampos += this.AcertarNomeCampoAtributo(campo) + (char)13;
		//	//	}

		//	//}
			
		//	return strCampos;
		//}

		private string AcertarNomeCampoPrivado(TreeNode noCampo_)
		{
			string strRetorno = "";

			string[] strTag = noCampo_.Tag.ToString().Split('|');
			string strDataType = this.ObterTipoCampo(strTag);

			switch(strDataType.ToLower())
			{

				case "long":
					strRetorno += " internal long _" + noCampo_.Text.ToLower().Replace("_","") + ";";
					break;
				case "float":
					strRetorno += " internal float _" + noCampo_.Text.ToLower().Replace("_","") + ";";
					break;
				case "string":
					strRetorno += " internal string _" + noCampo_.Text.ToLower().Replace("_","") + ";";
					break;
				case "date":
					strRetorno += " internal DateTime _" + noCampo_.Text.ToLower().Replace("_","") + ";";
					break;
				default:
					strRetorno += " internal string _" + noCampo_.Text.ToLower().Replace("_","") + ";";
					break;
			}
			
			return strRetorno;
		}
		
		
		private string AcertarNomeCampoConstrutor(TreeNode noCampo_)
		{
			string strRetorno = "";
			strRetorno = "_" + noCampo_.Text.Replace("_","").ToLower();

			string[] strTag = noCampo_.Tag.ToString().Split('|');
			string strDataType = this.ObterTipoCampo(strTag);

			switch(strDataType.ToLower())
			{

				case "long":
					strRetorno += " = long.MinValue;";
					break;
				case "float":
					strRetorno += " = float.MinValue;";
					break;
				case "string":
					strRetorno += " = string.Empty;";
					break;
				case "date":
					strRetorno += " = DateTime.MinValue;";
					break;
				default:
					strRetorno += " = string.Empty;";
					break;
			}
			
			return strRetorno;
		}

		
		private string AcertarNomeCampoAtributo(TreeNode noCampo_)
		{

			
			string strRetorno = "";
			string[] strCampo = noCampo_.Text.Split('_');

			string[] strTag = noCampo_.Tag.ToString().Split('|');
			string strDataType = this.ObterTipoCampo(strTag);

			foreach(string campo in strCampo)
			{
				strRetorno += campo.Substring(0,1).ToUpper() + campo.Substring(1,campo.Length-1).ToLower();
			}
			
			switch(strDataType.ToLower())
			{

				case "long":
					strRetorno = @"
 
		public long " + strRetorno + @"
		{
			get { return this._" + strRetorno.ToLower() + @"; }
			set { this._" + strRetorno.ToLower() + @" = value; }
		}

		";
					break;

				case "float":
					strRetorno = @"
 
		public float " + strRetorno + @"
		{
			get { return this._" + strRetorno.ToLower() + @"; }
			set { this._" + strRetorno.ToLower() + @" = value; }
		}

		";

					break;

				case "string":
					strRetorno = @"

		public string " + strRetorno + @"
		{
			get { return this._" + strRetorno.ToLower() + @"; }
			set { this._" + strRetorno.ToLower() + @" = value; }
		}

		";

					break;
				case "date":
					strRetorno = @"

		public DateTime " + strRetorno + @"
		{
			get { return this._" + strRetorno.ToLower() + @"; }
			set { this._" + strRetorno.ToLower() + @" = value; }
		}

		";

					break;
				default:
					strRetorno = @"

		public string " + strRetorno + @"
		{
			get { return this._" + strRetorno.ToLower() + @"; }
			set { this._" + strRetorno.ToLower() + @" = value; }
		}
		
		";
					break;
			}
			
			return strRetorno;
		}
		
		
//		private string AcertarNomeCampo(TreeNode noCampo_)
//		{
//			string strRetorno = this.GerarNomeCampoClasse(noCampo_.Text);
//
//			string[] strTag = noCampo_.Tag.ToString().Split('|');
//			string strDataType = this.ObterTipoCampo(strTag);
//
//			switch(strDataType.ToLower())
//			{
//
//				case "long":
//					strRetorno += " = rs.GetLong(\"" + noCampo_.Text + "\");";
//					break;
//				case "float":
//					strRetorno += " = rs.GetFloat(\"" + noCampo_.Text + "\");";
//					break;
//				case "string":
//					strRetorno += " = rs.GetString(\"" + noCampo_.Text + "\");";
//					break;
//				case "date":
//					strRetorno += " = rs.GetDateTime(\"" + noCampo_.Text + "\");";
//					break;
//				default:
//					strRetorno += " = rs.GetString(\"" + noCampo_.Text + "\");";
//					break;
//			}
//			
//			return strRetorno;
//		}

		
		public string ScriptGetDefatultMapper()
		{
		
			string strQuery = "";
			strQuery += @"

		public override IMapper GetDefaultMapper()
		{
			IMapper mapper = (IMapper) CacheManager.GetValue(""" + this.Classe + this.Tipo + @""", ""Mapper"");
			if(mapper == null)
			{
				mapper = new " + this.Classe + @"Mapper(this.GetType());
				CacheManager.SetValue(""" + this.Classe + this.Tipo + @""", ""Mapper"", mapper, -1);
			}
			return mapper;
		} 

";
  
			return strQuery;

		}

	}
}

