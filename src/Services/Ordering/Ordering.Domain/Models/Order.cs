namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public decimal TotalPrice
        {
            get { return _orderItems.Sum(item => item.Price); }
            private set { }
        }


        public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, 
            Address billingAddress, Payment payment)
        {
            //ArgumentException.ThrowIfNull(customerId);
            //ArgumentException.ThrowIfNull(orderName);
            //ArgumentException.ThrowIfNull(shippingAddress);
            //ArgumentException.ThrowIfNull(billingAddress);
            //ArgumentException.ThrowIfNull(payment);
            var order = new Order
            {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                Payment = payment,
                Status = OrderStatus.Pending
            };

            order.AddDomainEvent(new OrderCreatedEvent(order));

            return order;
        }

        public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
        {
           
            OrderName = orderName;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            Payment = payment;
            Status = status;
            AddDomainEvent(new OrderUpdatedEvent(this));
        }

        public void Add(ProductId productId, decimal price, int quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var orderItem = new OrderItem(Id, productId, price, quantity);
            _orderItems.Add(orderItem);

            //var existingOrderForProduct = _orderItems.FirstOrDefault(o => o.ProductId == productId);
            //if (existingOrderForProduct != null)
            //{
            //    existingOrderForProduct.AddUnits(quantity);
            //}
            //else
            //{
            //    var orderItem = new OrderItem(Id, productId, price, quantity);
            //    _orderItems.Add(orderItem);
            //}
        }

        public void Remove(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(o => o.ProductId == productId);
            if (orderItem != null)
            {
                _orderItems.Remove(orderItem);
            }
            
        }

    }
}
