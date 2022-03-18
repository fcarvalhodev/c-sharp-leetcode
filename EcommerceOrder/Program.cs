using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //15,24 x 15,24 x 10,16cm
            //6"x6"x4"x
        }
    }

    /// <summary>
    /// This application is using the basic concepts of OO/SOLID and a little bit of DDD and TDD
    /// The application was developing guided by tests, and the first layer that was builded was the Domain Layer
    /// The Domain Layer is using the Builder Pattern, where we have an extra security in the classes as also we are using the principles of Open/Close and Single Respoability concept
    /// After the domain layer, the data layer was builded, and the repositories followed by the services. Here we have DIP and ISP principle using interfaces for abstraction in the services.
    /// </summary>

    #region .: Services :.

    public interface IOrderService
    {
        IEnumerable<Order> GetPriorityOrders();
        IEnumerable<Order> GetOrders();
        int GetMinAmountOfBoxes(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int GetMinAmountOfBoxes(Order order)
        {
            return _orderRepository.GetMinAmountOfBoxes(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public IEnumerable<Order> GetPriorityOrders()
        {
            return _orderRepository.GetPriorityOrders();
        }
    }

    #endregion

    #region .: Repositories :.

    public interface IOrderRepository
    {
        IEnumerable<Order> GetPriorityOrders();
        IEnumerable<Order> GetOrders();
        int GetMinAmountOfBoxes(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository()
        {
            _context = new Context();
        }

        public int GetMinAmountOfBoxes(Order order)
        {
            float[] BoxSize = new float[] { 6, 6, 4 };
            int MinAmountOfBoxes = 0;
            bool Start = true;
            while (Start)
            {
                Start = false;
                for (int i = 0; i < order.Items.Count - 1; i++)
                {
                    float aValue = order.Items[i].Size.Max();
                    float bValue = order.Items[i + 1].Size.Max();
                    if (bValue < aValue)
                    {
                        var temp = order.Items[i + 1];
                        order.Items[i + 1] = order.Items[i];
                        order.Items[i] = temp;
                        Start = true;
                    }
                }
            }

            Start = true;
            while (Start)
            {
                float CurrentBoxSize = 0;
                Start = false;
                for (int i = 0; i < order.Items.Count; i++)
                {
                    float aValue = order.Items[i].Size.Max();
                    CurrentBoxSize += aValue;
                    if (CurrentBoxSize > BoxSize.Max())
                    {
                        MinAmountOfBoxes += 1;
                        CurrentBoxSize = 0;
                        i--;
                    }
                }
            }

            if (MinAmountOfBoxes == 0)
                MinAmountOfBoxes++;

            return MinAmountOfBoxes;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetPriorityOrders()
        {
            return _context.Orders.OrderBy(o => o.DateCreated).ToList();
        }
    }

    #endregion

    #region .: Data :.

    public class Context
    {
        public List<Order> Orders { get; set; }

        public Context()
        {
            Initialize();
        }

        private void Initialize()
        {
            DateTime date1 = DateTime.Parse("17/03/2021");
            DateTime date2 = DateTime.Parse("17/04/2021");
            DateTime date3 = DateTime.Parse("17/05/2021");

            Item dependentItem1 = new Item.ItemBuilder().Item(DependentItemStatus.NotDependent, true).Build();
            Item dependentItem2 = new Item.ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem3 = new Item.ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem4 = new Item.ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();


            Item item1 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 3.3F, 0.8F, 2.25F })
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem2)
                .Build();

            Item item2 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, false)
                .SetItemSize(new float[] { 0.4F, 1.2F, 0.7F })
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem3)
                .AddDependentItem(dependentItem4)
                .Build();

            Item item3 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 1.7F, 0.4F, 1.54F })
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem4)
                .Build();

            Item item4 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 0.4F, 0.6F, 2.66F })
                .AddDependentItem(dependentItem1)
                .Build();

            Item item5 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, false)
                .SetItemSize(new float[] { 4.7F, 1.4F, 0.31F })
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem2)
                .AddDependentItem(dependentItem3)
                .AddDependentItem(dependentItem4)
                .Build();

            Item item6 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 2.2F, 0.3F, 3.17F })
                .Build();

            Item item7 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 0.9F, 1.1F, 1.86F })
                .Build();

            Item item8 = new Item.ItemBuilder()
                .Item(DependentItemStatus.NotDependent, true)
                .SetItemSize(new float[] { 1.1F, 1.6F, 0.43F })
                .Build();

            Order order1 = new Order.OrderBuilder()
                .Order(date3, Location.UsLocation)
                .AddItem(item1)
                .AddItem(item2)
                .AddItem(item3)
                .Build();

            Order order2 = new Order.OrderBuilder()
                .Order(date2, Location.NonUsLocation)
                .AddItem(item4)
                .AddItem(item5)
                .Build();

            Order order3 = new Order.OrderBuilder()
                .Order(date1, Location.UsLocation)
                .AddItem(item6)
                .AddItem(item7)
                .AddItem(item8)
                .Build();

            Orders.Add(order1);
            Orders.Add(order2);
            Orders.Add(order3);
        }
    }

    #endregion

    #region .: Domain :.

    public class Order
    {
        public bool CanBeProcessed { get; private set; }
        public DateTime DateCreated { get; private set; }
        private Location Location { get; set; }
        public List<Item> Items { get; private set; }

        public Order()
        {

        }

        public class OrderBuilder
        {
            private readonly Order _order = new Order();

            public OrderBuilder Order(DateTime? dateCreated, Location location = Location.NonUsLocation)
            {
                _order.DateCreated = dateCreated ?? DateTime.Now;
                _order.Location = location;
                _order.Items = new List<Item>();
                _order.CanBeProcessed = location == Location.UsLocation ? true : false;
                return this;
            }

            public OrderBuilder AddItem(Item item)
            {
                _order.Items.Add(item);
                return this;
            }

            public OrderBuilder AddRange(List<Item> items)
            {
                _order.Items.AddRange(items);
                return this;
            }

            public Order Build()
            {
                return _order;
            }
        }
    }

    public class Item
    {
        public bool CanBeShipped { get; private set; }
        private Lazy<List<Item>> DependentItems { get; set; }
        private DependentItemStatus DependentItemStatus { get; set; }
        public float[] Size { get; private set; }

        public Item()
        {
        }

        public class ItemBuilder
        {
            private readonly Item _item = new Item();

            public ItemBuilder Item(DependentItemStatus dependentItemStatus = DependentItemStatus.NotDependent, bool canBeShipped = false)
            {
                this._item.DependentItemStatus = dependentItemStatus;
                this._item.CanBeShipped = canBeShipped;
                this._item.DependentItems = new Lazy<List<Item>>();
                this._item.Size = new float[3];
                return this;
            }

            public ItemBuilder SetItemSize(float[] itemSize)
            {
                if (itemSize.Length != 3)
                    throw new ArgumentException("The 'itemSize' length is invalid", "itemSize");

                this._item.Size = itemSize;

                return this;
            }

            public ItemBuilder AddDependentItem(Item item)
            {
                this._item.DependentItems.Value.Add(item);
                return this;
            }

            public ItemBuilder AddRangeDependentItem(List<Item> items)
            {
                this._item.DependentItems.Value.AddRange(items);
                return this;
            }

            private void DependentItemsCanBeShipped()
            {
                if (this._item.DependentItems.Value.Count > 0)
                {
                    var allItemsAreAllowdToDispatch = this._item.DependentItems.Value.Any(x => x.CanBeShipped == false);
                    if (!allItemsAreAllowdToDispatch)
                    {
                        _item.CanBeShipped = true;
                    }
                    else
                    {
                        if (this._item.DependentItemStatus == DependentItemStatus.NotDependent)
                            _item.CanBeShipped = true;
                        else
                            _item.CanBeShipped = false;
                    }
                }
            }

            public Item Build()
            {
                this.DependentItemsCanBeShipped();
                return _item;
            }
        }
    }

    public enum Location
    {
        UsLocation,
        NonUsLocation
    }

    public enum DependentItemStatus
    {
        Dependent,
        NotDependent
    }

    #endregion
}
