---
ProjectName: ExtensionCord
GitHub: https://github.com/johtela/ExtensionCord
Footer: "Copyright © 2018 Tommi Johtela"
License: License.html
ShowDescriptionsInToc: true
MarkdownStyle: plain
SyntaxHighlight: coding-horror
UseDiagrams: true
DiagramStyle: mermaid
UseMath: true
---
![Logo](images/extension-cord.svg){.img-responsive .center-block}
# ExtensionCord - Useful Extensions for .NET Types

This assembly contains useful extension methods and helper classes for standard .NET types. They have 
came in handy in many projects I have authored in the past. So, I gave them a home in their own assembly 
and created a nuget package for it.

The name of the library stems from my woodworking hobby. The first thing I usually do before 
starting a woodworking project is get the extension cord to power my tools. This library is 
similar in the way that its methods are needed in pretty much all C# code I write. So, the first 
thing I'll do is add reference to it whenever I create a new project.

The extension classes in the library are listed below with links to their documentation. The documentation 
is generated with the [Literate Programming](https://johtela.github.io/LiterateProgramming) tool I have 
also written.

## Contents

* [ArrayExt](src/ArrayExt.html) class contains methods that help accessing and modifying arrays.
* [BoolExt](src/ArrayExt.html) has few extension methods for booleans.
* [Either](src/Either.html) a generic class that can contain one of two possible values. 
* [EnumerableExt](src/EnumerableExt.html) contains a lot of extenion methods for the IEnumerable 
  interface.
* [Fun](src/Fun.html) is a static class that contains methods for generic delegates Func and Action.
* [NumExt](src/NumExt.html) extends number types `int`, `float`, and `double`.
* [ObjectExt](src/ObjectExt.html) has few generic extension methods which work with any type.
* [Params](src/Params.html) is a base class for key-value collections that can be constructed
  with collection initializers.
* [ReflectionExt](src/ReflectionExt.html) extends classes related to reflection.
* [Seq](src/Seq.html) is a minimal implementation of an immutable, singly-linked list.
* [StringExt](src/StringExt.html) has some methods that help string manipulation.
* [TupleExt](src/TupleExt.html) extends tuples with a couple of helper methods.