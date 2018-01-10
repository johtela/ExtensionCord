/*
# Either<T, U> Type

The Either class is a general purpose container for a value that can be one 
of two possible options. The class is useful, for example, when a function
wants to return either a result value, or an error message. The two cases are 
distinct. The class can contain either the result or the error, but not both. 
Hence the name.

A similar type is commonly found in functional languages which implement the concept 
as discriminated union. Pattern matching is typically used to decide what to do in
either case. Since pattern matching and case expressions are not (really) available 
in C#, we provide matching as an extension method.
*/
namespace ExtensionCord
{
    using System;
	/*
	## Exception Type

	If you try to access an invalid choice an exception is thrown. We define a specific
	exception type for this, since it might be convenient sometimes to handle the case
	matching through exceptions.
	*/
    public class EitherException : Exception
    {
        public EitherException (string choice) : base ("The choice '{0}' is not valid.")
        { }
    }
	/*
	## Structure of the Type

	The type contains two properties that represent the different choices of values.
	Either one of them is available at any given time. For a lack of better terms, 
	we name the propeties `Left` and `Right` and define them as abstract. Private, 
	inner sub-classes implement one of them, and throw an exception from the other 
	one. So, internally there are three different classes in play, but only one of 
	them exposed to the outside.
	*/
	public abstract class Either<T, U>
    {
        public abstract T Left { get; }
        public abstract U Right { get; }

        private class _Left : Either<T, U>
        {
            private T _left;

            public _Left (T left)
            {
                _left = left;
            }

            public override T Left
            {
                get { return _left; }
            }

            public override U Right
            {
                get { throw new EitherException ("Right"); }
            }
        }

        private class _Right : Either<T, U>
        {
            private U _right;

            public _Right (U right)
            {
                _right = right;
            }

            public override T Left
            {
                get { throw new EitherException ("Left"); }
            }

            public override U Right
            {
                get { return _right; }
            }
        }
		/*
		## Creating an Either<T, U>

		There are naturally two ways to construct a value of the Either<T, U> 
		type. You can give the left or right value, and based on that the
		correct private sub-class is created.
		*/
        public static Either<T, U> Create (T value)
        {
            return new _Left (value);
        }

        public static Either<T, U> Create (U value)
        {
            return new _Right (value);
        }
		/*
		## Pattern Matching

		Typically you want to do different things depending on which option
		is active. For that reason, we define a method that calls different
		delegate based on the actual type of the class.
		*/
        public V Match<V> (Func<T, V> left, Func<U, V> right)
        {
            if (this is _Left)
                return left (Left);
            else
                return right (Right);
        }
		/*
		## Checking Which Choice is Active

		To check if the left or right branch is active, we define two
		properties to test that.
		*/
        public bool IsLeft
        {
            get { return this is _Left; }
        }

        public bool IsRight
        {
            get { return this is _Right; }
        }
    }
}