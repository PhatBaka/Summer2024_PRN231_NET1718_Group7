using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(RoleDTO createModel)
        {
            Role role = _mapper.Map<Role>(createModel);
            return await _roleRepository.AddAsync(role);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var role = (await _roleRepository.GetAsync(r => r.RoleId == id)).FirstOrDefault();
                if (role != null)
                {
                    await _roleRepository.RemoveAsync(role);
                }
                else
                {
                    throw new KeyNotFoundException("Role not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoleDTO>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles.ToList());
        }

        public async Task<RoleDTO> GetByIdAsync(Guid id)
        {
            var role = (await _roleRepository.GetAsync(r => r.RoleId == id)).FirstOrDefault();
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task UpdateAsync(Guid id, RoleDTO updateModel)
        {
            var role = (await _roleRepository.GetAsync(r => r.RoleId == id)).FirstOrDefault();
            if (role != null)
            {
                var updateRole = _mapper.Map(updateModel, role);
                await _roleRepository.UpdateAsync(updateRole);
            }
            else
            {
                throw new KeyNotFoundException("Role not found.");
            }
        }
    }
}
