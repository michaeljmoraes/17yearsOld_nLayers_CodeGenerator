using System;
using System.Data;
using Avanade.ACA.Data;
using Avanade.ACA.Data.CommandWriter;
using Carrefour.Entidade.Corporativo.Seguranca.ControleAcesso;
using Carrefour.C4A.BusinessComponents;
using Carrefour.C4A.PersistenceFunctions;
using Carrefour.C4A.PersistableObjectManager;
using System.Collections;

namespace procwork 
{
	/// <summary>
	/// B_PROJTOMapper
	/// </summary>
	/// <remarks>
	/// @LastUpdate: 12/11/2004 - 12:12
	/// </remarks>	
	public class B_PROJTOMapper : AMapper
	{
		public B_PROJTOMapper(System.Type objType_): base(objType_)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override IDbObject ConvertFromDB(ResultSetRow rs_)
		{
			B_PROJTOEO objEO = new B_PROJTOEO();
			

			return objEO;
		}

		public override string GetDefaultQuery()
		{
			string SQL = @"
			return SQL;
		}

		public override string GetDefaultCountQuery()
		{
			return "";
		}
		

		public override IDbCommandWriter GetInsertCommand(string userName_, IEntityObject obj_)
		{
			B_PROJTOEO obj = (B_PROJTOEO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter("SP_IN_B_PROJTO", CommandType.StoredProcedure);
			cw.AddInParam("V_ANO_PROJTO", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.AnoProjto));
			cw.AddInParam("V_IND_TIPO_DESTNO", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndTipoDestno));
			cw.AddInParam("V_DSC_RESUM", DbType.String,PersistenceHelper.SetStringOnDB(obj_.DscResum));
			cw.AddInParam("V_NOM_RESPNS", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomRespns));
			cw.AddInParam("V_DAT_INICL", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatInicl));
			cw.AddInParam("V_DAT_FINAL", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatFinal));
			cw.AddInParam("V_NOM_AREA_SOLICT", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomAreaSolict));
			cw.AddInParam("V_NOM_USURIO_SOLICT", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomUsurioSolict));
			cw.AddInParam("V_COD_CLASSF", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodClassf));
			cw.AddInParam("V_DSC_DTALHE", DbType.String,PersistenceHelper.SetStringOnDB(obj_.DscDtalhe));
			cw.AddInParam("V_IND_VALID", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndValid));
			cw.AddInParam("V_NOM_USURIO_VALID", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomUsurioValid));
			cw.AddInParam("V_DAT_VALID", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatValid));
			cw.AddInParam("V_COD_SITUAC", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodSituac));
			cw.AddInParam("V_IND_INTERF", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndInterf));
			cw.AddInParam("V_DAT_INTERF", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatInterf));
			cw.AddInParam("V_COD_AREA", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodArea));
			cw.AddInParam("V_COD_USURIO_INCLUS", DbType.String,PersistenceHelper.SetStringOnDB(obj_.CodUsurioInclus));
			cw.AddParam("V_COD_PROJTO", DbType.Int64, ParameterDirection.InputOutput, "V_COD_PROJTO", DataRowVersion.Default, obj_.CodProjto);
			cw.AddParam("V_DAT_ATUALIZACAO", DbType.DateTime, ParameterDirection.InputOutput, "V_DAT_ATUALIZACAO", DataRowVersion.Default, obj_.DatAtualizacao);
			 
			return cw;	
		}

		

		public override IDbCommandWriter GetUpdateCommand(string userName_, IEntityObject obj_)
		{
			B_PROJTOEO obj = (B_PROJTOEO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter("SP_UP_B_PROJTO", CommandType.StoredProcedure);
			cw.AddInParam("V_COD_PROJTO", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodProjto));
			cw.AddInParam("V_ANO_PROJTO", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.AnoProjto));
			cw.AddInParam("V_IND_TIPO_DESTNO", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndTipoDestno));
			cw.AddInParam("V_DSC_RESUM", DbType.String,PersistenceHelper.SetStringOnDB(obj_.DscResum));
			cw.AddInParam("V_NOM_RESPNS", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomRespns));
			cw.AddInParam("V_DAT_INICL", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatInicl));
			cw.AddInParam("V_DAT_FINAL", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatFinal));
			cw.AddInParam("V_NOM_AREA_SOLICT", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomAreaSolict));
			cw.AddInParam("V_NOM_USURIO_SOLICT", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomUsurioSolict));
			cw.AddInParam("V_COD_CLASSF", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodClassf));
			cw.AddInParam("V_DSC_DTALHE", DbType.String,PersistenceHelper.SetStringOnDB(obj_.DscDtalhe));
			cw.AddInParam("V_IND_VALID", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndValid));
			cw.AddInParam("V_NOM_USURIO_VALID", DbType.String,PersistenceHelper.SetStringOnDB(obj_.NomUsurioValid));
			cw.AddInParam("V_DAT_VALID", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatValid));
			cw.AddInParam("V_COD_SITUAC", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodSituac));
			cw.AddInParam("V_IND_INTERF", DbType.String,PersistenceHelper.SetStringOnDB(obj_.IndInterf));
			cw.AddInParam("V_DAT_INTERF", DbType.DateTime,PersistenceHelper.SetDateTimeOnDB(obj_.DatInterf));
			cw.AddInParam("V_COD_AREA", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodArea));
			cw.AddInParam("V_COD_USURIO_ALTRAC", DbType.String,PersistenceHelper.SetStringOnDB(obj_.CodUsurioAltrac));
			cw.AddParam("V_DAT_ATUALIZACAO", DbType.DateTime, ParameterDirection.InputOutput, "V_DAT_ATUALIZACAO", DataRowVersion.Default, obj_.DatAtualizacao);
			
			return cw;	
		}

		

		public override IDbCommandWriter GetDeleteCommand(string userName_, IEntityObject obj_)
		{
			B_PROJTOEO obj = (B_PROJTOEO) obj_;
			IDbCommandWriter cw = this.DB.CreateDbCommandWriter("SP_EX_B_PROJTO", CommandType.StoredProcedure);
			cw.AddInParam("V_COD_PROJTO", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.CodProjto));
			cw.AddInParam("V_ANO_PROJTO", DbType.Int64,PersistenceHelper.SetLongOnDB(obj_.AnoProjto));
			
			return cw;	
		}

		

	}

}