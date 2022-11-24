using System;
using System.CodeDom;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;



namespace TypedHashtableProvider {
	/// <summary>
	/// Summary description for CTHTGenerator.
	/// </summary>
	public class CTHTGenerator {
		private NameValueCollection TemplateVariables;
		private CodeVariableReferenceExpression InternalHash;
		private const string INT_HASH_NAME	= "InternalHash";
		private const string T_NAMESPACE	= "Namespace";
		private const string T_CLASSNAME	= "ClassType";
		private const string T_VALUETYPE	= "ValueType";
		private const string T_KEYTYPE		= "KeyType";
		
		public CTHTGenerator() {
			TemplateVariables = new NameValueCollection(5);
			TemplateVariables.Add(T_NAMESPACE,	"CTypedHashNamespace");
			TemplateVariables.Add(T_CLASSNAME,	"CTypedHashClassName");
			TemplateVariables.Add(T_VALUETYPE,	"CTypedHashValueType");
			TemplateVariables.Add(T_KEYTYPE,	"CTypedHashKeyType");
		}

		public string GetName() {
			return "Typed Hashtable Generator";
		}

		public NameValueCollection QueryVariables() {
			return TemplateVariables;
		}

		public void SetVariables(NameValueCollection varCollection) {
			TemplateVariables = varCollection;
		}

		public CodeCompileUnit GenerateCCU() {
			CodeCompileUnit ccu = new CodeCompileUnit();
			CodeNamespace	cns = new CodeNamespace(TemplateVariables[T_NAMESPACE]);
			CodeTypeDeclaration TypedHash = new CodeTypeDeclaration(TemplateVariables[T_CLASSNAME]);
			CodeMemberField ContainedHash;

			// Create and add the namespace
			ccu.Namespaces.Add(cns);
			cns.Imports.Add(new CodeNamespaceImport("System.Collections"));

			// Add the type and set its properties
			cns.Types.Add(TypedHash);
			TypedHash.IsClass = true;

			// Create internal hashtable
			ContainedHash = new CodeMemberField();
			ContainedHash.Name = INT_HASH_NAME;
			ContainedHash.Attributes = MemberAttributes.Private;
			ContainedHash.Type = new CodeTypeReference(typeof(System.Collections.Hashtable));
			TypedHash.Members.Add(ContainedHash);
			InternalHash = new CodeVariableReferenceExpression(INT_HASH_NAME);

			// Generate the constructors for the class
			GenerateConstructors(TypedHash);

			GenerateTypedImplementation(TypedHash);

			return ccu;
		}

		private void GenerateConstructors(CodeTypeDeclaration TypedHash) {
			//public CTypedHashTable() : base() {}
			CodeConstructor HTConstructor = new CodeConstructor();
			CodeExpression[] prmConstructor;

			HTConstructor.Name = "CTypedHashTable";
			HTConstructor.Attributes = MemberAttributes.Public;
			prmConstructor = new CodeExpression[0];
			HTConstructor.Statements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression(INT_HASH_NAME),
				new CodeObjectCreateExpression(typeof(Hashtable), prmConstructor)));
			TypedHash.Members.Add(HTConstructor);

			//public CTypedHashTable(int capacity) : base(capacity) {}
			HTConstructor = new CodeConstructor();
			HTConstructor.Name = "CTypedHashTable";
			HTConstructor.Attributes = MemberAttributes.Public;
			HTConstructor.Parameters.Add( new CodeParameterDeclarationExpression(typeof(int), "capacity"));

			prmConstructor = new CodeExpression[1];
			prmConstructor[0] = new CodeArgumentReferenceExpression("capacity");
			HTConstructor.Statements.Add(new CodeAssignStatement(InternalHash,
											new CodeObjectCreateExpression(typeof(Hashtable), prmConstructor)));
			TypedHash.Members.Add(HTConstructor);

			//public CTypedHashTable(int capacity, float loadFactor) : base(capacity, loadFactor) {}
			HTConstructor = new CodeConstructor();
			HTConstructor.Name = "CTypedHashTable";
			HTConstructor.Attributes = MemberAttributes.Public;
			HTConstructor.Parameters.Add( new CodeParameterDeclarationExpression(typeof(int), "capacity"));
			HTConstructor.Parameters.Add( new CodeParameterDeclarationExpression(typeof(System.Double), "loadFactor"));

			prmConstructor = new CodeExpression[2];
			prmConstructor[0] = new CodeArgumentReferenceExpression("capacity");
			prmConstructor[1] = new CodeArgumentReferenceExpression("loadFactor");
			HTConstructor.Statements.Add(new CodeAssignStatement(InternalHash,
				new CodeObjectCreateExpression(typeof(Hashtable), prmConstructor)));
			TypedHash.Members.Add(HTConstructor);
		}


		private void GenerateTypedImplementation(CodeTypeDeclaration TypedHash) {

			//		public void Add(T_KEYTPYE Key, T_ITEMTYPE Value)  {
			//			InternalHash.Add(Key, Value);
			//		}
			// Add Method
			CodeMemberMethod AddMethod = new CodeMemberMethod();
			CodeMethodInvokeExpression InternalHashMethod = new CodeMethodInvokeExpression();

			AddMethod.Name = "Add";
			AddMethod.ReturnType = new CodeTypeReference(typeof(void));
			AddMethod.Attributes = MemberAttributes.Public;
			AddMethod.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_KEYTYPE], "Key"));
			AddMethod.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_VALUETYPE], "Value"));
			
			InternalHashMethod.Method = new CodeMethodReferenceExpression(InternalHash, "Add");
			InternalHashMethod.Parameters.Add(new CodeArgumentReferenceExpression("Key"));
			InternalHashMethod.Parameters.Add(new CodeArgumentReferenceExpression("Value"));
			
			AddMethod.Statements.Add(InternalHashMethod);
			TypedHash.Members.Add(AddMethod);			

			//		public bool ContainsKey(T_KEYTPYE Key) {
			//			return InternalHash.ContainsKey(Key);
			//		}
			CodeMemberMethod ContainsKeyMethod = new CodeMemberMethod();
			InternalHashMethod = new CodeMethodInvokeExpression();

			ContainsKeyMethod.Name = "ContainsKey";
			ContainsKeyMethod.ReturnType = new CodeTypeReference(typeof(bool));
			ContainsKeyMethod.Attributes = MemberAttributes.Public;
			ContainsKeyMethod.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_KEYTYPE], "Key"));

			InternalHashMethod.Method = new CodeMethodReferenceExpression(InternalHash, "ContainsKey");
			InternalHashMethod.Parameters.Add(new CodeArgumentReferenceExpression("Key"));

			ContainsKeyMethod.Statements.Add(new CodeMethodReturnStatement(InternalHashMethod));
			TypedHash.Members.Add(ContainsKeyMethod);	


			//		public bool ContainsValue(T_ITEMTYPE Value) {
			//			return InternalHash.ContainsValue(Value);
			//		}
			CodeMemberMethod ContainsValueMethod = new CodeMemberMethod();
			InternalHashMethod = new CodeMethodInvokeExpression();

			ContainsValueMethod.Name = "ContainsValue";
			ContainsValueMethod.ReturnType = new CodeTypeReference(typeof(bool));
			ContainsValueMethod.Attributes = MemberAttributes.Public;
			ContainsValueMethod.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_VALUETYPE], "Value"));

			InternalHashMethod.Method = new CodeMethodReferenceExpression(InternalHash, "ContainsValue");
			InternalHashMethod.Parameters.Add(new CodeArgumentReferenceExpression("Value"));

			ContainsValueMethod.Statements.Add(new CodeMethodReturnStatement(InternalHashMethod));
			TypedHash.Members.Add(ContainsValueMethod);	


			//		public void Remove(T_KEYTPYE Key) {
			//			InternalHash.Remove(IssueID);
			//		}
			CodeMemberMethod RemoveMethod = new CodeMemberMethod();
			InternalHashMethod = new CodeMethodInvokeExpression();

			RemoveMethod.Name = "Remove";
			RemoveMethod.ReturnType = new CodeTypeReference(typeof(void));
			RemoveMethod.Attributes = MemberAttributes.Public;
			RemoveMethod.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_KEYTYPE], "Key"));
			
			InternalHashMethod.Method = new CodeMethodReferenceExpression(InternalHash, "Remove");
			InternalHashMethod.Parameters.Add(new CodeArgumentReferenceExpression("Key"));
			
			RemoveMethod.Statements.Add(InternalHashMethod);
			TypedHash.Members.Add(RemoveMethod);	


			//		public CTypedHashItem this[T_KEYTPYE Key] {
			//			get {
			//				return (T_ITEMTYPE)base[Key];
			//			}
			//			set {
			//				base[Key] = value;
			//			}
			//		}
			//Create the default indexer.  This requires the use of the special name "Item" along
			//with one or more parameters.
			CodeMemberProperty DefaultProperty = new CodeMemberProperty();
			CodeExpression[] HashIndex = new CodeExpression[1] { new CodeArgumentReferenceExpression("Key") };
			CodeIndexerExpression InternalDefaultReference = new CodeIndexerExpression(InternalHash,
				HashIndex);

			DefaultProperty.Name = "Item";
			DefaultProperty.Attributes = MemberAttributes.Public;
			DefaultProperty.Parameters.Add(new CodeParameterDeclarationExpression(TemplateVariables[T_KEYTYPE], "Key"));
			DefaultProperty.Type = new CodeTypeReference(TemplateVariables[T_VALUETYPE]);

			// Get Statement
			DefaultProperty.GetStatements.Add(new CodeMethodReturnStatement(
				new CodeCastExpression(TemplateVariables[T_VALUETYPE], InternalDefaultReference)));
			
			// Set Statement
			DefaultProperty.SetStatements.Add(new CodeAssignStatement(InternalDefaultReference, 
				new CodePropertySetValueReferenceExpression()));
		
			TypedHash.Members.Add(DefaultProperty);
		}

	}
}
