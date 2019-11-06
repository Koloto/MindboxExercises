using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
	/// <summary>
	/// Вспомогательные методы расширения для геометрических фигур
	/// </summary>
	public static class ShapeExtensions
	{
		/// <summary>
		/// Вычисляет суммарную площадь нескольких фигур.
		/// </summary>
		/// <param name="shapes">Перечень фигур</param>
		/// <returns>Суммарная площадь всех фигур из <paramref name="shapes"/>.</returns>
		public static double CalculateTotalArea(this IEnumerable<IShape> shapes)
		{
			if (shapes == null)
				throw new ArgumentNullException(nameof(shapes));

			return shapes.Select(s => s.CalculateArea()).Sum();
		}
	}
}
