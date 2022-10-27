using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models;
using SystemManagement.Models.Dto;


namespace SystemManagement.Database
{
    public class ApiDbContext:DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Pallet> Pallets { get; set; }

        public DbSet<Node> Nodes { get; set; }

        public DbSet<Lpn> Lpns { get; set; }

        public DbSet<WareHouse> WareHouses { get; set; }


        //questiongrou - > 
        //modelBuilder.Entity<Product>()
        //HasKey(t => new { t.PalletId });

        //modelBuilder.Entity<Product>()
        //  .HasOne(qg => qg.Pallet)
        //.WithMany(q => q.Product)
        //.HasForeignKey(qg => qg.Id);

        //  modelBuilder.Entity<Product>()
        //    .HasOne(qg => qg.Group)
        //  .WithMany(g => g.QuestionGroups)
        //.HasForeignKey(qg => qg.GroupId);
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Product>.HasData(new Product
            {
                ProductId = 1,
                ProductType="Chair",
                Price=3000,
                Quantity=10,
                
            });
            
        }*/
    }
}
