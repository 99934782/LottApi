using LottGameApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LottGameApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<Banner[]> GetAllBanner();
        Task<ButtonsLinks[]> GetAllButtons();
        Task<ButtonsLinks[]> GetButtonsByLanguage(string language);
        Task<Banner[]> GetBannerByLanguage(string language);
    }
}
