using DSTutorials1909.Models;
using Microsoft.EntityFrameworkCore;


namespace DSTutorials1909.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) 
        {
            
        }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }

        public DbSet<Content> Contents { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>().HasOne(i => i.Courses).WithMany().HasForeignKey(u => u.CourseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SubMenu>().HasOne(i => i.Courses).WithMany().HasForeignKey(u => u.CourseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SubMenu>().HasOne(i => i.Menu).WithMany().HasForeignKey(u => u.MenuId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Content>().HasOne(i => i.Courses).WithMany().HasForeignKey(u => u.CourseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Content>().HasOne(i => i.Menu).WithMany().HasForeignKey(u => u.MenuId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Content>().HasOne(i => i.SubMenu).WithMany().HasForeignKey(u => u.SubMenuId).OnDelete(DeleteBehavior.Restrict);



        }

    }
}
