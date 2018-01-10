/*
# Immutable Singly Linked List

The data structure that is employed by practically every functional programming 
language is singly linked list. Operations defined for the list are pure which 
makes the list immutable. None of the operations modify the existing list, but 
always return a new version of it. Structural sharing makes these operations 
efficient.

The figure below depicts two sequences [1, 2, 3] and [4, 2, 3] which share the 
same suffix [2, 3].

```mermaid
graph LR
    A(First = 1) -->|Rest| B(First = 2)
    B -->|Rest| C(First = 3)
    C -->|Rest| D[null]
	E(First = 4) -->|Rest| B
```

Since this data structure is useful in many algorithms and .NET framework does 
not provide one out-of-the-box, we define a minimal implementation here. We 
could use the 
[System.Collections.Immutable](https://www.nuget.org/packages/System.Collections.Immutable/) 
Nuget package provided by Microsoft, but it brings with it a long chain of 
dependencies. So, we will roll our own implementation to limit the dependencies 
to .NET framework only.
*/
namespace ExtensionCord
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Text;
	/*
	## The Seq<T> Class

	For brevity, we will call the data structure `Seq<T>`. The name stands for
	sequence, an abstraction that represents a stream of data that can be 
	traversed only forward. The class implements IEnumerable<T> which is 
	a similar abstraction, but inherently mutable.
	*/
	public class Seq<T> : IEnumerable<T>
	{
		/*
		### First and Rest

		The data structure has two parts: the first item (commonly also called
		as _head_) and the rest of the sequence (_tail_). The rest points to 
		another sequence, which makes the data structure recursive. If the rest 
		is `null`, then we are at the end of the sequence. An empty sequence 
		is represented simply by `null`.
		*/
		public T First { get; private set; }
		public Seq<T> Rest { get; private set; }

		internal Seq (T first, Seq<T> rest)
		{
			First = first;
			Rest = rest;
		}
		/*
		### The | Operator

		The pipe `|` operator constructs a new sequence by prepending a new 
		item at the front. This is a $O(1)$ operation since the rest part
		of the existing sequence is used as-is. Internally this operation 
		uses the static `Cons` constructor.
		*/
		public static Seq<T> operator |(T first, Seq<T> rest) => 
			Seq.Cons(first, rest);
		/*
		### Constructing from IEnumerable

		We cheat a bit when sequence is created from IEnumerable. The sequence
		is mutated when it is being constructed. This is ok, since we don't
		return the sequence to the caller until it is ready. So, from the 
		caller's point of view, the sequence is immutable.
		*/
		public static Seq<T> FromEnumerable (IEnumerable<T> enumerable)
		{
			Seq<T> prev = null, result = null;
			foreach (var item in enumerable)
			{
				var curr = new Seq<T> (item, null);
				if (prev == null)
					result = curr;
				else
					prev.Rest = curr;
				prev = curr;
			}
			return result;
		}

		/*
		### IEnumerable Implementation

		By employing an iterator the IEnumerable implementation becomes trivial.
		*/
		public IEnumerator<T> GetEnumerator ()
		{
			for (var node = this; node != null; node = node.Rest)
				yield return node.First;
		}

		IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();
		/*
		### Converting to String

		A sequence can be printed as string. The parameters specify how the it is
		formatted. What opening and closing bracket are used, and what string 
		separates the items.
		*/
		public string ToString(string openBracket, string separator, string closeBracket)
		{
			var res = new StringBuilder(openBracket);
			for (var item = this; item != null; item = item.Rest)
			{
				res.Append(item.First);
				if (item.Rest != null)
					res.Append(separator);
			}
			res.Append(closeBracket);
			return res.ToString();
		}

		public override string ToString() =>
			ToString("[ ", ", ", " ]");
	}
	/*
	## Static Methods

	The static methods are defined in the separate Seq class. This is a
	normal static class without any type parameters. We do this to avoid 
	having to type the generic parameter when calling the static methods.
	*/
	public static class Seq
	{
		/*
		### Is Sequence Empty

		The test for empty sequence just checks if the parameter is `null`.
		*/
		public static bool IsEmpty<T> (this Seq<T> seq)
		{
			return seq == null;
		}
		/*
		### Constructing a Sequence

		The simplest way to construct a sequence is to give the first item
		and the rest of the sequence. The second parameter can be omitted to 
		create a sequence with a single item.
		*/
		public static Seq<T> Cons<T> (T first, Seq<T> rest = null) => 
			new Seq<T> (first, rest);
		/*
		The following is a convenience method that extends IEnumerable
		with a way to convert it to sequence.
		*/
		public static Seq<T> ToSeq<T> (this IEnumerable<T> enumerable)
		{
			return Seq<T>.FromEnumerable (enumerable);
		}
		/*
		### Removing an Item

		Removing an item is not a cheap operation since it requires at
		least a part of the sequence to be copied. It also uses recursion,
		so this method should be used only with very short sequences. If 
		you try to use it with a too long sequence, you will get a stack
		overflow exception.
		*/
		public static Seq<T> Remove<T> (this Seq<T> seq, T item)
		{
			if (seq == null)
				throw new ArgumentException ("Item not found in sequence.");
			if (seq.First.Equals (item))
				return seq.Rest;
			return Cons (seq.First, Remove (seq.Rest, item));
		}
		/*
		### Searching for an Item

		Searching is also a trivial operation, but $O(n)$ in complexity.
		*/
		public static bool Contains<T> (this Seq<T> seq, T item)
		{
			var s = seq;
			while (!(s == null || s.First.Equals (item)))
				s = s.Rest;
			return s != null;
		}
	}
}