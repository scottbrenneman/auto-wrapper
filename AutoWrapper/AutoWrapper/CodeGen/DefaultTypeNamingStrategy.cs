using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class DefaultTypeNamingStrategy : ITypeNamingStrategy
	{
		public virtual string TypeNameFor(Type type)
		{
			return "Wrapped" + type.Name;
		}
	}
}