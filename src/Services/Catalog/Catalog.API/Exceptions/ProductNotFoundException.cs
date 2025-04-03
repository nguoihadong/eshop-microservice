using BuildingBlocks.Exceptions;
using System;

namespace Catalog.API.Exceptions
{
	public class ProductNotFoundException : NotFoundException
	{
		public ProductNotFoundException(Guid Id) : base("Product", Id)
		{

		}
	}
}
