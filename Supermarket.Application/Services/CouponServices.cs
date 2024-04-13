﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class CouponServices : ICouponServices
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public CouponServices(ICouponRepository couponRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CouponResposeDto>> GetAllAsync()
        {
            var result = await _couponRepository.GetAllAsync();
            var resultMap = _mapper.Map<IEnumerable<CouponResposeDto>>(result);
            return resultMap;
        }

        public async Task<CouponResposeDto> GetByIdAsync(int id)
        {
            var result = await _couponRepository.GetSingleByIdAsync(id);
            var resultMap = _mapper.Map<CouponResposeDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(CouponRequestDto entity)
        {
            var entityMap = _mapper.Map<Coupon>(entity);
            var result = await _couponRepository.AddAsync(entityMap);
            await _unitOfWork.CommitAsync();
            return result!=null?true:false;
        }

        public async Task<bool> UpdateAsync(CouponRequestDto entity, int id)
        {
            var entityMap = _mapper.Map<Coupon>(entity);
            var result = await _couponRepository.UpdateAsync(entityMap,id,"Coupon");
            await _unitOfWork.CommitAsync();
            return result != null ? true : false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _couponRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return result != null ? true : false;
        }
    }
}