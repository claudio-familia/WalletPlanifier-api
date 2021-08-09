using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class WalletService : BaseService<Wallet, WalletDto>, IBaseService<Wallet, WalletDto>
    {
        private readonly IDataRepository<Wallet> dataRepository;                
        private readonly IUnitOfWork unitOfWork;
        private readonly ICurrentUserService currentUser;        
        private readonly IMapper mapper;

        public WalletService(IDataRepository<Wallet> dataRepository,
                             IUnitOfWork unitOfWork,
                             ICurrentUserService currentUser,
                             IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;            
            this.unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }        

        public override IEnumerable<WalletDto> GetAll()
        {
            var result = repository.GetAll().Where(x => x.CreatorUserId == currentUser.UserId);

            return mapper.Map<IEnumerable<WalletDto>>(result);
        }

        public override WalletDto Get(int id)
        {
            var result = dataRepository.Get(id);

            if (result.CreatorUserId != currentUser.UserId) throw new TypeAccessException("This resource does not belong to the requester");

            return mapper.Map<WalletDto>(result);
        }
    }
}