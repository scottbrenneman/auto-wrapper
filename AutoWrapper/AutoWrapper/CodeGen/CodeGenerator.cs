using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace AutoWrapper.CodeGen
{
	public sealed class CodeGenerator : IDisposable
	{
		public CodeGenerator(CodeGeneratorOptions generatorOptions = null)
		{
			_provider = CodeDomProvider.CreateProvider("CSharp");
			_options = generatorOptions ?? StandardOptions;
		}

		public string GenerateCode(CodeTypeDeclaration declaration)
		{
			using (var writer = new StringWriter())
			{
				_provider.GenerateCodeFromType(declaration, writer, _options);

				return writer.ToString();
			}
		}

		public string GenerateCode(CodeCompileUnit codeCompileUnit)
		{
			using (var writer = new StringWriter())
			{
				_provider.GenerateCodeFromStatement(new CodeSnippetStatement("#pragma warning disable"), writer, _options);

				_provider.GenerateCodeFromCompileUnit(codeCompileUnit, writer, _options);

				return writer.ToString();
			}
		}

		public void Dispose()
		{
			_provider.Dispose();
		}

		public static CodeGeneratorOptions StandardOptions => new CodeGeneratorOptions { BracingStyle = "C", IndentString = "\t"};

		private readonly CodeDomProvider _provider;
		private readonly CodeGeneratorOptions _options;
	}
}