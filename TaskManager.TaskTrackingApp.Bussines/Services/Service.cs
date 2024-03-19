using AutoMapper;
using FluentValidation;
using TaskManager.TaskTrackingApp.Bussines.Interfaces;
using TaskManager.TaskTrackingApp.Common;
using TaskManager.TaskTrackingApp.Common.Enums;
using TaskManager.TaskTrackingApp.Common.Interfaces;
using TaskManager.TaskTrackingApp.DataAccess.Interfaces;
using TaskManager.TaskTrackingApp.Dtos.AppUserTaskDtos;
using TaskManager.TaskTrackingApp.Dtos.Interfaces;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.Bussines.Services
{
    public abstract class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T> where
        CreateDto : class, ICreateDto where
        UpdateDto : class, IUpdateDto where
        ListDto : class, IListDto where
        T : BaseEntity
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createValidator;

        public Service(IUow uow, IMapper mapper, IValidator<CreateDto> createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _uow.GetRepository<T>().CreateAsync(_mapper.Map<T>(dto));
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success,dto);
            }
            return new Response<CreateDto>(ResponseType.ValidationError, dto);

        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var result = await _uow.GetRepository<T>().GetAllAsync();
            return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(result));
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            var result = await _uow.GetRepository<T>().GetAllAsync(filter);
            return new Response<List<ListDto>>(ResponseType.Success, _mapper.Map<List<ListDto>>(result));
        }

        public  async Task<IResponse<ListDto>> GetByIdAsync(int id) 
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data != null)
            {
                return new Response<ListDto>(ResponseType.Success, _mapper.Map<ListDto>(data));
            }
            return new Response<ListDto>( ResponseType.NotFound, "Böyle bir kayıta ulaşılamadı.", _mapper.Map<ListDto>(data));
        }

        public async Task<IResponse> Remove(ListDto dto)
        {
            _uow.GetRepository<T>().Remove(_mapper.Map<T>(dto));
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            try
            {
                _uow.GetRepository<T>().Update(await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == dto.Id), _mapper.Map<T>(dto));
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success,dto);
            }
            catch (Exception e)
            {
                return new Response<UpdateDto>(ResponseType.Error,$"Bir sorun oluştu Hata mesajı : {e.Message}", dto);
            }
        }



    }
}
