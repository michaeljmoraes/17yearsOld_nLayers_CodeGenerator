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

	public class GeraArquivoBC: GeraArquivo
	{

//		private string m_campochavebanco = "";
//		public string CampoChaveBanco
//		{
//			get { return m_campochavebanco; }
//			set { m_campochavebanco = value; }
//		}
//
//		private string m_campochaveclasse = "";
//		public string CampoChaveClasse
//		{
//			get { return m_campochaveclasse; }
//			set { m_campochaveclasse = value; }
//		}

		public bool GeraMetodoObter = true;
		public bool GeraMetodoObterTodos = true;
		public bool GeraMetodoRemover = true;
		public bool GeraMetodoPersistir = true;

		public GeraArquivoBC()
		{
		}

		public string GeraArquivo()
		{
			try
			{
				#region Código da classe

				string strCodigo = "";
				
				strCodigo  = @"using System;
using System.Collections;
using System.EnterpriseServices;
using Carrefour.C4A.BusinessComponents;
using Carrefour.C4A.HelperFunctions;
using Carrefour.C4A.PersistenceFunctions;
using Carrefour.C4A.PersistableObjectManager;
using Carrefour.C4A.DataFilter;

namespace " + this.Namespace + @"
{
	[Transaction(TransactionOption.Supported)]
	public class " + this.Classe + @"BC : ABusinessComponent
	{
		public " + this.Classe + @"BC()
		{
		}
	
		" + this.ScriptObterTodos() + @" 

		#region Metodos Publicos

		" + this.ScriptObter() + @"
		" + this.ScriptPersistir() + @"
		" + this.ScriptRemover() + @"

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

		public string ScriptObter()
		{
			string strQuery = "";

			if(this.GeraMetodoObter) 
			{

				strQuery = @"

		public " + this.Classe + @"EO Obter(" + this.Classe + @"EO objEO_)
		{
			" + this.Classe + @"EO ret = new " + this.Classe + @"EO();
			PersistableObjectManagerNonTX pom = new PersistableObjectManagerNonTX();
			try
			{
				ret = (" + this.Classe + @"EO)pom.Retrieve(ret.GetDefaultMapper(), objEO_); 
			}
			finally
			{
				pom.Dispose();
			}
			return ret;
		}

			";

			}

			return strQuery;
		}

		
		public string ScriptObterTodos()
		{
			string strQuery = "";

			if(this.GeraMetodoObterTodos) 
			{

				strQuery = @"

		public ArrayList ObterTodos()
		{
			ArrayList ret = new ArrayList();
			" + this.Classe + @"EO objEO = new " + this.Classe + @"EO();
			PersistableObjectManagerNonTX pom = new PersistableObjectManagerNonTX();
			Criteria criteria = new Criteria();
			try
			{
				ret = pom.Retrieve(objEO.GetDefaultMapper()
					             , criteria
					             , false
					             , """"
					             , """"
					             , """"
					             , false);
			}
			finally
			{
				pom.Dispose();
			}
			return ret;
		}

			";
			
			}

			return strQuery;
		}


		public string ScriptPersistir()
		{
		
			string strQuery = "";

			if(this.GeraMetodoPersistir) 
			{

			
				strQuery += @"

		public " + this.Classe + @"EO Persistir(string usuario, " + this.Classe + @"EO objEO_)
		{
			PersistableObjectManagerTX pom = new PersistableObjectManagerTX();
			try
			{
				objEO_ = (" + this.Classe + @"EO) pom.Persist(usuario, objEO_);
			}
			finally
			{
				pom.Dispose();
			}
			
			return objEO_;

		}

	";
			}
			return strQuery;

		}


		public string ScriptRemover()
		{
			string strQuery = "";

			if(this.GeraMetodoRemover) 
			{

				strQuery = @"

		public void Remover(string usuario, " + this.Classe + @"EO objEO_)
		{
			objEO_.Delete();
			BCHelper.Persist(usuario, objEO_);
		}

		";

			}
			return strQuery;

		}


		

	}
}

