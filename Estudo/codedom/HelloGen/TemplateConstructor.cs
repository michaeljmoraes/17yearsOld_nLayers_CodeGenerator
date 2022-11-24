using System;
using System.CodeDom;

namespace HelloGen
{
	/// <summary>
	/// Summary description for AppCreator.
	/// </summary>
	public class TemplateConstructor
	{
		public CodePrimitiveExpression SourceText;
		public bool	UseFullNamespace = false;

		private CodeTypeDeclaration hwClassRef;
		
		public TemplateConstructor() {
			SourceText = new CodePrimitiveExpression("[Little Recursive Box]");
		}


		public CodeCompileUnit GenerateCCU() {
			CodeCompileUnit		hwCompileUnit = new CodeCompileUnit();
			CodeNamespace		hwNamespace = BuildNamespace();
			CodeTypeDeclaration	hwFormClass = BuildFormClass();
			
			hwClassRef = hwFormClass;
			CodeTypeDeclaration hwAppClass	= BuildAppClass();

			hwCompileUnit.Namespaces.Add(hwNamespace);
			hwNamespace.Types.Add(hwFormClass);
			hwNamespace.Types.Add(hwAppClass);			

			return hwCompileUnit;
		}

		private CodeNamespace BuildNamespace() {
			CodeNamespace	hwNamespace = new CodeNamespace();
			
			hwNamespace.Name = "HelloWorld";
			hwNamespace.Imports.Add(new CodeNamespaceImport("System"));
			hwNamespace.Imports.Add(new CodeNamespaceImport("System.Drawing"));
			hwNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
			return hwNamespace;
		}

		private CodeTypeDeclaration BuildFormClass() {
			CodeTypeDeclaration	FormClass = new CodeTypeDeclaration();
			CodeEntryPointMethod MainMethod = new CodeEntryPointMethod();

			// Set up Class
			FormClass.Name = "HelloWorldForm";
			FormClass.IsClass = true;
			FormClass.BaseTypes.Add(new CodeTypeReference(typeof(System.Windows.Forms.Form)));
					
			FormClass.Attributes = MemberAttributes.Public;

			// set up members
			FormClass.Members.Add(new CodeMemberField(typeof(System.Windows.Forms.TextBox), "txtSourceCode"));

			// set up constructor
			FormClass.Members.Add(BuildFormConstructor());
			
			return FormClass;
		}

		private CodeConstructor BuildFormConstructor() {
			CodeConstructor					hwConstructor = new CodeConstructor();
			CodeThisReferenceExpression		oThis = new CodeThisReferenceExpression();
			CodeStatementCollection			stCol = new CodeStatementCollection();
			
			hwConstructor.Attributes = MemberAttributes.Public;

			CodeExpression[] prmSizeArgs = { new CodePrimitiveExpression(5), new CodePrimitiveExpression(13) };
            stCol.Add(new CodeAssignStatement(
						new CodePropertyReferenceExpression(oThis, "AutoScaleBaseSize"),
						new CodeObjectCreateExpression(typeof(System.Drawing.Size), prmSizeArgs)));

			stCol.Add(new CodeAssignStatement(
						new CodePropertyReferenceExpression(oThis, "Text"),
						new CodePrimitiveExpression("Hello, World!")));

			prmSizeArgs[0] = new CodePrimitiveExpression(700);
			prmSizeArgs[1] = new CodePrimitiveExpression(350);
			stCol.Add(new CodeAssignStatement(
						new CodePropertyReferenceExpression(oThis, "Size"),
						new CodeObjectCreateExpression(typeof(System.Drawing.Size), prmSizeArgs)));

			stCol.Add(new CodeAssignStatement(
						new CodeVariableReferenceExpression("txtSourceCode"),
						new CodeObjectCreateExpression(typeof(System.Windows.Forms.TextBox), new CodeExpression[0])));

			CodeExpression[] prmAdd = { new CodeVariableReferenceExpression("txtSourceCode") };
			stCol.Add(new CodeMethodInvokeExpression(
						new CodePropertyReferenceExpression(oThis, "Controls"), "Add", prmAdd));
			

			stCol.Add(new CodeAssignStatement(
						new CodePropertyReferenceExpression(
							new CodeVariableReferenceExpression("txtSourceCode"), "Multiline"),
                			new CodePrimitiveExpression(true)));
	
			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "ScrollBars"),
				new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("ScrollBars"), "Both")));
						

			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "Top"),
				new CodePrimitiveExpression(10)));	
		
			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "Width"),
				new CodePrimitiveExpression(10)));


			prmSizeArgs[0] = new CodePrimitiveExpression(690);
			prmSizeArgs[1] = new CodePrimitiveExpression(300);
			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "Size"),
				new CodeObjectCreateExpression(typeof(System.Drawing.Size), prmSizeArgs)));


			CodeTypeReferenceExpression oAnchor = new CodeTypeReferenceExpression("AnchorStyles");
			CodeBinaryOperatorExpression AnchorStyles = new CodeBinaryOperatorExpression(
					new CodeFieldReferenceExpression(oAnchor, "Bottom"), CodeBinaryOperatorType.BitwiseOr,
					new CodeBinaryOperatorExpression(
						new CodeFieldReferenceExpression(oAnchor, "Top"), CodeBinaryOperatorType.BitwiseOr,
						new CodeBinaryOperatorExpression(		
							new CodeFieldReferenceExpression(oAnchor, "Left"), CodeBinaryOperatorType.BitwiseOr,
							new CodeFieldReferenceExpression(oAnchor, "Right"))));


			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "Anchor"),
				AnchorStyles));

			stCol.Add(new CodeAssignStatement(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression("txtSourceCode"), "Text"),
				SourceText));

			hwConstructor.Statements.AddRange(stCol);

			return hwConstructor;
		}

		private CodeTypeDeclaration BuildAppClass() {
			String TypeString = "HelloWorldForm";

			if(UseFullNamespace) {
				TypeString = "HelloWorld." + TypeString;
			}

			CodeTypeDeclaration		hwAppClass = new CodeTypeDeclaration("HelloApplication");
			CodeEntryPointMethod	MainMethod = new CodeEntryPointMethod();
			
			hwAppClass.IsClass = true;
			hwAppClass.Attributes = MemberAttributes.Public;

			MainMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
			MainMethod.ReturnType = new CodeTypeReference(typeof(void));
 			CodeExpression[] prmRun = { new CodeObjectCreateExpression("HelloWorld", new CodeExpression[0]) };


			MainMethod.Statements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference(TypeString), "hwApp"));

			CodeExpression[] hwParams = new CodeExpression[0];			
			MainMethod.Statements.Add(new CodeAssignStatement(
				new CodeVariableReferenceExpression("hwApp"), 
				new CodeObjectCreateExpression(TypeString, hwParams)));

			
			MainMethod.Statements.Add( new CodeMethodInvokeExpression(
				new CodeVariableReferenceExpression("hwApp"), "ShowDialog", hwParams));
			
			hwAppClass.Members.Add(MainMethod);
	
			return hwAppClass;
		}
	}
}
