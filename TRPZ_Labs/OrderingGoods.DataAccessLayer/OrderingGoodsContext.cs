using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace OrderingGoods.DataAccessLayer
{
    public class OrderingGoodsContext : DbContext
    {
        public DbSet<GoodEntity> Goods { get; set; }
        public DbSet<GoodTypeEntity> GoodTypes { get; set; }
        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public OrderingGoodsContext() : base() { }

        public OrderingGoodsContext(DbContextOptions<OrderingGoodsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //For migrations only
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=OrderingGoods;Integrated Security=True";

            //string connectionString = ConfigurationManager.ConnectionStrings["OrderingGoodsDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GoodTypeEntity goodType1 = new GoodTypeEntity
            {
                Id = 1,
                Name = "Стіл"
            };
            GoodTypeEntity goodType2 = new GoodTypeEntity
            {
                Id = 2,
                Name = "Шафа"
            };
            GoodTypeEntity goodType3 = new GoodTypeEntity
            {
                Id = 3,
                Name = "Футболка"
            };
            GoodTypeEntity goodType4 = new GoodTypeEntity
            {
                Id = 4,
                Name = "Шорти"
            };
            GoodTypeEntity goodType5 = new GoodTypeEntity
            {
                Id = 5,
                Name = "Кросівки"
            };
            GoodTypeEntity goodType6 = new GoodTypeEntity
            {
                Id = 6,
                Name = "Пральна машина"
            };
            GoodTypeEntity goodType7 = new GoodTypeEntity
            {
                Id = 7,
                Name = "Мікрохвильова піч"
            };
            GoodTypeEntity goodType8 = new GoodTypeEntity
            {
                Id = 8,
                Name = "Ноутбук"
            };
            GoodTypeEntity goodType9 = new GoodTypeEntity
            {
                Id = 9,
                Name = "Телефон"
            };
            GoodTypeEntity goodType10 = new GoodTypeEntity
            {
                Id = 10,
                Name = "Фотоапарат"
            };

            GoodEntity good1 = new GoodEntity
            {
                Id = 1,
                TypeId = 1,
                Model = "Вікторія",
                Manufacturer = "Київмеблі",
                Description = "Дерев'яний дубовий стіл з шухлядками"
            };
            GoodEntity good2 = new GoodEntity
            {
                Id = 2,
                TypeId = 2,
                Model = "Сергій",
                Manufacturer = "Київмеблі",
                Description = "Дерев'яна соснова шафа-купе"
            };
            GoodEntity good3 = new GoodEntity
            {
                Id = 3,
                TypeId = 3,
                Model = null,
                Manufacturer = "Versacci",
                Description = "Блакитна футболка розміру XS з принтом в стилі аніме"
            };
            GoodEntity good4 = new GoodEntity
            {
                Id = 4,
                TypeId = 4,
                Model = null,
                Manufacturer = "Хмельницький ринок",
                Description = "Червоні шорти розміру L з зображеннями пальм"
            };
            GoodEntity good5 = new GoodEntity
            {
                Id = 5,
                TypeId = 5,
                Model = null,
                Manufacturer = "Reebok",
                Description = "Білі кросівки 37 розміру"
            };
            GoodEntity good6 = new GoodEntity
            {
                Id = 6,
                TypeId = 6,
                Model = "HT3001",
                Manufacturer = "Kaiser",
                Description = "Пральна машина з горизонтальним завантаженням 134х109х65"
            };
            GoodEntity good7 = new GoodEntity
            {
                Id = 7,
                TypeId = 7,
                Model = "Profy",
                Manufacturer = "LG",
                Description = "Мікрохвильова піч з 35 режимами роботи 74х43х50"
            };
            GoodEntity good8 = new GoodEntity
            {
                Id = 8,
                TypeId = 8,
                Model = "ProBook 4540s",
                Manufacturer = "HP",
                Description = "Ноутбук чорного кольору з діагоналлю 15', 8-ядерним процесором Intel Core i7 і відеокартою nVidia GeForce"
            };
            GoodEntity good9 = new GoodEntity
            {
                Id = 9,
                TypeId = 9,
                Model = "Galaxy S10",
                Manufacturer = "Samsung",
                Description = "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632 і NFC"
            };
            GoodEntity good10 = new GoodEntity
            {
                Id = 10,
                TypeId = 9,
                Model = "Redmi Note 7A",
                Manufacturer = "Xiaomi",
                Description = "Смартфон з діагоналлю 5,7', 4-ядерним процесором MediaTek 231 і сканером відбитків пальців"
            };
            GoodEntity good11 = new GoodEntity
            {
                Id = 11,
                TypeId = 9,
                Model = "Redmi Note 8T",
                Manufacturer = "Xiaomi",
                Description = "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632, NFC і IRDA"
            };
            GoodEntity good12 = new GoodEntity
            {
                Id = 12,
                TypeId = 10,
                Model = "300X",
                Manufacturer = "Nikon",
                Description = "Фотоапарат з 30х зумом, 50 режимами налаштувань і автофокусом"
            };

            ShopEntity shop1 = new ShopEntity
            {
                Id = 1,
                Name = "TechCenter"
            };
            ShopEntity shop2 = new ShopEntity
            {
                Id = 2,
                Name = "Eldorado"
            };
            ShopEntity shop3 = new ShopEntity
            {
                Id = 3,
                Name = "Furniture House"
            };
            ShopEntity shop4 = new ShopEntity
            {
                Id = 4,
                Name = "Second hand"
            };
            ShopEntity shop5 = new ShopEntity
            {
                Id = 5,
                Name = "1000 things"
            };

            object item1 = new { Id = 1, GoodId = 8, ShopId = 1, Price = 999.9 };
            object item2 = new { Id = 2, GoodId = 9, ShopId = 1, Price = 450.0 };
            object item3 = new { Id = 3, GoodId = 10, ShopId = 1, Price = 325.5 };
            object item4 = new { Id = 4, GoodId = 11, ShopId = 1, Price = 624.43 };

            object item5 = new { Id = 5, GoodId = 8, ShopId = 2, Price = 1099.9 };
            object item6 = new { Id = 6, GoodId = 9, ShopId = 2, Price = 400.0 };
            object item7 = new { Id = 7, GoodId = 10, ShopId = 2, Price = 325.5 };
            object item8 = new { Id = 8, GoodId = 6, ShopId = 2, Price = 345.0 };
            object item9 = new { Id = 9, GoodId = 7, ShopId = 2, Price = 63.54 };

            object item10 = new { Id = 10, GoodId = 1, ShopId = 3, Price = 36.25 };
            object item11 = new { Id = 11, GoodId = 2, ShopId = 3, Price = 209.0 };

            object item12 = new { Id = 12, GoodId = 3, ShopId = 4, Price = 10.12 };
            object item13 = new { Id = 13, GoodId = 4, ShopId = 4, Price = 5.74 };
            object item14 = new { Id = 14, GoodId = 5, ShopId = 4, Price = 44.12 };

            object item15 = new { Id = 15, GoodId = 1, ShopId = 5, Price = 40.2 };
            object item16 = new { Id = 16, GoodId = 5, ShopId = 5, Price = 25.65 };
            object item17 = new { Id = 17, GoodId = 8, ShopId = 5, Price = 899.9 };
            object item18 = new { Id = 18, GoodId = 10, ShopId = 5, Price = 300.6 };

            var goodTypes = new List<GoodTypeEntity>();
            goodTypes.Add(goodType1);
            goodTypes.Add(goodType2);
            goodTypes.Add(goodType3);
            goodTypes.Add(goodType4);
            goodTypes.Add(goodType5);
            goodTypes.Add(goodType6);
            goodTypes.Add(goodType7);
            goodTypes.Add(goodType8);
            goodTypes.Add(goodType9);
            goodTypes.Add(goodType10);

            var goods = new List<GoodEntity>();
            goods.Add(good1);
            goods.Add(good2);
            goods.Add(good3);
            goods.Add(good4);
            goods.Add(good5);
            goods.Add(good6);
            goods.Add(good7);
            goods.Add(good8);
            goods.Add(good9);
            goods.Add(good10);
            goods.Add(good11);
            goods.Add(good12);

            var shops = new List<ShopEntity>();
            shops.Add(shop1);
            shops.Add(shop2);
            shops.Add(shop3);
            shops.Add(shop4);
            shops.Add(shop5);

            var items = new List<object>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);
            items.Add(item6);
            items.Add(item7);
            items.Add(item8);
            items.Add(item9);
            items.Add(item10);
            items.Add(item11);
            items.Add(item12);
            items.Add(item13);
            items.Add(item14);
            items.Add(item15);
            items.Add(item16);
            items.Add(item17);
            items.Add(item18);

            modelBuilder.Entity<GoodTypeEntity>().HasData(goodTypes);
            modelBuilder.Entity<GoodEntity>().HasData(goods);
            modelBuilder.Entity<ShopEntity>().HasData(shops);
            modelBuilder.Entity<ItemEntity>().HasData(items);

            //ItemEntity item1 = new ItemEntity { Id = 1, Good = good8, Shop = shop1, Price = 999.9 };
            //ItemEntity item2 = new ItemEntity { Id = 2, Good = good9, Shop = shop1, Price = 450.0 };
            //ItemEntity item3 = new ItemEntity { Id = 3, Good = good10, Shop = shop1, Price = 325.5 };
            //ItemEntity item4 = new ItemEntity { Id = 4, Good = good11, Shop = shop1, Price = 624.43 };

            //ItemEntity item5 = new ItemEntity { Id = 5, Good = good8, Shop = shop2, Price = 1099.9 };
            //ItemEntity item6 = new ItemEntity { Id = 6, Good = good9, Shop = shop2, Price = 400.0 };
            //ItemEntity item7 = new ItemEntity { Id = 7, Good = good10, Shop = shop2, Price = 325.5 };
            //ItemEntity item8 = new ItemEntity { Id = 8, Good = good6, Shop = shop2, Price = 345.0 };
            //ItemEntity item9 = new ItemEntity { Id = 9, Good = good7, Shop = shop2, Price = 63.54 };

            //ItemEntity item10 = new ItemEntity { Id = 10, Good = good1, Shop = shop3, Price = 36.25 };
            //ItemEntity item11 = new ItemEntity { Id = 11, Good = good2, Shop = shop3, Price = 209.0 };

            //ItemEntity item12 = new ItemEntity { Id = 12, Good = good3, Shop = shop4, Price = 10.12 };
            //ItemEntity item13 = new ItemEntity { Id = 13, Good = good4, Shop = shop4, Price = 5.74 };
            //ItemEntity item14 = new ItemEntity { Id = 14, Good = good5, Shop = shop4, Price = 44.12 };

            //ItemEntity item15 = new ItemEntity { Id = 15, Good = good1, Shop = shop5, Price = 40.2 };
            //ItemEntity item16 = new ItemEntity { Id = 16, Good = good5, Shop = shop5, Price = 25.65 };
            //ItemEntity item17 = new ItemEntity { Id = 17, Good = good8, Shop = shop5, Price = 899.9 };
            //ItemEntity item18 = new ItemEntity { Id = 18, Good = good10, Shop = shop5, Price = 300.6 };
        }
    }
}
