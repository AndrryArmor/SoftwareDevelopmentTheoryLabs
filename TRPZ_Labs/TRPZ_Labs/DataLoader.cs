using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using GoodsOrdering;

namespace TRPZ_Labs
{
    public class DataLoader
    {
        private const string goodsFileName = "Goods.data";
        private const string shopsFileName = "Shops.data";
        private const string jsonFileName = "Orders.json";
        private const string dataPath = "..\\..\\Data\\";

        public List<Good> LoadGoods()
        {
            var goods = new List<Good>();

            // Good describes as string of "ID, Name, Model, Manufacturer, Description"  
            using (var goodsData = new StreamReader(new Uri(dataPath + goodsFileName, UriKind.Relative).ToString()))
            {
                while (!goodsData.EndOfStream)
                {
                    string[] parameters = goodsData.ReadLine()?.Split('}');
                    for (int i = 0; i < parameters.Length; i++)
                        parameters[i] = parameters[i].Trim(' ', ',', '{', '}');

                    int id = int.Parse(parameters[0]);
                    string name = parameters[1];
                    string model = parameters[2];
                    string manufacturer = parameters[3];
                    string description = parameters[4];
                    goods.Add(new Good(id, name, model, manufacturer, description));
                }
            }
            return goods;
        }

        public List<Shop> LoadShops(List<Good> goods)
        {
            var shops = new List<Shop>();

            // Shop describes as "Name, goodID1, price1, goodID2, price2, ..."
            using (var shopGoodsData = new StreamReader(new Uri(dataPath + shopsFileName, UriKind.Relative).ToString()))
            {
                while (!shopGoodsData.EndOfStream)
                {
                    string[] parameters = shopGoodsData.ReadLine().Split(',');
                    for (int i = 0; i < parameters.Length; i++)
                        parameters[i] = parameters[i].Trim(' ', '{', '}');

                    string shopName = parameters[0];
                    var items = new List<Item>();
                    for (int i = 1; i < parameters.Length; i += 2)
                    {
                        int goodID = int.Parse(parameters[i]);
                        Good goodFromId = goods.Find(good => good.ID == goodID);
                        float price = float.Parse(parameters[i + 1].Replace('.', ','));

                        items.Add(new Item(goodFromId, shopName, price));
                    }

                    shops.Add(new Shop(shopName, items));
                }
            }
            return shops;
        }

        public List<Order> DeserializeOrders()
        {
            string path = dataPath + jsonFileName;
            if (File.Exists(path) == false || File.ReadAllText(path) == "")
                return new List<Order>();

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Order>));
                return (List<Order>)jsonSerializer.ReadObject(fs);
            }
        }

        public void SerializeOrders(List<Order> orders)
        {
            string path = dataPath + jsonFileName;
            if (orders == null || orders.Count == 0)
                return;

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Order>));
                jsonSerializer.WriteObject(fs, orders);
            }
        }
    }
}
