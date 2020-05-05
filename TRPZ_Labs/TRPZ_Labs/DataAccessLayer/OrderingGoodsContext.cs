using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;

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
    }
}
