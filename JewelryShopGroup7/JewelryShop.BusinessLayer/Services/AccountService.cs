using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(AccountDTO createModel)
        {
            Account account = _mapper.Map<Account>(createModel);
            return await _accountRepository.AddAsync(account);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var account = (await _accountRepository.GetAsync(a => a.AccountId == id)).FirstOrDefault();
                if (account != null)
                {
                    await _accountRepository.RemoveAsync(account);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseResult<AccountDTO>> GetAccountByEmailAndPasswordAsync(LoginDTO loginDTO)
        {
            AccountDTO data;
            try
            {
                data = _mapper.Map<AccountDTO>(_accountRepository.GetFirstOrDefaultAsync(x => x.Email.Trim().Equals(loginDTO.Email)
                                                                                && x.Password.Equals(loginDTO.Password)).Result);

                if (data == null)
                {
                    return new ResponseResult<AccountDTO>()
                    {
                        Message = Constraints.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                return new ResponseResult<AccountDTO>()
                {
                    Message = Constraints.FOUND_INFO,
                    Result = true,
                    Data = data
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDTO>>(accounts.ToList());
        }

        public async Task<AccountDTO> GetByIdAsync(Guid id)
        {
            var account = (await _accountRepository.GetAsync(a => a.AccountId == id)).FirstOrDefault();
            return _mapper.Map<AccountDTO>(account);
        }

        public async Task UpdateAsync(Guid id, AccountDTO updateModel)
        {
            var account = (await _accountRepository.GetAsync(a => a.AccountId == id)).FirstOrDefault();
            if (account != null)
            {
                var updateAccount = _mapper.Map(updateModel,account);
                await _accountRepository.UpdateAsync(updateAccount);
            } else
            {
                throw new KeyNotFoundException("Account not found.");
            }
        }
    }
}
