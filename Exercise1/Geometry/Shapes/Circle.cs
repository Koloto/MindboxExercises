using System;

namespace Geometry.Shapes
{
	/// <summary>
	/// Круг
	/// </summary>
	/// <remarks>
	/// Если критична производительность, то вместо класса можно использовать readonly struct.
	/// Но это порождает ряд проблем, например:
	///  - при использовании конструктора по умолчанию будет нулевой радиус,
	///  - boxing/unboxing при передаче параметров типа <see cref="IShape"/>.
	/// </remarks>
	public class Circle : IShape
	{
		/// <summary>
		/// Радиус
		/// </summary>
		public double Radius { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="radius">Радиус круга</param>
		public Circle(double radius)
		{
			if (radius <= 0)
				throw new ArgumentOutOfRangeException(nameof(radius), Resources.Circle_RadiusMustBePositive);

			Radius = radius;
		}

		/// <inheritdoc cref="IShape.CalculateArea"/>
		public double CalculateArea() => Math.PI * Radius * Radius;
	}
}