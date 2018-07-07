![Logo](images/extension-cord.svg){.img-responsive .center-block}
# ExtensionCord - Useful Extensions for Common .NET Types

This assembly contains useful extension methods and helper classes for the basic types in the 
.NET framework. They have came in handy in many projects I've written. So, I bundled them into 
a .NET Standard assembly and created a [nuget](https://www.nuget.org/packages/ExtensionCord) 
package from that.

The name of the library stems from my woodworking hobby. Usually when I start a woodworking project 
the first thing I'll grab is the extension cord to power my tools. This library is similar in the way 
that its methods are used in pretty much all C# code I have written. So, the first thing I'll do is 
add a reference to it whenever I create a new project.

The extension classes in the library are listed below with links to their documentation. The 
documentation is generated with the [Literate Programming](https://johtela.github.io/LiterateProgramming) 
tool, which is another project of mine.

## Contents

* [ArrayExt](ExtensionCord/ArrayExt.html) class contains methods that help accessing and modifying arrays.
* [BoolExt](ExtensionCord/ArrayExt.html) has few extension methods for booleans.
* [Either](ExtensionCord/Either.html) a generic class that can contain one of two possible values. 
* [EnumerableExt](ExtensionCord/EnumerableExt.html) contains a lot of extenion methods for the IEnumerable 
  interface.
* [Fun](ExtensionCord/Fun.html) is a static class that contains methods for generic delegates Func and Action.
* [NumExt](ExtensionCord/NumExt.html) extends number types `int`, `float`, and `double`.
* [ObjectExt](ExtensionCord/ObjectExt.html) has few generic extension methods which work with any type.
* [Params](ExtensionCord/Params.html) is a base class for key-value collections that can be constructed
  with collection initializers.
* [ReflectionExt](ExtensionCord/ReflectionExt.html) extends classes related to reflection.
* [Seq](ExtensionCord/Seq.html) is a minimal implementation of an immutable, singly-linked list.
* [StringExt](ExtensionCord/StringExt.html) has some methods that help string manipulation.
* [TupleExt](ExtensionCord/TupleExt.html) extends tuples with a couple of helper methods.