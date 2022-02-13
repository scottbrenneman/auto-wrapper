# AutoWrapper

A library for generation of wrapper classes with interfaces.

# Examples

#### Quickly generate a wrapper with T4

    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>    
    <#@ assembly name="netstandard" #>
    <#@ assembly name="$(TargetDir)AutoWrapper.dll" #>
    <#@ assembly name="$(TargetDir)MyAssembly.dll" #>
    <#@ import namespace="AutoWrapper" #>
    
    <#= AutoWrap.Type<MyClass>("MyWrappedClasses") #>

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

#### AutoWrapper is for design-time (use PrivateAssets to avoid proliferating it as a dependency)

    <ItemGroup>
        <PackageReference Include="AutoWrapper" Version="1.1.0">
            <PrivateAssets>all</PrivateAssets>
        </PackageReference>
    </ItemGroup>