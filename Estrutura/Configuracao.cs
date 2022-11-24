using System;
using System.Xml;

namespace Procwork.CodeGenerator
{
	/// <summary>
	/// Summary description for Configuracao.
	/// </summary>
	public class Configuracao
	{
		public Configuracao()
		{

		}

		public string ObterParametroDoXML(string parametro_)
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
