using System;
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

namespace ProductivityTools
{
	/// <summary>
	/// Summary description for B_PROJTORO
	/// </summary>
	public class B_PROJTORO : AReportObject
	{
		#region campos privados
				 internal long _codprojto;		 internal long _anoprojto;		 internal string _indtipodestno;		 internal string _dscresum;		 internal string _nomrespns;		 internal DateTime _datinicl;		 internal DateTime _datfinal;		 internal string _nomareasolict;		 internal string _nomusuriosolict;		 internal long _codclassf;		 internal string _dscdtalhe;		 internal string _indvalid;		 internal string _nomusuriovalid;		 internal DateTime _datvalid;		 internal long _codsituac;		 internal string _indinterf;		 internal DateTime _datinterf;		 internal long _codarea;		 internal DateTime _datinclus;		 internal string _codusurioinclus;		 internal string _codusurioaltrac;		 internal DateTime _dataltrac;		 internal DateTime _datatualizacao;		
		#endregion

		#region construtores
		public B_PROJTORO()
		{
						_codprojto = long.MinValue;			_anoprojto = long.MinValue;			_indtipodestno = string.Empty;			_dscresum = string.Empty;			_nomrespns = string.Empty;			_datinicl = DateTime.MinValue;			_datfinal = DateTime.MinValue;			_nomareasolict = string.Empty;			_nomusuriosolict = string.Empty;			_codclassf = long.MinValue;			_dscdtalhe = string.Empty;			_indvalid = string.Empty;			_nomusuriovalid = string.Empty;			_datvalid = DateTime.MinValue;			_codsituac = long.MinValue;			_indinterf = string.Empty;			_datinterf = DateTime.MinValue;			_codarea = long.MinValue;			_datinclus = DateTime.MinValue;			_codusurioinclus = string.Empty;			_codusurioaltrac = string.Empty;			_dataltrac = DateTime.MinValue;			_datatualizacao = DateTime.MinValue;
		}
		#endregion

		#region Propriedades
		
 
		public long CodProjto
		{
			get { return this._codprojto; }
			set { this._codprojto = value; }
		}

		
 
		public long AnoProjto
		{
			get { return this._anoprojto; }
			set { this._anoprojto = value; }
		}

		

		public string IndTipoDestno
		{
			get { return this._indtipodestno; }
			set { this._indtipodestno = value; }
		}

		

		public string DscResum
		{
			get { return this._dscresum; }
			set { this._dscresum = value; }
		}

		

		public string NomRespns
		{
			get { return this._nomrespns; }
			set { this._nomrespns = value; }
		}

		

		public DateTime DatInicl
		{
			get { return this._datinicl; }
			set { this._datinicl = value; }
		}

		

		public DateTime DatFinal
		{
			get { return this._datfinal; }
			set { this._datfinal = value; }
		}

		

		public string NomAreaSolict
		{
			get { return this._nomareasolict; }
			set { this._nomareasolict = value; }
		}

		

		public string NomUsurioSolict
		{
			get { return this._nomusuriosolict; }
			set { this._nomusuriosolict = value; }
		}

		
 
		public long CodClassf
		{
			get { return this._codclassf; }
			set { this._codclassf = value; }
		}

		

		public string DscDtalhe
		{
			get { return this._dscdtalhe; }
			set { this._dscdtalhe = value; }
		}

		

		public string IndValid
		{
			get { return this._indvalid; }
			set { this._indvalid = value; }
		}

		

		public string NomUsurioValid
		{
			get { return this._nomusuriovalid; }
			set { this._nomusuriovalid = value; }
		}

		

		public DateTime DatValid
		{
			get { return this._datvalid; }
			set { this._datvalid = value; }
		}

		
 
		public long CodSituac
		{
			get { return this._codsituac; }
			set { this._codsituac = value; }
		}

		

		public string IndInterf
		{
			get { return this._indinterf; }
			set { this._indinterf = value; }
		}

		

		public DateTime DatInterf
		{
			get { return this._datinterf; }
			set { this._datinterf = value; }
		}

		
 
		public long CodArea
		{
			get { return this._codarea; }
			set { this._codarea = value; }
		}

		

		public DateTime DatInclus
		{
			get { return this._datinclus; }
			set { this._datinclus = value; }
		}

		

		public string CodUsurioInclus
		{
			get { return this._codusurioinclus; }
			set { this._codusurioinclus = value; }
		}

		

		public string CodUsurioAltrac
		{
			get { return this._codusurioaltrac; }
			set { this._codusurioaltrac = value; }
		}

		

		public DateTime DatAltrac
		{
			get { return this._dataltrac; }
			set { this._dataltrac = value; }
		}

		

		public DateTime DatAtualizacao
		{
			get { return this._datatualizacao; }
			set { this._datatualizacao = value; }
		}

		
		#endregion

		#region Metodo Publico
		

		public override IMapper GetDefaultMapper()
		{
			IMapper mapper = (IMapper) CacheManager.GetValue("B_PROJTORO", "Mapper");
			if(mapper == null)
			{
				mapper = new B_PROJTOMapper(this.GetType());
				CacheManager.SetValue("B_PROJTORO", "Mapper", mapper, -1);
			}
			return mapper;
		} 


		#endregion
	}
}
