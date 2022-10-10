using LottGameApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LottGameApi.Data
{
    public class Repository : IRepository
    {
        public DataContext Context { get; }

        public Repository(DataContext context)
        {
            this.Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() > 0);
        }

        public async Task<Banner[]> GetAllBanner()
        {
            IQueryable<Banner> query = Context.Banners;

            return await query.ToArrayAsync();
        }

        public async Task<ButtonsLinks[]> GetAllButtons()
        {
            IQueryable<ButtonsLinks> query = Context.Buttons;

            return await query.ToArrayAsync();
        }

        public async Task<ButtonsLinks[]> GetButtonsByLanguage(string language)
        {
            IQueryable<ButtonsLinks> query = Context.Buttons.Where(x => x.Language == language);

            return await query.ToArrayAsync();
        }

        public async Task<Banner[]> GetBannerByLanguage(string language)
        {
            IQueryable<Banner> query = Context.Banners.Where(x => x.Language == language);

            return await query.ToArrayAsync();
        }
    }
}
