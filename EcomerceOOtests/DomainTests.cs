using EcommerceOrder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static EcommerceOrder.Item;
using static EcommerceOrder.Order;

namespace EcomerceOOtests
{
    [TestClass]
    public class DomainTests
    {
        [TestMethod]
        public void Given_A_ValidItem_ShouldNotBeShipped()
        {
            //Act
            Item item = new ItemBuilder().Item().Build();

            //Assert
            Assert.IsFalse(item.CanBeShipped);
        }

        [TestMethod]
        public void Given_A_ValidOrder_ShouldBeProcessed()
        {
            //Arrange
            DateTime date = DateTime.Parse("17/03/2021");

            //Act
            Order order = new OrderBuilder()
                .Order(date, Location.UsLocation)
                .Build();

            //Assert
            Assert.IsTrue(order.CanBeProcessed);
        }

        [TestMethod]
        public void Given_A_ListOfOrder_OrdersMustBePriorityzedByDate()
        {
            //Arrange
            DateTime date1 = DateTime.Parse("17/03/2021");
            DateTime date2 = DateTime.Parse("17/04/2021");
            DateTime date3 = DateTime.Parse("17/05/2021");

            Order order1 = new OrderBuilder()
                .Order(date3, Location.UsLocation)
                .Build();

            Order order2 = new OrderBuilder()
                .Order(date2, Location.UsLocation)
                .Build();

            Order order3 = new OrderBuilder()
                .Order(date1, Location.UsLocation)
                .Build();

            List<Order> orders = new List<Order>();
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            //Act
            orders = orders.OrderBy(o => o.DateCreated).ToList();

            //Assert
            Assert.AreEqual(orders[0].DateCreated, order3.DateCreated);
            Assert.AreEqual(orders[1].DateCreated, order2.DateCreated);
            Assert.AreEqual(orders[2].DateCreated, order1.DateCreated);
        }

        [TestMethod]
        public void Given_A_ListOfOrders_USLocationMustProcessAutomatically()
        {
            //Arrange
            DateTime date1 = DateTime.Parse("17/03/2021");
            DateTime date2 = DateTime.Parse("17/04/2021");
            DateTime date3 = DateTime.Parse("17/05/2021");

            Item item1 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).Build();
            Item item2 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item item3 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).Build();

            Order order1 = new OrderBuilder()
                .Order(date3, Location.UsLocation)
                .AddItem(item1)
                .AddItem(item2)
                .AddItem(item3)
                .Build();

            Order order2 = new OrderBuilder()
                .Order(date2, Location.UsLocation)
                .AddItem(item2)
                .Build();

            Order order3 = new OrderBuilder()
                .Order(date1, Location.NonUsLocation)
                .AddItem(item1)
                .AddItem(item3)
                .Build();

            List<Order> orders = new List<Order>();

            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            //Act
            orders = orders.OrderBy(o => o.DateCreated).ToList();

            //Assert
            Assert.IsFalse(orders[0].CanBeProcessed);
            Assert.IsTrue(orders[1].CanBeProcessed);
            Assert.IsTrue(orders[2].CanBeProcessed);
        }

        [TestMethod]
        public void Given_An_Item_With_DependentItem_ShouldNotBeShipped()
        {
            //Arrange
            Item dependentItem1 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).Build();
            Item dependentItem2 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem3 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem4 = new ItemBuilder().Item(DependentItemStatus.Dependent, false).Build();

            //Act
            Item item = new ItemBuilder()
                .Item(DependentItemStatus.Dependent, true)
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem2)
                .AddDependentItem(dependentItem3)
                .AddDependentItem(dependentItem4)
                .Build();

            //Assert
            Assert.IsFalse(item.CanBeShipped);
        }

        [TestMethod]
        public void Given_An_Item_With_DependentItem_ShouldBeShipped()
        {
            //Arrange
            Item dependentItem = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).Build();
            Item dependentItem1 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem2 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();
            Item dependentItem4 = new ItemBuilder().Item(DependentItemStatus.Dependent, true).Build();

            //Act
            Item item = new ItemBuilder()
                .Item()
                .AddDependentItem(dependentItem)
                .AddDependentItem(dependentItem1)
                .AddDependentItem(dependentItem2)
                .AddDependentItem(dependentItem4)
                .Build();

            //Assert
            Assert.IsTrue(item.CanBeShipped);
        }

        [TestMethod]
        public void Given_An_ListOfItems_SizeMustReturnAMinQtdOfBox()
        {
            //Arrange
            Item item1 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 3.3F, 0.8F, 2.25F }).Build();
            Item item2 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 0.4F, 1.2F, 0.7F }).Build();
            Item item3 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 1.7F, 0.4F, 1.54F }).Build();
            Item item4 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 0.4F, 0.6F, 2.66F }).Build();
            Item item5 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 4.7F, 1.4F, 0.31F }).Build();
            Item item6 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 2.2F, 0.3F, 3.17F }).Build();
            Item item7 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 0.9F, 1.1F, 1.86F }).Build();
            Item item8 = new ItemBuilder().Item(DependentItemStatus.NotDependent, true).SetItemSize(new float[] { 1.1F, 1.6F, 0.43F }).Build();
            float[] BoxSize = new float[] { 6, 6, 4 };
            int MinAmountOfBoxes = 0;
            List<Item> ListItems = new List<Item>();
            bool Start = true;

            //Act
            ListItems.Add(item1);
            ListItems.Add(item2);
            ListItems.Add(item3);
            ListItems.Add(item4);
            ListItems.Add(item5);
            ListItems.Add(item6);
            ListItems.Add(item7);
            ListItems.Add(item8);

            while (Start)
            {
                Start = false;
                for (int i = 0; i < ListItems.Count - 1; i++)
                {
                    float aValue = ListItems[i].Size.Max();
                    float bValue = ListItems[i + 1].Size.Max();
                    if (bValue < aValue)
                    {
                        var temp = ListItems[i + 1];
                        ListItems[i + 1] = ListItems[i];
                        ListItems[i] = temp;
                        Start = true;
                    }
                }
            }

            Start = true;
            while (Start)
            {
                float CurrentBoxSize = 0;
                Start = false;
                for (int i = 0; i < ListItems.Count; i++)
                {
                    float aValue = ListItems[i].Size.Max();
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


            Assert.AreEqual(MinAmountOfBoxes, 4);
        }
    }
}
