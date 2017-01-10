using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TDDhw_TestGroup
{
    [TestClass]
    public class Test_GroupSum
    {

        private List<Product> oProduct()
        {

            var ProductList = new List<Product>()
            {
                new Product() { Id=1 , Cost=1 , Revenue=11 , SellPrice=21 },
                new Product() { Id=2 , Cost=2 , Revenue=12 , SellPrice=22 },
                new Product() { Id=3 , Cost=3 , Revenue=13 , SellPrice=23 },
                new Product() { Id=4 , Cost=4 , Revenue=14 , SellPrice=24 },
                new Product() { Id=5 , Cost=5 , Revenue=15 , SellPrice=25 },
                new Product() { Id=6 , Cost=6 , Revenue=16 , SellPrice=26 },
                new Product() { Id=7 , Cost=7 , Revenue=17 , SellPrice=27 },
                new Product() { Id=8 , Cost=8 , Revenue=18 , SellPrice=28 },
                new Product() { Id=9 , Cost=9 , Revenue=19 , SellPrice=29 },
                new Product() { Id=10, Cost=10, Revenue=20 , SellPrice=30 },
                new Product() { Id=11, Cost=11, Revenue=21 , SellPrice=31 }
            };
            return ProductList;
        }

        /// <summary>
        /// Cost三筆一組的總和
        /// </summary>
        [TestMethod]
        public void Test_GroupSum3_ByCost()
        {
            //arrage
            var _Product = oProduct();
            List<int> expected = new List<int> { 6, 15, 24, 21 };

            //act
            List<int> actual = GroupSum(3, _Product.Select(o => o.Cost).ToList());

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 測試SellPrice五筆一組的總和
        /// </summary>
        [TestMethod]
        public void Test_GroupSum5_ByRevenue()
        {
            //arrage
            var _Product = oProduct();
            List<int> expected = new List<int> { 115, 140, 31 };

            //act
            List<int> actual = GroupSum(5, _Product.Select(o => o.SellPrice).ToList());

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Revenue四筆一組的總和
        /// </summary>
        [TestMethod]
        public void Test_GroupSum4_ByRevenue()
        {
            //arrage
            var _Product = oProduct();
            List<int> expected = new List<int> { 50, 66, 60 };

            //act
            List<int> actual = GroupSum(4, _Product.Select(o => o.Revenue).ToList());

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        internal class Product
        {
            public int Id { get; set; }
            public int Cost { get; set; }
            public int Revenue { get; set; }
            public int SellPrice { get; set; }
        }

        /// <summary>
        /// 小實作測試
        /// </summary>
        [TestMethod]
        public void Test_GroupDrinks()
        {
            //arrage

            var _drink = new List<Drinks>()
            {
                new Drinks() { Quantity=1 },
                new Drinks() { Quantity=2 },
                new Drinks() { Quantity=3 },
                new Drinks() { Quantity=4 },
                new Drinks() { Quantity=5 },
                new Drinks() { Quantity=6 },
                new Drinks() { Quantity=7 },

            };
            List<int> expected_By3 = new List<int> { 6, 15, 7 };
            List<int> expected_By4 = new List<int> { 10, 18 };


            //act 測試取三筆及四筆
            List<int> actual_By3 = GroupSum(3, _drink.Select(o => o.Quantity).ToList());
            List<int> actual_By4 = GroupSum(4, _drink.Select(o => o.Quantity).ToList());

            //assert
            CollectionAssert.AreEqual(expected_By3, actual_By3);
            CollectionAssert.AreEqual(expected_By4, actual_By4);

        }
        internal class Drinks
        {
            public int Quantity { get; set; }
            
        }

        private List<int> GroupSum(int divided, List<int> product)
        {
            //divided - 所需數量組合  ,  product - 該產品項目產品總和
            //初始
            List<int> list = new List<int>();
            int value = 0;
            //將產品列舉
            while (value < product.Count())
            {
                //依據條件擷取取得總和
                list.Add(product.Skip(value).Take(divided).Sum());
                value += divided;
            }
            return list;
        }
    }

}
