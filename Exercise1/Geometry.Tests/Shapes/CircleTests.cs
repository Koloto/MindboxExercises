using System;
using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.Tests.Shapes
{
	/// <summary>
	/// Тесты для круга
	/// </summary>
	public class CircleTests
	{
		[TestCase(-1)]
		[TestCase(0)]
		public void Constructor_NotPositiveRadius_Throws(double radius)
		{
			Assert.That(() => new Circle(radius), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[TestCase(1)]
		[TestCase(10.0)]
		[TestCase(0.3333)]
		public void CalculateArea_ReturnsExpected(double radius)
		{
			Assert.That(new Circle(radius).CalculateArea(), Is.EqualTo(Math.PI * radius * radius));
		}
	}
}