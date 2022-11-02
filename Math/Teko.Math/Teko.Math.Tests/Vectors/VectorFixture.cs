using System.Globalization;
using Teko.Math.Core.Vector;
using Xunit;

namespace Teko.Math.Tests.Vectors
{
	public class VectorFixture
	{
		[Fact]
		public void InitializeVector_ValidDimension_CorrectDimensionSet()
		{
			const int dimension = 3;

			Vector vector = new Vector(dimension);

			Assert.Equal(dimension, vector.Dimension);
		}

		[Fact]
		public void InitializeVector_NegativeDimension_ThrowsException()
		{
			const int dimension = -1;

			var exception = Record.Exception(() => new Vector(dimension));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.DimensionOutOfRangeError, exception.Message);
		}

		[Fact]
		public void Set_NegativeIndex_ThrowsException()
		{
			const int dimension = 3;
			Vector vector = new Vector(dimension);

			var exception = Record.Exception(() => vector.Set(-1, 4));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.IndexOutOfRangeError, exception.Message);
		}

		[Fact]
		public void Set_IndexOutOfRange_ThrowsException()
		{
			const int dimension = 1;
			Vector vector = new Vector(dimension);

			var exception = Record.Exception(() => vector.Set(2, 4));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.IndexOutOfRangeError, exception.Message);
		}

		[Fact]
		public void Set_ValidIndex_ValueSetCorrect()
		{
			const int dimension = 1;
			const int value = -6;
			Vector vector = new Vector(dimension);

			vector.Set(0, value);

			Assert.Equal(vector.Get(0), value);
		}

		[Fact]
		public void SetAll_ToManyValues_ThrowsException()
		{
			const int dimension = 4;
			double[] values = { 4.0, -7, 2, 6, 7 };

			Vector vector = new Vector(dimension);
			var exception = Record.Exception(() => vector.SetAll(values));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(
				string.Format(CultureInfo.CurrentCulture, VectorResources.InvalidAmountOfValues, vector.Dimension,
					values.Length), exception.Message);
		}

		[Fact]
		public void SetAll_NotEnoughValues_ThrowsException()
		{
			const int dimension = 3;
			double[] values = { -200, 25.6 };

			Vector vector = new Vector(dimension);
			var exception = Record.Exception(() => vector.SetAll(values));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(
				string.Format(CultureInfo.CurrentCulture, VectorResources.InvalidAmountOfValues, vector.Dimension,
					values.Length), exception.Message);
		}

		[Fact]
		public void SetAll_CorrectAmountOfValues_ValuesSet()
		{
			const int dimension = 3;
			double[] values = { 40, 255.6, -123 };

			Vector vector = new Vector(dimension);

			vector.SetAll(values);
			Assert.Equal(values, vector.GetAll());
		}

		[Fact]
		public void Get_NegativeIndex_ThrowsException()
		{
			const int dimension = 3;
			Vector vector = new Vector(dimension);

			var exception = Record.Exception(() => vector.Get(-1));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.IndexOutOfRangeError, exception.Message);
		}

		[Fact]
		public void Get_IndexOutOfRange_ThrowsException()
		{
			const int dimension = 3;
			Vector vector = new Vector(dimension);

			var exception = Record.Exception(() => vector.Get(3));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.IndexOutOfRangeError, exception.Message);
		}

		[Fact]
		public void Get_ValidIndex_GetCorrectValue()
		{
			const int dimension = 3;
			const double value = -2000;
			const int index = 2;
			Vector vector = new Vector(dimension);

			vector.Set(index, value);

			Assert.Equal(value, vector.Get(index));
		}

		[Fact]
		public void GetAll_GetCorrectValues()
		{
			const int dimension = 3;
			double[] values = { 0, -2255, 989 };
			Vector vector = new Vector(dimension);

			vector.SetAll(values);

			Assert.Equal(values, vector.GetAll());
		}

		[Fact]
		public void Add_DimensionMismatch_ThrowsException()
		{
			Vector vector1 = new Vector(3);
			Vector vector2 = new Vector(4);


			var exception = Record.Exception(() => vector1.Add(vector2));

			Assert.IsType<VectorException>(exception);
			Assert.Equal(VectorResources.DimensionMismatchError, exception.Message);
		}

		[Fact]
		public void Add_ValidVectors_ReturnsCorrectAddition()
		{
			double[] valuesVector1 = { 1, 3, 10 };
			double[] valuesVector2 = { 5, 3, 1 };
			Vector vector1 = new Vector(3);
			vector1.SetAll(valuesVector1);
			Vector vector2 = new Vector(3);
			vector2.SetAll(valuesVector2);

			var result = vector1.Add(vector2);

			double[] expected = { 6, 6, 11 };
			Assert.Equal(expected, result.GetAll());
		}

		[Fact]
		public void Mul_PositiveMultiplier_ReturnsCorrectMultiplication()
		{
			double[] values = { 6, 6, 11 };
			const int multiplier = -1;
			Vector vector = new Vector(3);
			vector.SetAll(values);

			Vector result = vector.Mul(multiplier);

			double[] expected = { -6, -6, -11 };
			Assert.Equal(expected, result.GetAll());
		}

		[Fact]
		public void ToString_ReturnsCorrectToString()
		{
			double[] values = { 6, 6, 11 };
			Vector vector = new Vector(3);
			vector.SetAll(values);

			string result = vector.ToString();

			string expected = "[ 6, 6, 11 ]";
			Assert.Equal(expected, result);
		}
	}
}