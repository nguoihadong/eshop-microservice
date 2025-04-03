﻿namespace Catalog.API.Products.UpdateProduct
{
	public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, List<string> Category, string ImageFile) : ICommand<UpdateProductResult>;

	public record UpdateProductResult(bool isSuccess);

	public class UpdateProductResultValidator : AbstractValidator<UpdateProductCommand>
	{
		public UpdateProductResultValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
			RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
			RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
		}
	}
	internal class UpdateProductHandler	
		(IDocumentSession session)
		: ICommandHandler<UpdateProductCommand, UpdateProductResult>
	{
		public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
		{
			var product = await session.LoadAsync<Product>(command.Id,cancellationToken);

			if (product is null)
			{
				throw new ProductNotFoundException(command.Id);
			}

			product.Name = command.Name;
			product.Category = command.Category;
			product.Description = command.Description;
			product.Price = command.Price;
			product.ImageFile = command.ImageFile;

			session.Update(product);
			await session.SaveChangesAsync(cancellationToken);

			return new UpdateProductResult(true);
		}
	}
}
