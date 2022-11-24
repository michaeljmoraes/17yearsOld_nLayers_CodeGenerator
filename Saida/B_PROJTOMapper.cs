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
						objEO.CodProjto = rs.GetLong("COD_PROJTO");			objEO.AnoProjto = rs.GetLong("ANO_PROJTO");			objEO.IndTipoDestno = rs.GetString("IND_TIPO_DESTNO");			objEO.DscResum = rs.GetString("DSC_RESUM");			objEO.NomRespns = rs.GetString("NOM_RESPNS");			objEO.DatInicl = rs.GetDateTime("DAT_INICL");			objEO.DatFinal = rs.GetDateTime("DAT_FINAL");			objEO.NomAreaSolict = rs.GetString("NOM_AREA_SOLICT");			objEO.NomUsurioSolict = rs.GetString("NOM_USURIO_SOLICT");			objEO.CodClassf = rs.GetLong("COD_CLASSF");			objEO.DscDtalhe = rs.GetString("DSC_DTALHE");			objEO.IndValid = rs.GetString("IND_VALID");			objEO.NomUsurioValid = rs.GetString("NOM_USURIO_VALID");			objEO.DatValid = rs.GetDateTime("DAT_VALID");			objEO.CodSituac = rs.GetLong("COD_SITUAC");			objEO.IndInterf = rs.GetString("IND_INTERF");			objEO.DatInterf = rs.GetDateTime("DAT_INTERF");			objEO.CodArea = rs.GetLong("COD_AREA");			objEO.DatInclus = rs.GetDateTime("DAT_INCLUS");			objEO.CodUsurioInclus = rs.GetString("COD_USURIO_INCLUS");			objEO.CodUsurioAltrac = rs.GetString("COD_USURIO_ALTRAC");			objEO.DatAltrac = rs.GetDateTime("DAT_ALTRAC");			objEO.DatAtualizacao = rs.GetDateTime("DAT_ATUALIZACAO");

			return objEO;
		}

		public override string GetDefaultQuery()
		{
			string SQL = @"				SELECT 						COD_PROJTO, 						ANO_PROJTO, 						IND_TIPO_DESTNO, 						DSC_RESUM, 						NOM_RESPNS, 						DAT_INICL, 						DAT_FINAL, 						NOM_AREA_SOLICT, 						NOM_USURIO_SOLICT, 						COD_CLASSF, 						DSC_DTALHE, 						IND_VALID, 						NOM_USURIO_VALID, 						DAT_VALID, 						COD_SITUAC, 						IND_INTERF, 						DAT_INTERF, 						COD_AREA, 						DAT_INCLUS, 						COD_USURIO_INCLUS, 						COD_USURIO_ALTRAC, 						DAT_ALTRAC, 						DAT_ATUALIZACAO				 FROM B_PROJTO";
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