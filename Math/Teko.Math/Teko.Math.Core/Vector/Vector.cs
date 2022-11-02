using System.Globalization;

namespace Teko.Math.Core.Vector
{
	public class Vector
	{
		private readonly List<double> _components;

		private readonly int _dimension;

		public int Dimension => _dimension;

		public Vector(int dimension)
		{
			if (dimension < 1)
			{
				throw new VectorException(VectorResources.DimensionOutOfRangeError);
			}

			_dimension = dimension;
			_components = new List<double>(new double[dimension]);
		}

		public void Set(int componentIndex, double value)
		{
			if (componentIndex > _dimension || componentIndex < 0)
			{
				throw new VectorException(VectorResources.IndexOutOfRangeError);
			}

			_components[componentIndex] = value;
		}

		public void SetAll(params double[] values)
		{
			if (values.Length != _dimension)
			{
				throw new VectorException(String.Format(CultureInfo.CurrentCulture,
					VectorResources.InvalidAmountOfValues, _dimension, values.Length));
			}

			int index = 0;
			foreach (var value in values)
			{
				_components[index] = value;
				index++;
			}
		}

		public void SetRand(Random random)
		{
			for (int index = 0; index < _dimension; index++)
			{
				_components[index] = random.NextDouble();
			}
		}

		public double Get(int componentIndex)
		{
			if (componentIndex > _dimension || componentIndex < 0)
			{
				throw new VectorException(VectorResources.DimensionOutOfRangeError);
			}

			return _components[componentIndex];
		}

		public double[] GetAll()
		{
			return _components.ToArray();
		}

		public Vector Add(Vector vector)
		{
			if (_dimension != vector._dimension)
			{
				throw new VectorException(string.Format(CultureInfo.CurrentCulture,
					VectorResources.DimensionMissmatchError, _dimension, vector.Dimension));
			}

			Vector result = new Vector(_dimension);

			for (int index = 0; index < _dimension; index++)
			{
				double component = this.Get(index) + vector.Get(index);
				result.Set(index, component);
			}

			return result;
		}

		public void Add(Vector vector, out Vector result)
		{
			result = Add(vector);
		}

		public Vector Mul(double multiplier)
		{
			Vector result = new Vector(_dimension);

			for (int index = 0; index < _dimension; index++)
			{
				double component = multiplier * this.Get(index);
				result.Set(index, component);
			}

			return result;
		}

		public void Mul(double multiplier, out Vector result)
		{
			result = Mul(multiplier);
		}

		public override string ToString()
		{
			return $"[{string.Join(", ", _components)}]";
		}
	}
}