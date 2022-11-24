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

namespace Procwork.CodeGenerator.Classes
{
	/// <summary>
	/// Summary description for GeraArquivo.
	/// </summary>
	public class GeraArquivo
	{

		#region Propriedades

		public bool GeraMetodoObter = true;
		public bool GeraMetodoObterTodos = true;
		public bool GeraMetodoRemover = true;
		public bool GeraMetodoPersistir = true;

		public TreeNode trnProcedureSelect;
		public TreeNode trnProcedureInsert;
		public TreeNode trnProcedureUpdate;
		public TreeNode trnProcedureDelete;

		public string CampoTimeStamp = "";

		#endregion
		
		#region Atributos

		public TreeNode ColecaoNodes;
		
		private string m_Classe;
		public string Classe
		{
			get {return m_Classe; } 
			set { m_Classe = value; }
		}

		private string m_Namespace;
		public string Namespace
		{
			get {return m_Namespace; } 
			set { m_Namespace = value; }
		}

		private string m_CaminhoSaida;
		public string CaminhoSaida
		{
			get {return m_CaminhoSaida; } 
			set { m_CaminhoSaida = value; }
		}

		// OPCOES DE GERACAO DO ARQUIVO
		private bool m_GeraKeySelectCommand;
		public bool GeraKeySelectCommand
		{
			get {return m_GeraKeySelectCommand; } 
			set { m_GeraKeySelectCommand = value; }
		}
		
		private bool m_GeraInsertCommand;
		public bool GeraInsertCommand
		{
			get {return m_GeraInsertCommand; } 
			set { m_GeraInsertCommand = value; }
		}

		private bool m_GeraUpdateCommand;
		public bool GeraUpdateCommand
		{
			get {return m_GeraUpdateCommand; } 
			set { m_GeraUpdateCommand = value; }
		}
		
		private bool m_GeraDeleteCommand;
		public bool GeraDeleteCommand
		{
			get {return m_GeraDeleteCommand; } 
			set { m_GeraDeleteCommand = value; }
		}

		#endregion
		
		public GeraArquivo()
		{
		}

		public bool GerarMapper()
		{
			try
			{
				
				StreamWriter arquivo = new StreamWriter(this.CaminhoSaida + "\\" + this.Classe + "Mapper.cs");
				
				string strArquivo = this.VisualizarMapper();

				arquivo.Write(strArquivo);

				arquivo.Close();
				arquivo = null;
				
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;

		}


		/// <summary>
		/// Otem o conteudo do arquivo para visualizacao
		/// </summary>
		/// <returns></returns>
		public string VisualizarMapper()
		{
			try
			{
				GeraArquivoMapper mapper = new GeraArquivoMapper();
				mapper.Namespace = this.Namespace;
				mapper.Classe = this.Classe;
				mapper.ColecaoNodes = this.ColecaoNodes;

				mapper.GeraKeySelectCommand = this.GeraKeySelectCommand;
				mapper.GeraInsertCommand = this.GeraInsertCommand;
				mapper.GeraUpdateCommand = this.GeraUpdateCommand;
				mapper.GeraDeleteCommand = this.GeraDeleteCommand;

				mapper.trnProcedureSelect = this.trnProcedureSelect;
				mapper.trnProcedureInsert = this.trnProcedureInsert;
				mapper.trnProcedureUpdate = this.trnProcedureUpdate;
				mapper.trnProcedureDelete = this.trnProcedureDelete;

				mapper.CampoTimeStamp = this.CampoTimeStamp;
				
				string strPreview = mapper.GeraArquivo();

				return strPreview;
			}
			catch(Exception ex)
			{
				return "";
			}
		}
		

		public bool GerarEORO(string tipo_)
		{
			try
			{

				StreamWriter arquivo = new StreamWriter(this.CaminhoSaida + "\\" + this.Classe + tipo_ + ".cs");
				
				string strArquivo = this.VisualizarEORO(tipo_);
				arquivo.Write(strArquivo);

				arquivo.Close();
				arquivo = null;
				
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;

		}


		public bool GerarEO()
		{
			return this.GerarEORO("EO");

		}


		public string VisualizarEORO(string tipo_)
		{
			try
			{
				GeraArquivoEORO EORO = new GeraArquivoEORO(tipo_);
				EORO.Namespace = this.Namespace;
				EORO.Classe = this.Classe;
				EORO.ColecaoNodes = this.ColecaoNodes;

				if(tipo_ == "EO") 
				{
					EORO.GeraKeySelectCommand = this.GeraKeySelectCommand;
					EORO.GeraInsertCommand = this.GeraInsertCommand;
					EORO.GeraUpdateCommand = this.GeraUpdateCommand;
					EORO.GeraDeleteCommand = this.GeraDeleteCommand;
				}
				
				string strPreview = EORO.GeraArquivo();

				return strPreview;
			}
			catch(Exception ex)
			{
				return "";
			}

		}
		
		public string VisualizarEO()
		{
			return this.VisualizarEORO("EO");
		}

		public bool GerarRO()
		{
			return this.GerarEORO("RO");
		}


		public string VisualizarRO()
		{
			return this.VisualizarEORO("RO");
		}


		public string ObterTipoCampo(string[] tag_)
		{

			string strRetorno = "";
			string strDataType = tag_[0];
			string strDataLength = tag_[1];
			string strDataScale = tag_[2];

			switch(strDataType.ToLower())
			{

				case "number":
					if(strDataScale == "0" || strDataScale == "")
					{
						strRetorno += "long";
					}
					else
					{
						strRetorno += "float";
					}
					break;
				case "varchar2":
					strRetorno += "string";
					break;
				case "date":
					strRetorno += "date";
					break;
				default:
					strRetorno += "string";
					break;
			}
			
			return strRetorno;

		}
		
		public bool GerarBC()
		{
			try
			{
				StreamWriter arquivo = new StreamWriter(this.CaminhoSaida + "\\" + this.Classe + "BC.cs");
				
				string strArquivo = this.VisualizarBC();

				arquivo.Write(strArquivo);

				arquivo.Close();
				arquivo = null;
				
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}


		public string VisualizarBC()
		{
			try
			{
				GeraArquivoBC BC = new GeraArquivoBC();
				BC.Namespace = this.Namespace;
				BC.Classe = this.Classe;
				BC.ColecaoNodes = this.ColecaoNodes;

				BC.GeraMetodoObter = this.GeraMetodoObter;
				BC.GeraMetodoObterTodos = this.GeraMetodoObterTodos;
				BC.GeraMetodoPersistir = this.GeraMetodoPersistir;
				BC.GeraMetodoRemover = this.GeraMetodoRemover;

				string strPreview = BC.GeraArquivo();

				return strPreview;
			}
			catch(Exception ex)
			{
				return "";
			}
		}
		
		public enum enuTipoCampo
		{
			CamposMapper = 0,
			PropriedadesPrivadasEORO = 1,
			ConstrutorEORO =2,
			AtributosEORO = 3
		}

		protected string GerarNomeCampoClasse(string nomecampobanco_)
		{
			string strRetorno = "";
			if(nomecampobanco_ != "")
			{
				string[] strCampo = nomecampobanco_.Split('_');

				foreach(string campo in strCampo)
				{
					strRetorno += campo.Substring(0,1).ToUpper() + campo.Substring(1,campo.Length-1).ToLower();
				}
			}

			return strRetorno;
		}

		public string ObterNomeCampo(string nomecampo_)
		{
			string strRetorno = "";
			string[] strCampo = nomecampo_.Split('_');
											
			foreach(string campo in strCampo)
			{
				if(campo != "V")
					strRetorno += campo.Substring(0,1).ToUpper() + campo.Substring(1,campo.Length-1).ToLower();
			}

			return strRetorno;
		}


	}
}
