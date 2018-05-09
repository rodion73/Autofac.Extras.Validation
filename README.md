# Autofac.Extras.Validation

An Autofac interceptor that validates input method parameters with data annotation validation attributes like 'Require', 'Range', etc.

## How to use

```csharp
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Extras.Validation;
using System.ComponentModel.DataAnnotations;

public class Bar
{
  // Properties and fields of complex types will be validated too
  [Required]
  public string Baz {get; set;}
}

public interface IFoo
{
  // We can use any ValidationAttribute including custom ones
  void Bar(
    [Require] string p1,
    [Range(1, 10)] int p2,
    [EmailAddress] string p3,
    [RegularExpression("\\d+")] string p4,
    Bar p5
    // custom validators work as well
    [MyCustomValidation] object p5 
  );
}

public class Foo: IFoo
{
  // Implementation goes here
}

var builder = new ContainerBuilder();

// first of all register validation module
builder.RegisterModule<ValidationModule>();

builder.RegisterType<Foo>().As<IFoo>()
   .EnableInterfaceInterceptors() // enable interception
   .EnableParametersValidation(); // add validation interceptor
```

Also we can apply validation attributes to the class' method parameters like this:

```csharp
public class Foo: IFoo
{
  public void Bar(
    [Require] string p1,
    [Range(1, 10)] int p2,
    [EmailAddress] string p3,
    [RegularExpression("\\d+")] string p4,
    Bar p5
    // custom validators work as well
    [MyCustomValidation] object p5 
  )
  {
     // ....
  }
}
```
