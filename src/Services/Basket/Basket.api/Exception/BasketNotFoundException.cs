using BuildingBlocks.Exceptions;

namespace Basket.api.Exception
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string userName) : base("Basket",userName)
        {
            
        }
    }
}
