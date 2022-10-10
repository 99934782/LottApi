using Microsoft;
using Microsoft.EntityFrameworkCore;
using LottGameApi.Models;

namespace LottGameApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ButtonsLinks> Buttons { get; set; }
    }
}
