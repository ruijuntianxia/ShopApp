using Microsoft.EntityFrameworkCore;
using ShopApp.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Data
{
    public class AddDataDbContext:DbContext
    {
        public DbSet<Member> Member { get; set; }
        public virtual DbSet<AddDataViewModel> AddDataViewModel { get; set; }
        public AddDataDbContext(DbContextOptions<AddDataDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AddDataViewModel>(entity =>
            {
                //当表中有两个以上不为空的属性时 可能haskey会不同需根据自己的条件修改
                //作为更新时候的条件
                entity.HasKey(e => e.id);
                //表示此属性时值在新增时自动生成
                entity.Property(e => e.id).ValueGeneratedOnAdd();

                entity.Property(e => e.classify)
                            .HasMaxLength(30)
                            .ValueGeneratedNever();

                entity.Property(e => e.brand).HasMaxLength(30);

                entity.Property(e => e.model).HasMaxLength(50);

                entity.Property(e => e.modelmum).HasMaxLength(50);

                entity.Property(e => e.imageurl).HasMaxLength(255);

                entity.Property(e => e.remark).HasMaxLength(255);



                entity.Property(e => e.createuser).HasMaxLength(50);
                entity.Property(e => e.createdate).HasColumnType("datetime");
                entity.Property(e => e.updateuser).HasMaxLength(50);
                entity.Property(e => e.updatedate).HasColumnType("datetime");


            });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

    }
}
