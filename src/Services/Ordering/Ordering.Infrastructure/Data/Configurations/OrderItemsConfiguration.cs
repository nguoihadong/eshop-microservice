using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObJects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data.Configurations
{
	public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.HasKey(i => i.Id);

			builder.Property(i => i.Id)
				.HasConversion(
					orderItemId => orderItemId.Value,
					dbId => OrderItemId.Of(dbId));

			builder.HasOne<Product>().WithMany()
				.HasForeignKey(i => i.ProductId);

			builder.Property(i => i.Quantity).IsRequired();

			builder.Property(i => i.Price).IsRequired();
		}
	}
}
