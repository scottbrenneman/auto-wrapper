using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoWrapper.CodeGen.Contracts;

namespace AutoWrapper.CodeGen
{
	public sealed class WrapperTypeContainer : IWrapperTypeContainer
	{
		public WrapperTypeContainer()
		{
			_typesToWrap = new List<Type>();
		}

		public IEnumerable<Type> RegisteredTypes => _typesToWrap;

		public void RegisterAssembly(Assembly assembly)
		{
			_typesToWrap.AddRange(
				 assembly.GetTypes()
				 .Where(t => t.IsClass && t.IsPublic && t.IsAbstract == false && t.GetInterfaces().Length == 0)
				 .ToArray()
			);
		}

		public void RegisterAssemblyWithType(Type type)
		{
			RegisterAssembly(Assembly.GetAssembly(type));
		}

		public void Register(Type type)
		{
			_typesToWrap.Add(type);
		}

		public void Register<TType>()
			where TType : class
		{
			Register(typeof(TType));
		}

		private readonly List<Type> _typesToWrap;
	}
}