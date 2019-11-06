using System;

namespace Geometry.Shapes
{
	/// <summary>
	/// Треугольник
	/// </summary>
	/// <remarks>
	/// Если критична производительность, то вместо класса можно использовать readonly struct.
	/// Но это порождает ряд проблем, например:
	///  - при использовании конструктора по умолчанию будут нулевые стороны,
	///  - boxing/unboxing при передаче параметров типа <see cref="IShape"/>.
	/// </remarks>
	public class Triangle : IShape
	{
		/// <summary>
		/// Относительная погрешность по умолчанию, используемая при сравнении чисел с плавающей точкой.
		/// </summary>
		public const double DefaultTolerance = 1.0e-15;

		/// <summary>
		/// Сторона A
		/// </summary>
		public double SideA { get; }

		/// <summary>
		/// Сторона B
		/// </summary>
		public double SideB { get; }

		/// <summary>
		/// Сторона С
		/// </summary>
		public double SideC { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="sideA">Сторона A</param>
		/// <param name="sideB">Сторона B</param>
		/// <param name="sideC">Сторона C</param>
		/// <exception cref="ArgumentOutOfRangeException">Если хотя бы одна сторона меньше или равна нулю.</exception>
		/// <exception cref="ArgumentException">Если хотя бы одна сторона больше или равна сумме двух других сторон.</exception>
		public Triangle(double sideA, double sideB, double sideC)
		{
			if (sideA <= 0)
				throw new ArgumentOutOfRangeException(nameof(sideA), Resources.Triangle_SidesMustBePositive);
			if (sideB <= 0)
				throw new ArgumentOutOfRangeException(nameof(sideB), Resources.Triangle_SidesMustBePositive);
			if (sideC <= 0)
				throw new ArgumentOutOfRangeException(nameof(sideC), Resources.Triangle_SidesMustBePositive);
			if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB)
				throw new ArgumentException(Resources.Triangle_AnySideMustBeShorterThanSumOfTwoOthers);

			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
		}

		/// <inheritdoc cref="IShape.CalculateArea"/>
		public double CalculateArea()
		{
			double p = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
		}

		/// <summary>
		/// Проверяет, является ли треугольник прямоугольным
		/// </summary>
		/// <param name="tolerance">Относительная погрешность при сравнении</param>
		public bool IsRightAngled(double tolerance = DefaultTolerance)
		{
			if (tolerance < 0)
				throw new ArgumentOutOfRangeException(nameof(tolerance), Resources.Triangle_ToleranceMustBeNotNegative);

			// Отсортируем стороны по возрастанию длины
			double[] sides = { SideA, SideB, SideC };
			Array.Sort(sides);

			// Проверим теорему Пифагора (после сортировки sides[0] и sides[1] - это потенциальные катеты,
			// а sides[2] - гипотенуза).
			// NOTE: Нельзя использовать точное сравнение для типов с плавающей точкой.
			return Math.Abs((sides[0] * sides[0] + sides[1] * sides[1]) / (sides[2] * sides[2]) - 1.0) <= tolerance;
		}
	}
}