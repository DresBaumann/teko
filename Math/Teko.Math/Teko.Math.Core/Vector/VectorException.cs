namespace Teko.Math.Core.Vector
{
	public class VectorException : ApplicationException
	{
		public VectorException()
		{
		}

		public VectorException(string message)
			: base(message)
		{
		}

		public VectorException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}