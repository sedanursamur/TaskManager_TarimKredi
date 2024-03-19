using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Interfaces
{
    public interface IIncludeable<Dto> where Dto : class,IDto , new()
    {
        Task<IResponse<Dto>> GetIncluded(int id);

        Task<IResponse<List<Dto>>> GetIncluded();
    }
}
