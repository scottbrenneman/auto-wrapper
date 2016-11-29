# AutoWrapper

A library for generation of wrapper classes with interfaces.

# Examples

#### Quickly generate a wrapper with T4

    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    
    <#@ assembly name="AutoWrapper.dll" #>
    <#@ import namespace="AutoWrapper" #>
    
    <#= AutoWrap.Type<FooClass>("MyWrappedClasses") #>

#### Generate wrappers for an assembly

    <#= AutoWrap.AssemblyWithType<FooClass>("MyWrappedClasses") #>

#### Register the types you want to wrap with WrappedTypeContainer

    <# 
		var container =
			new WrappedTypeContainer()
				.Register<Class1>()
				.Register<Class2>();
	#>

	<#= AutoWrap.FromContainer(container, "MyWrappedClasses") #>
    
#### Use a naming strategy (implement ITypeNamingStrategy and IContractNamingStrategy)

    <#
		var contractNamingStrategy = new MyContractNamingStrategy();
		var typeNamingStrategy = new MyTypeNamingStrategy();

		AutoWrap.ContractNamingStrategy = contractNamingStrategy;
		AutoWrap.TypeNamingStrategy = typeNamingStrategy;
	#>
    
    <#= AutoWrap.Type<FooClass>("MyWrappedClasses") #>