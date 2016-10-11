﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoWrapper.Samples.WrapperForSomeType
{
	using System;
	
	
	// Interface for SomeTypeWrapper
	internal interface ISomeTypeWrapper : System.IDisposable
	{
		
		bool Property1
		{
			get;
			set;
		}
		
		object Property2
		{
			get;
		}
		
		string this[int x]
		{
			get;
		}
		
		AutoWrapper.Tests.TestClasses.SomeType Wrapped
		{
			get;
		}
		
		void Function1(int x);
		
		int Function2(bool b, object o);
		
		System.Threading.Tasks.Task<string> Function3(int x, string s);
		
		string Function4(out int x, ref string s, object o);
		
		void InheritedFunction();
	}
	
	public sealed partial class SomeTypeWrapper : ISomeTypeWrapper
	{
		
		private readonly AutoWrapper.Tests.TestClasses.SomeType _wrapped;
		
		public SomeTypeWrapper(AutoWrapper.Tests.TestClasses.SomeType wrapped)
		{
			_wrapped = wrapped;
		}
		
		public bool Property1
		{
			get
			{
				return _wrapped.Property1;
			}
			set
			{
				_wrapped.Property1 = value;
			}
		}
		
		public object Property2
		{
			get
			{
				return _wrapped.Property2;
			}
		}
		
		public string this[int x]
		{
			get
			{
				return _wrapped[x];
			}
		}
		
		public AutoWrapper.Tests.TestClasses.SomeType Wrapped
		{
			get
			{
				return _wrapped;
			}
		}
		
		public void Dispose()
		{
			_wrapped.Dispose();
		}
		
		public void Function1(int x)
		{
			_wrapped.Function1(x);
		}
		
		public int Function2(bool b, object o)
		{
			return _wrapped.Function2(b, o);
		}
		
		public System.Threading.Tasks.Task<string> Function3(int x, string s)
		{
			return _wrapped.Function3(x, s);
		}
		
		public string Function4(out int x, ref string s, object o)
		{
			return _wrapped.Function4(out x, ref s, o);
		}
		
		public void InheritedFunction()
		{
			_wrapped.InheritedFunction();
		}
		
		public override string ToString()
		{
			return _wrapped.ToString();
		}
		
		public override bool Equals(object obj)
		{
			return _wrapped.Equals(obj);
		}
		
		public override int GetHashCode()
		{
			return _wrapped.GetHashCode();
		}
	}
}
