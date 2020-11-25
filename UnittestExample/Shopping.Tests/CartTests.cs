using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnittestExample;

namespace Shopping.Tests
{
    [TestClass]
    public class CartTests
    {
        private CartItem _cartItem;
        private CartManager _cartManager;


        [TestInitialize]
        public void TestInitialize()
        {
            _cartManager = new CartManager();
             _cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void Sepete_Urun_Eklenebilir()
        {
            //Arange
            const int beklenen = 1;           
            //act
            
            var toplamelamansayisi = _cartManager.TotalItems;
            //Assert
            Assert.AreEqual(beklenen, toplamelamansayisi);

        }

        [TestMethod]
        public void Sepette_olan_urun_cikarilabilmelidir()
        {         
            var sepetteolanelamansayisi = _cartManager.TotalItems;
            //act
            _cartManager.Remove(1);
            var sepettekalanelamansayisi = _cartManager.TotalItems;
            //Assert
            Assert.AreEqual(sepetteolanelamansayisi - 1, sepettekalanelamansayisi);

        }


        [TestMethod]
        public void Sepet_temizlenebilir()
        {
            //Arange       
            //act
           _cartManager.Clear();
            //Assert
            Assert.AreEqual(0,_cartManager.TotalQuantity);
            Assert.AreEqual(0, _cartManager.TotalItems);

        }
    }
}
