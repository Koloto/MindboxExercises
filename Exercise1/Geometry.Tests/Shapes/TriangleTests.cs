using System;
using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.Tests.Shapes
{
	/// <summary>
	/// Тесты для треугольника
	/// </summary>
	public class TriangleTests
	{
		[TestCase(-3, 4, 5)]
		[TestCase(3, -4, 5)]
		[TestCase(3, 4, -5)]
		[TestCase(0, 4, 5)]
		[TestCase(3, 0, 5)]
		[TestCase(3, 4, 0)]
		public void Constructor_NotPositiveSide_Throws(double sideA, double sideB, double sideC)
		{
			Assert.That(() => new Triangle(sideA, sideB, sideC), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[TestCase(10, 4, 5)]
		[TestCase(3, 10, 5)]
		[TestCase(3, 4, 10)]
		public void Constructor_TooLargeSide_Throws(double sideA, double sideB, double sideC)
		{
			Assert.That(() => new Triangle(sideA, sideB, sideC), Throws.TypeOf<ArgumentException>());
		}

		[TestCase(3, 4, 5, 6)]
		[TestCase(12, 13, 5, 30)]
		[TestCase(6, 5, 5, 12)]
		[TestCase(0.6, 0.5, 0.5, 0.12)]
		public void CalculateArea_ReturnsExpected(double sideA, double sideB, double sideC, double expectedArea)
		{
			Assert.That(new Triangle(sideA, sideB, sideC).CalculateArea(), Is.EqualTo(expectedArea).Within(0.00000001));
		}

		[TestCase(3, 4, 5)]
		[TestCase(0.3, 0.4, 0.5)]
		[TestCase(12, 13, 5)]
		[TestCase(0.12, 0.13, 0.05)]
		public void IsRightAngled_Right_ReturnsTrue(double sideA, double sideB, double sideC)
		{
			Assert.That(new Triangle(sideA, sideB, sideC).IsRightAngled(), Is.True);
		}

		[TestCase(3, 4, 4.5)]
		[TestCase(3, 4, 5.000001)]
		[TestCase(3, 4, 4.999999)]
		public void IsRightAngled_NotRight_ReturnsFalse(double sideA, double sideB, double sideC)
		{
			Assert.That(new Triangle(sideA, sideB, sideC).IsRightAngled(), Is.False);
		}

		[TestCase(3, 4, 5.000001)]
		[TestCase(3, 4, 4.999999)]
		public void IsRightAngled_NearlyRight_WithTolerance_ReturnsTrue(double sideA, double sideB, double sideC)
		{
			Assert.That(new Triangle(sideA, sideB, sideC).IsRightAngled(0.000001), Is.True);
		}

		[TestCase(-1)]
		[TestCase(-Double.Epsilon)]
		public void IsRightAngled_NegativeTolerance_Throws(double tolerance)
		{
			var triangle = new Triangle(3, 4, 5);
			Assert.That(() => triangle.IsRightAngled(tolerance), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
	}
}