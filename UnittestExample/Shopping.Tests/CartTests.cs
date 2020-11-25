using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnittestExample;

namespace Shopping.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Sepete_Urun_Eklenebilir()
        {
            //Arange
            const int beklenen = 1;
            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };

            //act
            cartManager.Add(cartItem);
            var toplamelamansayisi = cartManager.TotalItems;
            //Assert
            Assert.AreEqual(beklenen, toplamelamansayisi);

        }

        [TestMethod]
        public void Sepette_olan_urun_cikarilabilmelidir()
        {
            //Arange
            var cartManager = new CartManager();
            var cartItem = new CartItem { 
            Product = new Product { ProductId=1,ProductName="LAptop",UnitPrice=2500},Quantity=1
            };
            cartManager.Add(cartItem);
            var sepetteolanelamansayisi = cartManager.TotalItems;
            //act
            cartManager.Remove(1);
            var sepettekalanelamansayisi = cartManager.TotalItems;
            //Assert
            Assert.AreEqual(sepetteolanelamansayisi - 1, sepettekalanelamansayisi);

        }


        [TestMethod]
        public void Sepet_temizlenebilir()
        {
            //Arange
            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product { ProductId = 1, ProductName = "LAptop", UnitPrice = 2500 },
                Quantity = 1
            };
            cartManager.Add(cartItem);
            //act
            cartManager.Clear();
            //Assert
            Assert.AreEqual(0,cartManager.TotalQuantity);
            Assert.AreEqual(0, cartManager.TotalItems);

        }
    }
}
