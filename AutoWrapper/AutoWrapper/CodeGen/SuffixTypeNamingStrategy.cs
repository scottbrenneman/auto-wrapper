using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class SuffixTypeNamingStrategy : ITypeNamingStrategy
	{
		public string TypeNameFor(Type type)
		{
			return $"{type.Name}Wrapper";
		}
	}
}