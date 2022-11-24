using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Procwork.CodeGenerator.Classes
{

	public class Code 
	
	{

		public string Name;
		public CodeTypeDeclaration Type;
		public CSharpCodeProvider Provider;

		public Code()
		{
		}

		public Code(string name_, CSharpCodeProvider provider_)
		{
			this.Name = name_;
			this.Type = new CodeTypeDeclaration(name_);
			this.Provider = provider_;

		}
		
		public string Generate()
		{
			ICodeGenerator generator = Provider.CreateGenerator();
			string codeString = Generate(generator);
			return codeString;
		}

		public string Generate(ICodeGenerator generator_)
		{
			
			MemoryStream stream = new MemoryStream();

			StreamWriter writer = new StreamWriter(stream);

			CodeCompileUnit unit = CreateCompileUnit();

			generator_.GenerateCodeFromCompileUnit(unit, writer, CreateOptions());

			writer.Flush();
			stream.Seek(0, SeekOrigin.Begin);
			StreamReader reader = new StreamReader(stream);
			string codeString = reader.ReadToEnd();
			stream.Close();

			return codeString;

		}

		public CodeCompileUnit CreateCompileUnit()
		{
			CodeCompileUnit unit = new CodeCompileUnit();

			unit.Namespaces.Add(CreateNamespace());

			return unit;

		}

		public CodeNamespace CreateNamespace()
		{
			CodeNamespace ns = new CodeNamespace();
			ns.Name = "Procwork";
			ns.Types.Add(Type);
			return ns;
		}

		public CodeGeneratorOptions CreateOptions()
		{
			CodeGeneratorOptions options = new CodeGeneratorOptions();
			options.BracingStyle = "C";
			return options;
		}

	}
}
