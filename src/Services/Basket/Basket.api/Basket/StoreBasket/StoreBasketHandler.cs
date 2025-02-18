
using Basket.api.Data;

namespace Basket.api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart)
        : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be empty");
            RuleFor(x => x.Cart.UserName).NotNull().WithMessage("Username is required");
        }
    }

    public class StoreBasketCommandHandler(IBasketRepository repository)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, 
            CancellationToken cancellationToken)
        {
            await repository.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
