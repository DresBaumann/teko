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
			VectorException.ThrowIfDimensionOutOfRange(dimension);

			_dimension = dimension;
			_components = new List<double>(new double[dimension]);
		}

		public void Set(int componentIndex, double value)
		{
			VectorException.ThrowIfIndexOutOfRange(componentIndex, _components.Count);

			_components[componentIndex] = value;
		}

		public void SetAll(params double[] values)
		{
			if (values.Length != _dimension)
			{
				throw new VectorException(string.Format(CultureInfo.CurrentCulture,
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
				Set(index, random.NextDouble());
			}
		}

		public double Get(int componentIndex)
		{
			VectorException.ThrowIfIndexOutOfRange(componentIndex, _dimension);

			return _components[componentIndex];
		}

		public double[] GetAll()
		{
			return _components.ToArray();
		}

		public Vector Add(Vector vector)
		{
			VectorException.ThrowIfDimensionMismatch(_dimension, vector.Dimension);

			Vector result = new(_dimension);

			for (int index = 0; index < _dimension; index++)
			{
				double component = Get(index) + vector.Get(index);
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
				double component = multiplier * Get(index);
				result.Set(index, component);
			}

			return result;
		}

		public void Mul(double multiplier, ref Vector result)
		{
			result = Mul(multiplier);
		}


		public override string ToString()
		{
			return $"[ {string.Join(", ", _components)} ]";
		}

		public double Abs()
		{
			IEnumerable<double> cubedComponents = _components.Select(component => component * component);
			return System.Math.Sqrt(cubedComponents.Sum());
		}

		public double Dot(Vector vector)
		{
			VectorException.ThrowIfDimensionMismatch(_dimension, vector.Dimension);

			double scalarProduct = 0;
			for (int index = 0; index < _dimension; index++)
			{
				scalarProduct += Get(index) * vector.Get(index);
			}

			return scalarProduct;
		}

		public Vector Cross(Vector vector)
		{
			VectorException.ThrowIfOperationNotSupportedWithCurrentDimension(
				VectorConstants.RequiredDimensionForCrossProductOperation, new[] { _dimension, vector.Dimension });

			double component1 = (Get(1) * vector.Get(2)) - (Get(2) * vector.Get(1));
			double component2 = (Get(2) * vector.Get(0)) - (Get(0) * vector.Get(2));
			double component3 = (Get(0) * vector.Get(1)) - (Get(1) * vector.Get(0));


			Vector crossProduct = new Vector(3);
			crossProduct.SetAll(component1, component2, component3);

			return crossProduct;
		}

		public void Cross(Vector vector, ref Vector result)
		{
			VectorException.ThrowIfOperationNotSupportedWithCurrentDimension(
				VectorConstants.RequiredDimensionForCrossProductOperation, result.Dimension);

			result = Cross(vector);
		}
	}
}