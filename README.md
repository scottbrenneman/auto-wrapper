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
    
    namespace MyWrappedClasses
    {
        <#= AutoWrap.Type<FooClass>() #>
    }

#### Use TypeGenerator to specify options

    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .AsPublic()
                .AsPartial()
                .GenerateCode() #>
    }

#### Generate a wrapper with a given name

    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .WithName("MyWrappedFoo")
                .GenerateCode() #>
    }

#### Use a naming strategy (implement ITypeNamingStrategy)

    <# var namingStrategy = new MyNamingStrategy(); #>
    
    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .WithNamingStrategy(namingStrategy)
                .GenerateCode() #>
    }

#### Exclude members from a given type

    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .ExcludingMembersFrom<object>()
                .GenerateCode() #>
    }

#### Generate a wrapper with no interface

    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .WithNoContract()
                .GenerateCode() #>
    }
    
#### Or no implementation

By default, AutoWrapper uses composition and will pass through all calls to the wrapped type. Specify `WithNoImplementation()` to throw `NotImplementedException` instead.

    namespace MyWrappedClasses
    {
        <#= TypeGenerator.WrapperFor<FooClass>()
                .WithNoImplementation()
                .GenerateCode() #>
    }
    
#### Use ContractGenerator to generate just an interface

    namespace MyGeneratedInterfaces
    {
        <#= ContractGenerator.ContractFor<FooClass>()
                .WithName("IFoo")
                .GenerateCode() #>
    }