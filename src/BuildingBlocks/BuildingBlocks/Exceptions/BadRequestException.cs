using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
		public BadRequestException(string message) : base(message)
		{
		}
		public BadRequestException(string message, string detail) : base(message)
		{
			Detail = detail;
		}
		public string? Detail { get; set; }
	}
}
