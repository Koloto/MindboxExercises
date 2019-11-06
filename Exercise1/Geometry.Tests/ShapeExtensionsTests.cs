using System.Collections.Generic;
using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.Tests
{
	/// <summary>
	/// Тесты для методов класса <see cref="ShapeExtensions"/>
	/// </summary>
	public class ShapeExtensionsTests
	{
		/// <summary>
		/// Произвольная нестандартная фигура-заглушка
		/// </summary>
		/// <remarks>
		/// Если таких заглушек будет много, то имеет смысл подключить какую-либо библиотеку для их создания, например, Moq.
		/// </remarks>
		class CustomShape : IShape
		{
			public double Area { get; }

			public CustomShape(double area)
			{
				Area = area;
			}

			public double CalculateArea()
			{
				return Area;
			}
		}

		[Test]
		public void CalculateTotalArea_NullArgument_Throws()
		{
			IEnumerable<IShape> shapes = null;
			Assert.That(() => shapes.CalculateTotalArea(), Throws.ArgumentNullException);
		}

		[Test]
		public void CalculateTotalArea_DifferentShapes_ReturnsSumOfAreas()
		{
			var circle = new Circle(10);
			var triangle = new Triangle(3, 4, 5);
			IShape[] shapes = { circle, triangle };

			var expectedArea = circle.CalculateArea() + triangle.CalculateArea();
			Assert.That(shapes.CalculateTotalArea(), Is.EqualTo(expectedArea).Within(0.00000001));
		}

		[Test]
		public void CalculateTotalArea_CustomShapes_ReturnsSumOfAreas()
		{
			var shape1 = new CustomShape(10);
			var shape2 = new CustomShape(20);
			IShape[] shapes = { shape1, shape2 };

			var expectedArea = shape1.CalculateArea() + shape2.CalculateArea();
			Assert.That(shapes.CalculateTotalArea(), Is.EqualTo(expectedArea).Within(0.00000001));
		}
	}
}
