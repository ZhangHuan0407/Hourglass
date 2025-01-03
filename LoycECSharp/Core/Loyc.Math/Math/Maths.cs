//
// Math operation structures produced with the help of T4 (Maths.tt)
// NOTE: THIS CODE HAS NOT BEEN WELL-TESTED AND DOES NOT YET HAVE A TEST SUITE.
// 





using System.Collections.Generic;



namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.SByte;

	/// <summary>Implements <see cref="IIntMath{T}"/> for numbers of type System.SByte.</summary>
	public struct MathI8 : IIntMath<sbyte>
	{
		public static readonly MathI8 Value = new MathI8();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 7; } }
		public int MaxIntPowerOf2   { get { return 7; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.SByte.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.SByte.MinValue; } }
		public T Zero       { get { return (sbyte)0; } }
		public T One        { get { return (sbyte)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return t > (uint)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return t > (int)T.MaxValue ? T.MaxValue : 
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }



		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Byte;

	/// <summary>Implements <see cref="IUIntMath{T}"/> for numbers of type System.Byte.</summary>
	public struct MathU8 : IUIntMath<byte>
	{
		public static readonly MathU8 Value = new MathU8();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { throw new NotSupportedException(); } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return false; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 8; } }
		public int MaxIntPowerOf2   { get { return 8; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.Byte.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.Byte.MinValue; } }
		public T Zero       { get { return (byte)0; } }
		public T One        { get { return (byte)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region IMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return t > (uint)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return t > (int)T.MaxValue ? T.MaxValue : 
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return a; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }



		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Int16;

	/// <summary>Implements <see cref="IIntMath{T}"/> for numbers of type System.Int16.</summary>
	public struct MathI16 : IIntMath<short>
	{
		public static readonly MathI16 Value = new MathI16();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 15; } }
		public int MaxIntPowerOf2   { get { return 15; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.Int16.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.Int16.MinValue; } }
		public T Zero       { get { return (short)0; } }
		public T One        { get { return (short)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return t > (uint)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return t > (int)T.MaxValue ? T.MaxValue : 
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }



		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.UInt16;

	/// <summary>Implements <see cref="IUIntMath{T}"/> for numbers of type System.UInt16.</summary>
	public struct MathU16 : IUIntMath<ushort>
	{
		public static readonly MathU16 Value = new MathU16();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { throw new NotSupportedException(); } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return false; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 16; } }
		public int MaxIntPowerOf2   { get { return 16; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.UInt16.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.UInt16.MinValue; } }
		public T Zero       { get { return (ushort)0; } }
		public T One        { get { return (ushort)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region IMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return t > (uint)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return t > (int)T.MaxValue ? T.MaxValue : 
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return a; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }



		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Int32;

	/// <summary>Implements <see cref="IIntMath{T}"/> for numbers of type System.Int32.</summary>
	public struct MathI : IIntMath<int>
	{
		public static readonly MathI Value = new MathI();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 31; } }
		public int MaxIntPowerOf2   { get { return 31; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.Int32.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.Int32.MinValue; } }
		public T Zero       { get { return (int)0; } }
		public T One        { get { return (int)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return t > (uint)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return
		                   (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)MathEx.MulDiv(a, mul, div); }



		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.UInt32;

	/// <summary>Implements <see cref="IUIntMath{T}"/> for numbers of type System.UInt32.</summary>
	public struct MathU : IUIntMath<uint>
	{
		public static readonly MathU Value = new MathU();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { throw new NotSupportedException(); } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return false; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 32; } }
		public int MaxIntPowerOf2   { get { return 32; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.UInt32.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.UInt32.MinValue; } }
		public T Zero       { get { return (uint)0; } }
		public T One        { get { return (uint)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region IMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return(T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return t > (long)T.MaxValue ? T.MaxValue : 
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return a; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)MathEx.MulDiv(a, mul, div); }



		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Int64;

	/// <summary>Implements <see cref="IIntMath{T}"/> for numbers of type System.Int64.</summary>
	public struct MathL : IIntMath<long>
	{
		public static readonly MathL Value = new MathL();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 63; } }
		public int MaxIntPowerOf2   { get { return 63; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.Int64.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.Int64.MinValue; } }
		public T Zero       { get { return (long)0; } }
		public T One        { get { return (long)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return(T)t; }
		public T Clip(ulong t)  { return t > (ulong)T.MaxValue ? T.MaxValue : (T)t; }
		public T Clip(int t)    { return
		                   (T)t; }
		public T Clip(long t)   { return
		                   (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)MathEx.MulDiv(a, mul, div); }



		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.UInt64;

	/// <summary>Implements <see cref="IUIntMath{T}"/> for numbers of type System.UInt64.</summary>
	public struct MathUL : IUIntMath<ulong>
	{
		public static readonly MathUL Value = new MathUL();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return 1; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { throw new NotSupportedException(); } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return false; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return true; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 64; } }
		public int MaxIntPowerOf2   { get { return 64; } }
		public ulong MaxInt { get { return (ulong)(ulong)System.UInt64.MaxValue; } }
		public long MinInt  { get { return (long)(long)System.UInt64.MinValue; } }
		public T Zero       { get { return (ulong)0; } }
		public T One        { get { return (ulong)1; } }


		public T Floor(T a)               { return a; }
		public T Ceiling(T a)             { return a; }


		#endregion

		#region IMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }


		public T Clip(uint t)   { return(T)t; }
		public T Clip(ulong t)  { return(T)t; }
		public T Clip(int t)    { return
		                    t < (int)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(long t)   { return
		                    t < (long)T.MinValue ? T.MinValue : (T)t; }
		public T Clip(double t) { return (T)t.PutInRange((double)0, (double)T.MaxValue); }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return a; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)MathEx.MulDiv(a, mul, div); }



		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return (T)MathEx.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return MathEx.CountOnes(a); }
		public int Log2Floor(T a)     { return MathEx.Log2Floor(a); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Single;

	/// <summary>Implements <see cref="IFloatMath{T}"/> for numbers of type System.Single.</summary>
	public struct MathF : IFloatMath<float>
	{
		public static readonly MathF Value = new MathF();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.PositiveInfinity; } }
		public T NegativeInfinity   { get { return T.NegativeInfinity; } }
		public T NaN                { get { return T.NaN; } }
		public bool IsInfinity(T value)   { return T.IsInfinity(value); }
		public bool IsNaN(T value)        { return T.IsNaN(value); }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return true; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 24; } }
		public int MaxIntPowerOf2   { get { return 128; } }
		public ulong MaxInt { get { return (ulong)ulong.MaxValue; } }
		public long MinInt  { get { return (long)long.MinValue; } }
		public T Zero       { get { return (float)0; } }
		public T One        { get { return (float)1; } }


		public T Floor(T a)               { return (T)System.Math.Floor(a); }
		public T Ceiling(T a)             { return (T)System.Math.Ceiling(a); }
		public T Round(T a)			      { return (T)System.Math.Round(a); }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }

		
		public T Clip(uint t)   { return (T)t; }
		public T Clip(int t)    { return (T)t; }
		public T Clip(ulong t)  { return (T)t; }
		public T Clip(long t)   { return (T)t; }
		public T Clip(double t) { return (T)t; }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { return MathEx.NextHigher(a); }
		public T NextLower(T a)             { return MathEx.NextLower(a); }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return MathEx.ShiftLeft(a, amount); }
		public T Shr(T a, int amount) { return MathEx.ShiftRight(a, amount); }

		public T Sqrt(T a)   { return (T)Math.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region ITrigonometry & IExp Members

		public T Asin(T a) { return (T)Math.Asin(a); }
		public T Acos(T a) { return (T)Math.Acos(a); }
		public T Atan(T a) { return (T)Math.Atan(a); }
		public T Atan2(T y, T x) { return (T)Math.Atan2(y, x); }

		public T Sin(T a) { return (T)Math.Sin(a); }
		public T Cos(T a) { return (T)Math.Cos(a); }
		public T Tan(T a) { return (T)Math.Tan(a); }

		public T Exp(T a)                 { return (T)Math.Exp(a); }
		public T Pow(T @base, T exponent) { return (T)Math.Pow(@base, exponent); }
		public T Ln(T a)                  { return (T)Math.Log(a); }
		#if CompactFramework
		public T Log(T a, T @base)        { return (T)(Math.Log(a) / Math.Log(@base)); }
		#else
		public T Log(T a, T @base)        { return (T)Math.Log(a, @base); }
		#endif

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = System.Double;

	/// <summary>Implements <see cref="IFloatMath{T}"/> for numbers of type System.Double.</summary>
	public struct MathD : IFloatMath<double>
	{
		public static readonly MathD Value = new MathD();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.PositiveInfinity; } }
		public T NegativeInfinity   { get { return T.NegativeInfinity; } }
		public T NaN                { get { return T.NaN; } }
		public bool IsInfinity(T value)   { return T.IsInfinity(value); }
		public bool IsNaN(T value)        { return T.IsNaN(value); }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return true; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 53; } }
		public int MaxIntPowerOf2   { get { return 1024; } }
		public ulong MaxInt { get { return (ulong)ulong.MaxValue; } }
		public long MinInt  { get { return (long)long.MinValue; } }
		public T Zero       { get { return (double)0; } }
		public T One        { get { return (double)1; } }


		public T Floor(T a)               { return (T)System.Math.Floor(a); }
		public T Ceiling(T a)             { return (T)System.Math.Ceiling(a); }
		public T Round(T a)			      { return (T)System.Math.Round(a); }


		#endregion

		#region ISignedMath


		public T From(uint t)   { return (T)t; }
		public T From(int t)    { return (T)t; }
		public T From(ulong t)  { return (T)t; }
		public T From(long t)   { return (T)t; }
		public T From(double t) { return (T)t; }

		
		public T Clip(uint t)   { return (T)t; }
		public T Clip(int t)    { return (T)t; }
		public T Clip(ulong t)  { return (T)t; }
		public T Clip(long t)   { return (T)t; }
		public T Clip(double t) { return (T)t; }



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { return MathEx.NextHigher(a); }
		public T NextLower(T a)             { return MathEx.NextLower(a); }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)(a * mul / div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return MathEx.ShiftLeft(a, amount); }
		public T Shr(T a, int amount) { return MathEx.ShiftRight(a, amount); }

		public T Sqrt(T a)   { return (T)Math.Sqrt(a); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region ITrigonometry & IExp Members

		public T Asin(T a) { return (T)Math.Asin(a); }
		public T Acos(T a) { return (T)Math.Acos(a); }
		public T Atan(T a) { return (T)Math.Atan(a); }
		public T Atan2(T y, T x) { return (T)Math.Atan2(y, x); }

		public T Sin(T a) { return (T)Math.Sin(a); }
		public T Cos(T a) { return (T)Math.Cos(a); }
		public T Tan(T a) { return (T)Math.Tan(a); }

		public T Exp(T a)                 { return (T)Math.Exp(a); }
		public T Pow(T @base, T exponent) { return (T)Math.Pow(@base, exponent); }
		public T Ln(T a)                  { return (T)Math.Log(a); }
		#if CompactFramework
		public T Log(T a, T @base)        { return (T)(Math.Log(a) / Math.Log(@base)); }
		#else
		public T Log(T a, T @base)        { return (T)Math.Log(a, @base); }
		#endif

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = FPI8;

	/// <summary>Implements <see cref="IRationalMath{T}"/> for numbers of type FPI8.</summary>
	public struct MathFPI8 : IRationalMath<T>, IBinaryMath<T>
	{
		public static readonly MathFPI8 Value = new MathFPI8();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 31; } }
		public int MaxIntPowerOf2   { get { return 23; } }
		public ulong MaxInt { get { return (ulong)(ulong)FPI8.MaxValue; } }
		public long MinInt  { get { return (long)(long)FPI8.MinValue; } }
		public T Zero       { get { return FPI8.Zero; } }
		public T One        { get { return FPI8.One; } }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Floor(T a)               { return a.Floor(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Ceiling(T a)             { return a.Ceiling(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Round(T a)			      { return a.Round(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Lerp(T a, T b, T t)
		{
			if (t > T.One)
			    t = T.One;
			else if (t < T.Zero)
				t = T.Zero;
			return (b - a) * t + a;
		}


		#endregion

		#region ISignedMath


		public T From(uint t)   { return T.FastCast(t); }
		public T From(int t)    { return T.FastCast(t); }
		public T From(ulong t)  { return T.FastCast((long)t); }
		public T From(long t)   { return T.FastCast(t); }
		public T From(double t) { return T.FastCast(t); }

		public T Clip(uint t)   { return new T(t); }
		public T Clip(int t)    { return new T(t); }
		public T Clip(ulong t)  { return new T(t); }
		public T Clip(long t)   { return new T(t); }
		public T Clip(double t) { return new T(t); }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)a.MulDiv(mul, div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return a.Sqrt(); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return a.CountOnes(); }
		public int Log2Floor(T a)     { return a.Log2Floor(); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = FPI16;

	/// <summary>Implements <see cref="IRationalMath{T}"/> for numbers of type FPI16.</summary>
	public struct MathFPI16 : IRationalMath<T>, IBinaryMath<T>
	{
		public static readonly MathFPI16 Value = new MathFPI16();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 31; } }
		public int MaxIntPowerOf2   { get { return 23; } }
		public ulong MaxInt { get { return (ulong)(ulong)FPI16.MaxValue; } }
		public long MinInt  { get { return (long)(long)FPI16.MinValue; } }
		public T Zero       { get { return FPI16.Zero; } }
		public T One        { get { return FPI16.One; } }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Floor(T a)               { return a.Floor(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Ceiling(T a)             { return a.Ceiling(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Round(T a)			      { return a.Round(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Lerp(T a, T b, T t)
		{
			if (t > T.One)
			    t = T.One;
			else if (t < T.Zero)
				t = T.Zero;
			return (b - a) * t + a;
		}


		#endregion

		#region ISignedMath


		public T From(uint t)   { return T.FastCast(t); }
		public T From(int t)    { return T.FastCast(t); }
		public T From(ulong t)  { return T.FastCast((long)t); }
		public T From(long t)   { return T.FastCast(t); }
		public T From(double t) { return T.FastCast(t); }

		public T Clip(uint t)   { return new T(t); }
		public T Clip(int t)    { return new T(t); }
		public T Clip(ulong t)  { return new T(t); }
		public T Clip(long t)   { return new T(t); }
		public T Clip(double t) { return new T(t); }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)a.MulDiv(mul, div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return a.Sqrt(); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return a.CountOnes(); }
		public int Log2Floor(T a)     { return a.Log2Floor(); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = FPI23;

	/// <summary>Implements <see cref="IRationalMath{T}"/> for numbers of type FPI23.</summary>
	public struct MathFPI23 : IRationalMath<T>, IBinaryMath<T>
	{
		public static readonly MathFPI23 Value = new MathFPI23();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 31; } }
		public int MaxIntPowerOf2   { get { return 23; } }
		public ulong MaxInt { get { return (ulong)(ulong)FPI23.MaxValue; } }
		public long MinInt  { get { return (long)(long)FPI23.MinValue; } }
		public T Zero       { get { return FPI23.Zero; } }
		public T One        { get { return FPI23.One; } }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Floor(T a)               { return a.Floor(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Ceiling(T a)             { return a.Ceiling(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Round(T a)			      { return a.Round(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Lerp(T a, T b, T t)
		{
			if (t > T.One)
			    t = T.One;
			else if (t < T.Zero)
				t = T.Zero;
			return (b - a) * t + a;
		}


		#endregion

		#region ISignedMath


		public T From(uint t)   { return T.FastCast(t); }
		public T From(int t)    { return T.FastCast(t); }
		public T From(ulong t)  { return T.FastCast((long)t); }
		public T From(long t)   { return T.FastCast(t); }
		public T From(double t) { return T.FastCast(t); }

		public T Clip(uint t)   { return new T(t); }
		public T Clip(int t)    { return new T(t); }
		public T Clip(ulong t)  { return new T(t); }
		public T Clip(long t)   { return new T(t); }
		public T Clip(double t) { return new T(t); }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)a.MulDiv(mul, div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return a.Sqrt(); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return a.CountOnes(); }
		public int Log2Floor(T a)     { return a.Log2Floor(); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = FPL16;

	/// <summary>Implements <see cref="IRationalMath{T}"/> for numbers of type FPL16.</summary>
	public struct MathFPL16 : IRationalMath<T>, IBinaryMath<T>
	{
		public static readonly MathFPL16 Value = new MathFPL16();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 63; } }
		public int MaxIntPowerOf2   { get { return 47; } }
		public ulong MaxInt { get { return (ulong)(ulong)FPL16.MaxValue; } }
		public long MinInt  { get { return (long)(long)FPL16.MinValue; } }
		public T Zero       { get { return FPL16.Zero; } }
		public T One        { get { return FPL16.One; } }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Floor(T a)               { return a.Floor(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Ceiling(T a)             { return a.Ceiling(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Round(T a)			      { return a.Round(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Lerp(T a, T b, T t)
		{
			if (t > T.One)
			    t = T.One;
			else if (t < T.Zero)
				t = T.Zero;
			return (b - a) * t + a;
		}


		#endregion

		#region ISignedMath


		public T From(uint t)   { return T.FastCast(t); }
		public T From(int t)    { return T.FastCast(t); }
		public T From(ulong t)  { return T.FastCast((long)t); }
		public T From(long t)   { return T.FastCast(t); }
		public T From(double t) { return T.FastCast(t); }

		public T Clip(uint t)   { return new T(t); }
		public T Clip(int t)    { return new T(t); }
		public T Clip(ulong t)  { return new T(t); }
		public T Clip(long t)   { return new T(t); }
		public T Clip(double t) { return new T(t); }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)a.MulDiv(mul, div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return a.Sqrt(); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return a.CountOnes(); }
		public int Log2Floor(T a)     { return a.Log2Floor(); }

		#endregion

	}
}


namespace Loyc.Math
{
	using System;
	using System.Runtime.CompilerServices;
	using T = FPL32;

	/// <summary>Implements <see cref="IRationalMath{T}"/> for numbers of type FPL32.</summary>
	public struct MathFPL32 : IRationalMath<T>, IBinaryMath<T>
	{
		public static readonly MathFPL32 Value = new MathFPL32();

		#region INumTraits

		public T MinValue           { get { return T.MinValue; } }
		public T MaxValue           { get { return T.MaxValue; } }
		public T Epsilon            { get { return T.Epsilon; } }
		public T PositiveInfinity   { get { return T.MaxValue; } }
		public T NegativeInfinity   { get { return T.MinValue; } }
		public T NaN                { get { throw new NotSupportedException(); } }
		public bool IsInfinity(T value)   { return false; }
		public bool IsNaN(T value)        { return false; }
		public bool IsSigned        { get { return true; } }
		public bool IsFloatingPoint { get { return false; } }
		public bool IsInteger       { get { return false; } }
		public bool IsOrdered       { get { return true; } }
		public int SignificantBits  { get { return 63; } }
		public int MaxIntPowerOf2   { get { return 31; } }
		public ulong MaxInt { get { return (ulong)(ulong)FPL32.MaxValue; } }
		public long MinInt  { get { return (long)(long)FPL32.MinValue; } }
		public T Zero       { get { return FPL32.Zero; } }
		public T One        { get { return FPL32.One; } }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Floor(T a)               { return a.Floor(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Ceiling(T a)             { return a.Ceiling(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Round(T a)			      { return a.Round(); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Lerp(T a, T b, T t)
		{
			if (t > T.One)
			    t = T.One;
			else if (t < T.Zero)
				t = T.Zero;
			return (b - a) * t + a;
		}


		#endregion

		#region ISignedMath


		public T From(uint t)   { return T.FastCast(t); }
		public T From(int t)    { return T.FastCast(t); }
		public T From(ulong t)  { return T.FastCast((long)t); }
		public T From(long t)   { return T.FastCast(t); }
		public T From(double t) { return T.FastCast(t); }

		public T Clip(uint t)   { return new T(t); }
		public T Clip(int t)    { return new T(t); }
		public T Clip(ulong t)  { return new T(t); }
		public T Clip(long t)   { return new T(t); }
		public T Clip(double t) { return new T(t); }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLess(T a, T b)        { return a < b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsLessOrEqual(T a, T b) { return a <= b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Abs(T a)                   { return (T)(a >= Zero ? a : -a); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b)              { return a > b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c)
		{
			T max = a > b ? a : b;
			return max > c ? max : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Max(T a, T b, T c, T d)
		{
			T max = a > b ? a : b;
			max = max > c ? max : c;
			return max > d ? max : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b)              { return a < b ? a : b; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c)
		{
			T min = a < b ? a : b;
			return min < c ? min : c;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Min(T a, T b, T c, T d)
		{
			T min = a < b ? a : b;
			min = min < c ? min : c;
			return min < d ? min : d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y)        { return x.CompareTo(y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(T x, T y)        { return x == y; }
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetHashCode(T x)         { return x.GetHashCode(); }

		public T AddOne(T a)                { a++; return a; }
		public T SubOne(T a)                { a--; return a; }

		public T NextHigher(T a)            { a++; return a; }
		public T NextLower(T a)             { a--; return a; }


		public T Add(T a, T b)              { return (T)(a + b); }
		public T Add(T a, T b, T c)         { return (T)(a + b + c); }
		public T Sub(T a, T b)              { return (T)(a - b); }
		public T Mul(T a, T b)              { return (T)(a * b); }
		public T Div(T a, T b)              { return (T)(a / b); }
		public T MulDiv(T a, T mul, T div)  { return (T)a.MulDiv(mul, div); }


		public T Reciprocal(T a) { return One / a; }


		public T Negate(T a) { return (T)(-a); }


		public T Shl(T a, int amount) { return (T)(a << amount); }
		public T Shr(T a, int amount) { return (T)(a >> amount); }

		public T Sqrt(T a)   { return a.Sqrt(); }
		public T Square(T a) { return (T)(a * a); }

		#endregion


		#region BinaryMath

		public T And(T a, T b) { return (T)(a & b); }
		public T Or(T a, T b)  { return (T)(a | b); }
		public T Xor(T a, T b) { return (T)(a ^ b); }
		public T Not(T a)      { return (T)~a; }

		public int CountOnes(T a)     { return a.CountOnes(); }
		public int Log2Floor(T a)     { return a.Log2Floor(); }

		#endregion

	}
}

