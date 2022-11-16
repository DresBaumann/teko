using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Teko.Math.Core.Vector
{
	public class VectorException : ApplicationException
	{
		public VectorException(string message)
			: base(message)
		{
		}

		public static void ThrowIfDimensionMismatch([NotNull] int dimension,
			[NotNull] int otherDimension)
		{
			if (dimension != otherDimension)
			{
				Throw(string.Format(CultureInfo.CurrentCulture,
					VectorResources.DimensionMismatchError, dimension, otherDimension));
			}
		}

		public static void ThrowIfIndexOutOfRange([NotNull] int index,
			[NotNull] int maxIndex)
		{
			if (index >= maxIndex || index < 0)
			{
				Throw(VectorResources.IndexOutOfRangeError);
			}
		}


		public static void ThrowIfDimensionOutOfRange([NotNull] int dimension)
		{
			if (dimension < 1)
			{
				Throw(VectorResources.DimensionOutOfRangeError);
			}
		}

		public static void ThrowIfOperationNotSupportedWithCurrentDimension(int requiredDimension,
			[NotNull] params int[] dimensions)
		{
			if (dimensions.Any(dimension => dimension != requiredDimension))
			{
				Throw(string.Format(CultureInfo.CurrentCulture,
					VectorResources.OperationNotSupportedWithCurrentDimensionError, requiredDimension));
			}
		}

		[DoesNotReturn]
		private static void Throw(string message) =>
			throw new VectorException(message);
	}
}