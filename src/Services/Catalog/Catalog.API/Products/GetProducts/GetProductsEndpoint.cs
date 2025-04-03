
namespace Catalog.API.Products.GetProducts
{
	public record GetProductRequest(int? pageNumber = 1, int? PageSize = 10);

	public record GetProductRespone(IEnumerable<Product> Products);

	public class GetProductsEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/products", async([AsParameters] GetProductRequest request,  ISender sender) =>
			{
				var query = request.Adapt<GetProductRequest>();

				var result = await sender.Send(query);

				var response = result.Adapt<GetProductRespone>();

				return Results.Ok(response);
			})
			.WithName("GetProducts")
			.Produces<GetProductRespone>(StatusCodes.Status200OK)
			.ProducesProblem(StatusCodes.Status400BadRequest)
			.WithSummary("Get Products")
			.WithDescription("Get Products");
		}
	}
}
