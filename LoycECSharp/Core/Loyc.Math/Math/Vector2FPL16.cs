using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Loyc.Math
{
	[Serializable]
    public struct Vector2FPL16
    {
		/// <summary>
		/// (0, 0)
		/// </summary>
        public static readonly Vector2FPL16 Zero = new Vector2FPL16(FPL16.Zero, FPL16.Zero);
		/// <summary>
		/// (1, 0)
		/// </summary>
		public static readonly Vector2FPL16 Right = new Vector2FPL16(FPL16.One, FPL16.Zero);
		/// <summary>
		/// (-1, 0)
		/// </summary>
		public static readonly Vector2FPL16 Left = new Vector2FPL16(-FPL16.One, FPL16.Zero);
		/// <summary>
		/// (0, 1)
		/// </summary>
		public static readonly Vector2FPL16 Up = new Vector2FPL16(FPL16.Zero, FPL16.One);
		/// <summary>
		/// (0, -1)
		/// </summary>
		public static readonly Vector2FPL16 Down = new Vector2FPL16(FPL16.Zero, -FPL16.One);
		/// <summary>
		/// (1, 1)
		/// </summary>
		public static readonly Vector2FPL16 One = new Vector2FPL16(FPL16.One, FPL16.One);

        private const long DotZeroOne_Prescaled = 655;
        private const long _10_Prescaled = 655360;

        public FPL16 x;
        public FPL16 y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FPL16(FPL16 x, FPL16 y)
        {
            this.x = x;
            this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FPL16(Vector2Int vector2Int)
        {
            x = vector2Int.x;
            y = vector2Int.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 Prescaled(long x, long y)
        {
            Vector2FPL16 result;
            result.x.N = x;
            result.y.N = y;
            return result;
        }

        public FPL16 Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (x * x + y * y).Sqrt();
        }
        public FPL16 SqrMagnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x * x + y * y;
        }

        public Vector2FPL16 Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Vector2FPL16 result = this;
                result.Normalize();
                return result;
            }
        }

        public Vector2 ToVector2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2((float)x, (float)y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Abs()
        {
            x.N = x.N < 0 ? -x.N : x.N;
            y.N = y.N < 0 ? -y.N : y.N;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            long sumAbs = x.Abs().N + y.Abs().N;
            if (sumAbs > _10_Prescaled)
            {
                FPL16 magnitude = Magnitude;
                this /= magnitude;
            }
            else if (sumAbs > DotZeroOne_Prescaled)
            {
                FPL16 magnitude = FPL16.Prescaled(x.N * x.N + y.N * y.N).Sqrt();
				x.N = (x.N << 24) / magnitude.N;
				y.N = (y.N << 24) / magnitude.N;
			}
            else
                this = Zero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2FPL16 left, Vector2FPL16 right) => left.x.N == right.x.N && left.y.N == right.y.N;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2FPL16 left, Vector2FPL16 right) => left.x.N != right.x.N || left.y.N != right.y.N;
        public override int GetHashCode() => ((int)x.N ^ (int)(x.N >> 32)) ^ (((int)y.N ^ (int)(y.N >> 32)) << 2);

        public override bool Equals(object obj)
        {
            if (obj is Vector2FPL16 value)
                return this == value;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator +(Vector2FPL16 left, Vector2FPL16 right) => Prescaled(left.x.N + right.x.N, left.y.N + right.y.N);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator -(Vector2FPL16 left, Vector2FPL16 right) => Prescaled(left.x.N - right.x.N, left.y.N - right.y.N);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator *(Vector2FPL16 a, FPL16 d) => new Vector2FPL16(a.x * d, a.y * d);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2FPL16 operator *(FPL16 d, Vector2FPL16 a) => new Vector2FPL16(a.x * d, a.y * d);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator /(Vector2FPL16 a, FPL16 d) => new Vector2FPL16(a.x / d, a.y / d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator -(Vector2FPL16 value) => new Vector2FPL16(FPL16.Prescaled(-value.x.N), FPL16.Prescaled(-value.y.N));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator *(Vector2FPL16 a, int d) => Prescaled(a.x.N * d, a.y.N * d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FPL16 operator /(Vector2FPL16 a, int d) => Prescaled(a.x.N / d, a.y.N / d);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FPL16 Dot(Vector2FPL16 lhs, Vector2FPL16 rhs) => lhs.x * rhs.x + lhs.y * rhs.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2FPL16 Lerp(Vector2FPL16 a, Vector2FPL16 b, FPL16 t)
		{
			t = MathFPL16.Value.Clamp01(t);
			return new Vector2FPL16(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2FPL16 LerpUnclamped(Vector2FPL16 a, Vector2FPL16 b, FPL16 t)
		{
			return new Vector2FPL16(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"({x}, {y})";
    }
}