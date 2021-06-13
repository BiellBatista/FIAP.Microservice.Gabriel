using FIAP.Microservice.Gabriel.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FIAP.Microservice.Gabriel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static string paulistaStore = "Paulista";
        private static string morumbiStore = "Morumbi";

        private static Item beef = new Item { ItemId = Guid.NewGuid(), Name = "beef" };
        private static Item pork = new Item { ItemId = Guid.NewGuid(), Name = "pork" };
        private static Item mustard = new Item { ItemId = Guid.NewGuid(), Name = "mustard" };
        private static Item ketchup = new Item { ItemId = Guid.NewGuid(), Name = "ketchup" };
        private static Item bread = new Item { ItemId = Guid.NewGuid(), Name = "bread" };
        private static Item wBread = new Item { ItemId = Guid.NewGuid(), Name = "whole bread" };

        private List<Product> products = new List<Product>()
        {
            new Product {
                ProductId = Guid.NewGuid(), Name = "Darth Bacon",
                Image = "hamb1.png",
                StoreName = paulistaStore,
                Items = new List<Item> {beef, ketchup, bread}
            },
            new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Cap. Spork",
                Image = "hamb2.png",
                StoreName = paulistaStore,
                Items = new List<Item> { pork, mustard, wBread }
            },
            new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Beef Turner",
                Image = "hamb3.png",
                StoreName = morumbiStore,
                Items = new List<Item> { beef, mustard, bread }
            }
        };

        [HttpGet("{storeName}")]
        public IActionResult GetProductsByStoreName(string storeName)
        {
            var productsByStore = products.Where(product => product.StoreName == storeName).ToList();

            if (productsByStore.Count <= 0)
                return NotFound();

            return Ok(productsByStore);
        }
    }
}