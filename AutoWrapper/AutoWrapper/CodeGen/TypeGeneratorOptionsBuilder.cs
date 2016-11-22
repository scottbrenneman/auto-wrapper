using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class TypeGeneratorOptionsBuilder : ITypeGeneratorOptionsBuilder, ITypeGeneratorOptions
	{
		private ITypeNamingStrategy _typeNamingStrategy;
		private TypeAttributes _typeAttributes;

		public TypeGeneratorOptionsBuilder(ITypeNamingStrategy typeNamingStrategy = null)
		{
			_typeNamingStrategy = typeNamingStrategy ?? new DefaultNamingStrategy();
		}

		public ITypeGeneratorOptionsBuilder WithPublic()
		{
			_typeAttributes |= TypeAttributes.Public;
			return this;
		}

		public ITypeGeneratorOptionsBuilder WithPartial()
		{
			_usePartial = true;
			return this;
		}

		public ITypeGeneratorOptions Build() => this;
		
		TypeAttributes ITypeGeneratorOptions.GetTypeAttributes()
		{
			return _typeAttributes;
		}

		private bool _usePartial;
		bool ITypeGeneratorOptions.UsePartial => _usePartial;
	}
}