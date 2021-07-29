using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Domain.Transactions;
using Xunit;

namespace WalletPlanifier.BusinessLogic.Services
{
    public class TransactionServiceTest
    {
        private readonly Mock<ITransactionService> _transactionService;
        private readonly Mock<IBaseService<Income, IncomeDto>> _incomeService;
        private readonly Mock<IBaseService<Debt, DebtDto>> _debtService;
        private readonly Mock<IBaseService<Wallet, WalletDto>> _walletService;
        private readonly List<TransactionDto> _listUserTransactions;
        private readonly UserDto _user;
        private readonly IncomeDto _income;
        private readonly DebtDto _debt;
        private readonly WalletDto _wallet;
        private readonly FrecuencyDto _frecuency;

        public TransactionServiceTest()
        {
            _user = new UserDto()
            {
                BirthDate = DateTime.Now,
                Email = "string@string.com",
                FirstName = "String",
                Gender = "M",
                Id = 1,
                LastName = "String",
                Nationality = "String",
                Password = "String",
                Profession = "String",
                UserName = "String",
            };

            _frecuency = new FrecuencyDto()
            {
                Description = "Quincenal",
                Id = 1,
                AmountInDays = 15
            };

            _income = new IncomeDto()
            {
                Id = 1,
                Amount = 10000,
                Description = "Some income",
                UserId = 1,
                User = _user,
                Frecuency = _frecuency,
                FrecuencyId = 1
            };

            _debt = new DebtDto()
            {
                Id = 1,
                Amount = 5000,
                Description = "Some debt",
                EndDate = DateTime.Now.AddDays(5),
                User = _user,
                UserId = 1,
                Frecuency = _frecuency,
                FrecuencyId = 1
            };

            _wallet = new WalletDto()
            {
                Id = 1,
                UserId = 1,
                Description = "Main Wallet",
                Total = 0,
                User = _user,
            };

            _listUserTransactions = new List<TransactionDto>()
            {
                new TransactionDto(){
                    Id = 1,
                    DebtId = null,
                    IncomeId = 1,
                    UserId = 1,
                    WalletId = 1,
                    Debt = null,
                    Income = _income,
                    Wallet = _wallet,
                    User = _user
                },
                new TransactionDto(){
                    Id = 2,
                    DebtId = 1,
                    IncomeId = null,
                    UserId = 1,
                    WalletId = 1,
                    Debt = _debt,
                    Income = null,
                    Wallet = _wallet,
                    User = _user
                },
                new TransactionDto(){},
                new TransactionDto(){},
                new TransactionDto(){},
                new TransactionDto(){},
            };

            _transactionService = new Mock<ITransactionService>();

            _incomeService = new Mock<IBaseService<Income, IncomeDto>>();

            _debtService = new Mock<IBaseService<Debt, DebtDto>>();

            _walletService = new Mock<IBaseService<Wallet, WalletDto>>();

            _transactionService.Setup(service => service.GetAllByClient(It.IsAny<int>())).Returns(_listUserTransactions);
        }

        [Fact]
        public void ShouldReturnAllUserTransaction()
        {
            var transactions = _transactionService.Object.GetAllByClient(1);

            Assert.True(transactions.Count() > 0);
            Assert.IsAssignableFrom<IEnumerable<TransactionDto>>(transactions);
            Assert.NotNull(transactions);
        }

        [Fact]
        public void ShouldCreateTransactionAfterCreatingIncome()
        {
            var newIncome = new IncomeDto()
            {
                Id = 2,
                Description = "New Income test",
                Amount = 50000,
                Frecuency = _frecuency,
                FrecuencyId = 1
            };

            _incomeService.Setup(service => service.Add(It.IsAny<IncomeDto>()))
                                                   .Returns(new Income() { 
                                                       Amount = newIncome.Amount,
                                                       Description = newIncome.Description,
                                                       Id = newIncome.Id,
                                                       Frecuency = new Frecuency() { 
                                                           Id = newIncome.Frecuency.Id,
                                                           Description = newIncome.Frecuency.Description,
                                                           AmountInDays = newIncome.Frecuency.AmountInDays,
                                                       },
                                                       FrecuencyId = newIncome.FrecuencyId
                                                   });            

            var incomeCreated = _incomeService.Object.Add(newIncome);

            var newTransaction = new TransactionDto()
            {
                Debt = null,
                DebtId = null,
                Id = 3,
                Income = newIncome,
                IncomeId = newIncome.Id,
                User = _user,
                UserId = 1,
                Wallet = _wallet,
                WalletId = 1
            };

            _transactionService.Setup(service => service.Add(It.IsAny<TransactionDto>()))
                               .Callback(() => _listUserTransactions.Add(newTransaction));

            _transactionService.Object.Add(newTransaction);

            _incomeService.Verify(x => x.Add(newIncome), Times.Once);
            _transactionService.Verify(x => x.Add(newTransaction), Times.Once);
            Assert.True(_listUserTransactions.Count(x => x.IncomeId == newIncome.Id) > 0);
            Assert.NotNull(incomeCreated);
            Assert.Equal(incomeCreated.Description, newIncome.Description);
            Assert.Equal(incomeCreated.Amount, newIncome.Amount);
            Assert.Equal(incomeCreated.FrecuencyId, newIncome.FrecuencyId);
        }

        [Fact]
        public void ShouldProccessIncomeTransaction()
        {
            Transaction resultTransaction = null;
            Wallet resultWallet = null;
            _transactionService.Setup(service => service.GetTransactionById(It.IsAny<int>(), It.IsAny<int>()))
                               .Returns(_listUserTransactions.FirstOrDefault());

            _transactionService.Setup(service => service.Update(It.IsAny<TransactionDto>()))
                               .Returns(new Transaction());

            _walletService.Setup(service => service.Update(It.IsAny<WalletDto>()))
                               .Returns(new Wallet());

            var transaction = _transactionService.Object.GetTransactionById(1, 1);


            if (transaction.IncomeId.HasValue)
            {
                transaction.OriginWalletValue = _wallet.Total;
                _wallet.Total += transaction.Income.Amount;
                transaction.IsCompleted = true;
                transaction.CompletedTime = DateTime.Now;

                resultTransaction = _transactionService.Object.Update(transaction);
                resultWallet = _walletService.Object.Update(_wallet);
            }


            Assert.NotNull(resultTransaction);
            Assert.NotNull(resultWallet);
        }

        [Fact]
        public void ShouldProccessDebtTransaction()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldProcessAllTransactions()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldUpdateWalletValue()
        {
            Assert.True(true);
        }
    }
}
