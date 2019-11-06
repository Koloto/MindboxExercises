namespace Geometry
{
	/// <summary>
	/// Базовый интерфейс для геометрических фигур
	/// </summary>
	public interface IShape
	{
		/// <summary>
		/// Вычисляет площадь фигуры
		/// </summary>
		/// <returns>Площадь фигуры</returns>
		double CalculateArea();
	}
}