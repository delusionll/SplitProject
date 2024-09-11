
namespace BLL.Tests.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;

[TestFixture]
public class ExpenseServiceTests
{
    private Mock<ICRUDService> _crudServiceMock;
    private Mock<IDTOService<Expense, ExpenseDTO>> _expenseDTOServiceMock;
    private ExpenseService _expenseService;

    [SetUp]
    public void Setup()
    {
        _crudServiceMock = new Mock<ICRUDService>();
        _expenseDTOServiceMock = new Mock<IDTOService<Expense, ExpenseDTO>>();
        _expenseService = new ExpenseService(_crudServiceMock.Object, _expenseDTOServiceMock.Object);
    }

    [Test]
    public async Task CountAsync_ValidInput_UpdatesBalances()
    {
        // Arrange
        var fromUser = new User { UserID = 1, Balance = 100 };
        var benefitersList = new List<UserBenefiter>
            {
                new UserBenefiter { User = new User { UserID = 2 }, Share = 50 },
                new UserBenefiter { User = new User { UserID = 3 }, Share = 50 }
            };

        _crudServiceMock.Setup(x => x.GetByIdAsync<User>(2)).ReturnsAsync(new User { UserID = 2, Balance = 50 });
        _crudServiceMock.Setup(x => x.GetByIdAsync<User>(3)).ReturnsAsync(new User { UserID = 3, Balance = 50 });

        // Act
        await _expenseService.CountAsync(100, fromUser, benefitersList);

        // Assert
        Assert.AreEqual(200, fromUser.Balance);
        _crudServiceMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        _crudServiceMock.Verify(x => x.GetByIdAsync<User>(2), Times.Once);
        _crudServiceMock.Verify(x => x.GetByIdAsync<User>(3), Times.Once);
    }

    [Test]
    public void CountAsync_InvalidShareSum_ThrowsArgumentException()
    {
        // Arrange
        var fromUser = new User { UserID = 1, Balance = 100 };
        var benefitersList = new List<UserBenefiter>
            {
                new UserBenefiter { User = new User { UserID = 2 }, Share = 30 },
                new UserBenefiter { User = new User { UserID = 3 }, Share = 50 }
            };

        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _expenseService.CountAsync(100, fromUser, benefitersList));

        Assert.That(ex.Message, Is.EqualTo("wrong share Sum"));
    }

    [Test]
    public async Task CreateAsync_ValidExpense_CreatesExpenseAndUpdatesBalances()
    {
        // Arrange
        var expenseDTO = new ExpenseDTO { UserID = 1, Amount = 100, Benefiters = new List<UserBenefiter>() };
        var expense = new Expense { UserID = 1, Amount = 100 };
        var user = new User { UserID = 1, Balance = 200 };

        _expenseDTOServiceMock.Setup(x => x.Map(expenseDTO)).Returns(expense);
        _crudServiceMock.Setup(x => x.AddAsync(expense)).Returns(Task.CompletedTask);
        _crudServiceMock.Setup(x => x.GetByIdAsync<User>(1)).ReturnsAsync(user);

        // Act
        var result = await _expenseService.CreateAsync(expenseDTO);

        // Assert
        Assert.AreEqual(expense, result);
        Assert.AreEqual(100, user.Balance);
        _crudServiceMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void CreateAsync_NullUser_ThrowsArgumentNullException()
    {
        // Arrange
        var expenseDTO = new ExpenseDTO { UserID = 1, Amount = 100 };
        var expense = new Expense { UserID = 1, Amount = 100 };

        _expenseDTOServiceMock.Setup(x => x.Map(expenseDTO)).Returns(expense);
        _crudServiceMock.Setup(x => x.AddAsync(expense)).Returns(Task.CompletedTask);
        _crudServiceMock.Setup(x => x.GetByIdAsync<User>(1)).ReturnsAsync((User)null);

        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _expenseService.CreateAsync(expenseDTO));

        Assert.That(ex.ParamName, Is.EqualTo("user"));
    }
}