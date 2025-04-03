using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerException : Exception
    {
		public InternalServerException(string message) : base(message)
		{

		}

		public InternalServerException(string message, string detail) : base(message)
		{
			Detail = detail;
		}

		public string? Detail { get; set; }
	}
}
