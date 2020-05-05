using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrderingGoods.DataAccessLayer
{
    public class OrderingGoodsContext : DbContext
    {
        public DbSet<GoodEntity> Goods { get; set; }
        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public OrderingGoodsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            

            List<GoodEntity> goods = new List<GoodEntity>
            {
                new GoodEntity
                {
                    ID = 1,
                    Name = "Стіл",
                    Model = "Вікторія",
                    Manufacturer = "Київмеблі",
                    Description = "Дерев'яний дубовий стіл з шухлядками"
                },
                new GoodEntity
                {
                    ID = 2,
                    Name = "Шафа",
                    Model = "Сергій",
                    Manufacturer = "Київмеблі",
                    Description = "Дерев'яна соснова шафа-купе"
                },
                new GoodEntity
                {
                    ID = 3,
                    Name = "Футболка",
                    Model = null,
                    Manufacturer = "Versacci",
                    Description = "Блакитна футболка розміру XS з принтом в стилі аніме"
                },
                new GoodEntity
                {
                    ID = 4,
                    Name = "Шорти",
                    Model = null,
                    Manufacturer = "Хмельницький ринок",
                    Description = "Червоні шорти розміру L з зображеннями пальм"
                },
                new GoodEntity
                {
                    ID = 5,
                    Name = "Кросівки",
                    Model = null,
                    Manufacturer = "Reebok",
                    Description = "Білі кросівки 37 розміру"
                },
                new GoodEntity
                {
                    ID = 6,
                    Name = "Пральна машина",
                    Model = "HT3001",
                    Manufacturer = "Kaiser",
                    Description = "Пральна машина з горизонтальним завантаженням 134х109х65"
                },
                new GoodEntity
                {
                    ID = 7,
                    Name = "Мікрохвильова піч",
                    Model = "Profy",
                    Manufacturer = "LG",
                    Description = "Мікрохвильова піч з 35 режимами роботи 74х43х50"
                },
                new GoodEntity
                {
                    ID = 8,
                    Name = "Ноутбук",
                    Model = "ProBook 4540s",
                    Manufacturer = "HP",
                    Description = "Ноутбук чорного кольору з діагоналлю 15', 8-ядерним процесором Intel Core i7 і відеокартою nVidia GeForce"
                },
                new GoodEntity
                {
                    ID = 9,
                    Name = "Телефон",
                    Model = "Galaxy S10",
                    Manufacturer = "Samsung",
                    Description = "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632 і NFC"
                },
                new GoodEntity
                {
                    ID = 10,
                    Name = "Телефон",
                    Model = "Redmi Note 7A",
                    Manufacturer = "Xiaomi",
                    Description = "Смартфон з діагоналлю 5,7', 4-ядерним процесором MediaTek 231 і сканером відбитків пальців"
                },
                new GoodEntity
                {
                    ID = 11,
                    Name = "Телефон",
                    Model = "Redmi Note 8T",
                    Manufacturer = "Xiaomi",
                    Description = "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632, NFC і IRDA"
                }
            };
            modelBuilder.Entity<GoodEntity>().HasData(goods);
            modelBuilder.Entity<ShopEntity>().HasData(
                new ShopEntity
                {
                    ID = 1,
                    Name = "TechCenter",
                    Items = new Collection<ItemEntity>
                    {
                        new ItemEntity
                        { ID = 1, Good = goods.Find(good => good.ID == 8), Price = 999.9 },
                        new ItemEntity
                        { ID = 2, Good = goods.Find(good => good.ID == 9), Price = 450 },
                        new ItemEntity
                        { ID = 3, Good = goods.Find(good => good.ID == 10), Price = 325.5 },
                        new ItemEntity
                        { ID = 4, Good = goods.Find(good => good.ID == 11), Price = 624.43 }
                    }
                },
                new ShopEntity
                {
                    ID = 2,
                    Name = "Eldorado",
                    Items = new Collection<ItemEntity>
                    {
                        new ItemEntity
                        { ID = 5, Good = goods.Find(good => good.ID == 8), Price = 1099.9 },
                        new ItemEntity
                        { ID = 6, Good = goods.Find(good => good.ID == 9), Price = 400 },
                        new ItemEntity
                        { ID = 7, Good = goods.Find(good => good.ID == 10), Price = 325.5 },
                        new ItemEntity
                        { ID = 8, Good = goods.Find(good => good.ID == 6), Price = 345 },
                        new ItemEntity
                        { ID = 9, Good = goods.Find(good => good.ID == 7), Price = 63.54 }
                    }
                },
                new ShopEntity
                {
                    ID = 3,
                    Name = "Furniture House",
                    Items = new Collection<ItemEntity>
                    {
                        new ItemEntity
                        { ID = 10, Good = goods.Find(good => good.ID == 1), Price = 36.25 },
                        new ItemEntity
                        { ID = 11, Good = goods.Find(good => good.ID == 2), Price = 209 }
                    }
                },
                new ShopEntity
                {
                    ID = 4,
                    Name = "Second hand",
                    Items = new Collection<ItemEntity>
                    {
                        new ItemEntity
                        { ID = 12, Good = goods.Find(good => good.ID == 3), Price = 10.12 },
                        new ItemEntity
                        { ID = 13, Good = goods.Find(good => good.ID == 4), Price = 5.74 },
                        new ItemEntity
                        { ID = 14, Good = goods.Find(good => good.ID == 5), Price = 44.12 }
                    }
                },
                new ShopEntity
                {
                    ID = 5,
                    Name = "1000 things",
                    Items = new Collection<ItemEntity>
                    {
                        new ItemEntity
                        { ID = 15, Good = goods.Find(good => good.ID == 1), Price = 40.2 },
                        new ItemEntity
                        { ID = 16, Good = goods.Find(good => good.ID == 5), Price = 25.65 },
                        new ItemEntity
                        { ID = 17, Good = goods.Find(good => good.ID == 8), Price = 899.9 },
                        new ItemEntity
                        { ID = 18, Good = goods.Find(good => good.ID == 10), Price = 300.6 }
                    }
                });            
        }
    }
}
