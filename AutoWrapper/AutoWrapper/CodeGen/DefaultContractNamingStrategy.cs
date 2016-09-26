using System;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public class DefaultContractNamingStrategy : IContractNamingStrategy
	{
		public virtual string ContractNameFor(Type type)
		{
			return 'I' + type.Name;
		}
	}
}