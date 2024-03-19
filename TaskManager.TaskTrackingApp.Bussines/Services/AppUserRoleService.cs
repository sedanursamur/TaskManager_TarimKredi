using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.Dtos;
using TaskManager.TaskTrackingApp.Dtos.AppUserRoleDtos;
using TaskManager.TaskTrackingApp.Dtos.DegreeDtos;
using TaskManager.TaskTrackingApp.Dtos.PriortryDtos;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Services
{
    public class AppUserRoleService : Service<AppUserRoleCreateDto, AppUserRoleUpdateDto, AppUserRoleListDto, AppUserRole>, IAppUserRoleService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AppUserRoleService(IUow uow , IMapper mapper, IValidator<AppUserRoleCreateDto> createvalidator) : base(uow,mapper,createvalidator)
        {
            _uow = uow;
        }

        public async Task AddRolesToDatabase()
        {
            // Veritabanında enum değerlerinin varlığını kontrol edelim
            var existingDegree = await _uow.GetRepository<Degree>().GetAllAsync();
            var existingAppRole = await _uow.GetRepository<AppRole>().GetAllAsync();
            var roles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().ToList();

            if (existingDegree.Count == 0)
            {
                // Enum değerleri veritabanında henüz eklenmemiş, ekleme işlemini yapalım
                foreach (var role in roles)
                {
                    await _uow.GetRepository<Degree>().CreateAsync(new Degree
                    {
                        Defination = role.ToString()
                    });
                }

                await _uow.SaveChangesAsync();
            }

            if (existingAppRole.Count == 0)
            {
                foreach (var role in roles)
                {
                    await _uow.GetRepository<AppRole>().CreateAsync(new AppRole
                    {
                        Defination = role.ToString()
                    });
                }

                await _uow.SaveChangesAsync();
            }
        }
        public async Task CreateAdminUser()
        {
            var isExistAdminRole = await _uow.GetRepository<AppUserRole>().GetAllAsync(ur => ur.AppRoleId == 1);
            if (isExistAdminRole.Count == 0)
            {
                var adminUser = new AppUser
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Username = "admin2",
                    Password = "admin", // Parolayı henüz şifrelemedim 
                    Email = "admin@example.com",
                    DegreeId = 1, // Admin rolü için uygun DegreeId değeri atanır
                    IsActive = true // İsteğe bağlı olarak hesabı aktif edin veya devre dışı bırakın
                };

                await _uow.GetRepository<AppUser>().CreateAsync(adminUser);

                await _uow.SaveChangesAsync();
                // Admin kullanıcısına admin rolünü atar
                var adminUserRole = new AppUserRole
                {
                    AppUserId = adminUser.Id,
                    AppRoleId = 1 // Admin rolünün Id'si
                };

                await _uow.GetRepository<AppUserRole>().CreateAsync(adminUserRole);

                await _uow.SaveChangesAsync();
            }

            }


   }
}
