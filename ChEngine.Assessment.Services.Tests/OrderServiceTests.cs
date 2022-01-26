using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChEngine.Assessment.Services.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        private IOrdersApi _ordersApi;

        [TestInitialize()]
        public void Initialize()
        {
            _ordersApi = new OrdersApiStub();
            _orderService = new OrderService(_ordersApi);
        }

        [TestMethod]
        public async Task AmountOfItems_InputIs5_ReturnMore()
        {
            var numberOfItems = 5;
            var topSoldProducts = await _orderService.GetTopSoldProducts(numberOfItems);

            Assert.IsFalse(topSoldProducts.Count() > numberOfItems, "Quantity of returned items must be equal to or less than the requested quantity");
        }

        [TestMethod]
        public async Task Order_InputIs5_ReturnInIncorrectOrder()
        {
            var numberOfItems = 5;
            var topSoldProducts = (await _orderService.GetTopSoldProducts(numberOfItems)).ToList();

            var isInCorrectOrder = false;

            for (int i = 0; i < numberOfItems - 1; i++)
            {
                if (topSoldProducts[i].Quantity < topSoldProducts[i + 1].Quantity)
                {
                    isInCorrectOrder = true;
                    break;
                }
            }

            Assert.IsFalse(isInCorrectOrder, "The products should be ordered in descending order");
        }

        [TestMethod]
        public async Task DataCorrectness_InputIs5_ReturnIncorrectData()
        {
            var numberOfItems = 5;
            var topSoldProducts = await _orderService.GetTopSoldProducts(numberOfItems);

            Assert.AreEqual("prdct-006", topSoldProducts.FirstOrDefault()?.MerchantProductNo, "Incorrect data returned");
        }

        class OrdersApiStub : IOrdersApi
        {
            public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
            {
                var dummyData = new List<Order> 
                {
                    new Order { Id = 1, Lines = new List<OrderItem> 
                    { 
                        new OrderItem{ Description = "Product 1", Gtin = "8719351020001", MerchantProductNo = "prdct-001", Quantity = 2},
                        new OrderItem{ Description = "Product 2", Gtin = "8719351020002", MerchantProductNo = "prdct-002", Quantity = 1},
                        new OrderItem{ Description = "Product 3", Gtin = "8719351020003", MerchantProductNo = "prdct-003", Quantity = 1},
                    } },
                    new Order { Id = 2, Lines = new List<OrderItem>
                    {
                        new OrderItem{ Description = "Product 1", Gtin = "8719351020001", MerchantProductNo = "prdct-001", Quantity = 1},
                        new OrderItem{ Description = "Product 2", Gtin = "8719351020002", MerchantProductNo = "prdct-002", Quantity = 1},
                        new OrderItem{ Description = "Product 3", Gtin = "8719351020003", MerchantProductNo = "prdct-003", Quantity = 1},
                        new OrderItem{ Description = "Product 4", Gtin = "8719351020004", MerchantProductNo = "prdct-004", Quantity = 1}
                    } },
                    new Order { Id = 3, Lines = new List<OrderItem>
                    {
                        new OrderItem{ Description = "Product 5", Gtin = "8719351020005", MerchantProductNo = "prdct-005", Quantity = 4}
                    } },
                    new Order { Id = 4, Lines = new List<OrderItem>
                    {
                        new OrderItem{ Description = "Product 1", Gtin = "8719351020001", MerchantProductNo = "prdct-001", Quantity = 1},
                        new OrderItem{ Description = "Product 3", Gtin = "8719351020003", MerchantProductNo = "prdct-003", Quantity = 3},
                    } },
                    new Order { Id = 5, Lines = new List<OrderItem>
                    {
                        new OrderItem{ Description = "Product 1", Gtin = "8719351020001", MerchantProductNo = "prdct-001", Quantity = 5},
                        new OrderItem{ Description = "Product 6", Gtin = "8719351020001", MerchantProductNo = "prdct-006", Quantity = 10}
                    } }
                };

                return dummyData;
            }
        }
    }
}