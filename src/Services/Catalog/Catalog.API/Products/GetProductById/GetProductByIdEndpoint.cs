
namespace Catalog.API.Products.GetProductById
{

	//public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
	
	public record GetProductByIdRespone(Product Product);

	public class GetProductByIdEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
			{
				var result = await sender.Send(new GetProductByIdQuery(id));
				var response = result.Adapt<GetProductByIdRespone>();
				return Results.Ok(response);
			})
			.WithName("GetProductById")
			.Produces<GetProductByIdRespone>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("Get Product By Id")
			.WithDescription("Get Product By Id");
		}
	}
}
