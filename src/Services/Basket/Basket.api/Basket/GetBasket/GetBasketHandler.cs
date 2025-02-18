using Basket.api.Data;
using Basket.api.Models;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;

namespace Basket.api.Basket.GetBasket
{
    public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository repository)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, 
            CancellationToken cancellationToken)
        {

            var basket = await repository.GetBasket(query.Username, cancellationToken);

            return new GetBasketResult(basket);
        }
    }
}
