namespace MySite.Presentation.Services
{
    public class OrderService : IOrderService
    {
        private OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        // Implementeer andere interface methoden...
    }
}
