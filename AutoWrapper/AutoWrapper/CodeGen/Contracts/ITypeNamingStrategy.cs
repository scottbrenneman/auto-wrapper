using System;

namespace AutoWrapper.CodeGen.Contracts
{
	public interface ITypeNamingStrategy
	{
		string TypeNameFor(Type type);
	}
}