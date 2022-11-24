using System;
using System.Collections;
using System.EnterpriseServices;
using Carrefour.C4A.BusinessComponents;
using Carrefour.C4A.HelperFunctions;
using Carrefour.C4A.PersistenceFunctions;
using Carrefour.C4A.PersistableObjectManager;
using Carrefour.C4A.DataFilter;

namespace B_PROJTO
{
	[Transaction(TransactionOption.Supported)]
	public class B_PROJTOBC : ABusinessComponent
	{
		public B_PROJTOBC()
		{
		}
	
		

		public ArrayList ObterTodos()
		{
			ArrayList ret = new ArrayList();
			B_PROJTOEO objEO = new B_PROJTOEO();
			PersistableObjectManagerNonTX pom = new PersistableObjectManagerNonTX();
			Criteria criteria = new Criteria();
			try
			{
				ret = pom.Retrieve(objEO.GetDefaultMapper()
					             , criteria
					             , false
					             , ""
					             , ""
					             , ""
					             , false);
			}
			finally
			{
				pom.Dispose();
			}
			return ret;
		}

			 

		#region Metodos Publicos

		

		public B_PROJTOEO Obter(B_PROJTOEO objEO_)
		{
			B_PROJTOEO ret = new B_PROJTOEO();
			PersistableObjectManagerNonTX pom = new PersistableObjectManagerNonTX();
			try
			{
				ret = (B_PROJTOEO)pom.Retrieve(ret.GetDefaultMapper(), objEO_); 
			}
			finally
			{
				pom.Dispose();
			}
			return ret;
		}

			
		

		public B_PROJTOEO Persistir(string usuario, B_PROJTOEO objEO_)
		{
			PersistableObjectManagerTX pom = new PersistableObjectManagerTX();
			try
			{
				objEO_ = (B_PROJTOEO) pom.Persist(usuario, objEO_);
			}
			finally
			{
				pom.Dispose();
			}
			
			return objEO_;

		}

	
		

		public void Remover(string usuario, B_PROJTOEO objEO_)
		{
			objEO_.Delete();
			BCHelper.Persist(usuario, objEO_);
		}

		

		#endregion

	}
}

