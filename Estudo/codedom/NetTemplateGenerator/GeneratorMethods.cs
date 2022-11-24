using System;
using System.Reflection;
using System.Collections.Specialized;

namespace NetTemplateGenerator
{
	/// <summary>
	/// Summary description for GeneratorMethods.
	/// </summary>
	public class GeneratorMethods
	{
		public string		ClassName;
		public string		FriendlyName;
		public MethodInfo	CCUGeneratorMethod;
		public MethodInfo	QueryVarsMethod;
		public MethodInfo	SetVarsMethod;
		public MethodInfo	GetNameMethod;

		public override string ToString() {
			if(FriendlyName == null) {
				return ClassName;
			} else {
				return FriendlyName;
			}
		}

		public GeneratorMethods()
		{
			ClassName = null;
			FriendlyName = null;
			CCUGeneratorMethod = null;
			QueryVarsMethod = null;
			SetVarsMethod = null;
			GetNameMethod = null;		// not required to be implemented
		}

		public bool IsValid() {
			if( CCUGeneratorMethod != null &&
				QueryVarsMethod != null &&
				SetVarsMethod != null) {
				
				//Does generator return a code compile unit?
				if(CCUGeneratorMethod.ReturnType == typeof(System.CodeDom.CodeCompileUnit)) {
					// And take no parameters?
					if(CCUGeneratorMethod.GetParameters().Length != 0) {
						return false;
					}
				} else {
					return false;
				}

				//Does QueryVars return a NameValueCollection?
				if(QueryVarsMethod.ReturnType == typeof(NameValueCollection)) {
					// And take no parameters?
					if(CCUGeneratorMethod.GetParameters().Length != 0) {
						return false;
					}
				} else {
					return false;
				}

				//Does SetVars return void?
				if(SetVarsMethod.ReturnType == typeof(void)) {
					ParameterInfo[] curParams = SetVarsMethod.GetParameters();
					// And take one parameter that is a NameValueCollection?
					if(curParams[0].ParameterType != typeof(NameValueCollection) &&
					   curParams.Length != 1) {
						return false;
					}
				} else {
					return false;
				}
			
			} else {
				return false;
			}

			return true;
		}

	}
}
