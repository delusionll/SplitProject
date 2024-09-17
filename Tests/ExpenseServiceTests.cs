namespace Tests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using BLL.Services;
using DAL;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

/// <summary>
/// <see cref="ExpenseService"/> tests.
/// </summary>
[TestFixture]
public class ExpenseServiceTests
{
    private ICRUDService _crudService;
    private Mock<IDTOService<Expense, ExpenseDTO>> _expenseDTOServiceMock;
    private ExpenseService _expenseService;
    private SplitContext _context;

    /// <summary>
    /// Setup.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<SplitContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new SplitContext(options);
        _crudService = new CRUDService(_context);
        _expenseDTOServiceMock = new Mock<IDTOService<Expense, ExpenseDTO>>();
        _expenseService = new ExpenseService(_crudService, _expenseDTOServiceMock.Object);
    }

    [TearDown]
    public void TearDownContext()
    {
        if (_context != null)
            _context.Dispose();
    }

    /// <summary>
    /// Tests <see cref="ExpenseService.CountAsync(decimal, User, IEnumerable{UserBenefiter})"/> <see langword="method"/> on valid input and proper balance update.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Test]
    public async Task CountAsync_ValidInput_UpdatesBalances()
    {
        var fromUser1 = new User("testUser1") { Balance = 100 };
        await _crudService.AddAsync(fromUser1);
        var benefitersList = new List<UserBenefiter>();
        var expense = new Expense("testExpense1", 100, fromUser1.UserID, benefitersList);
        var newUser2 = new User("testUser2") { Balance = 50 };
        await _crudService.AddAsync(newUser2);
        var newUser3 = new User("testUser3") { Balance = 50 };
        await _crudService.AddAsync(newUser3);
        var testUserBenefiter2 = new UserBenefiter(newUser2, 50, expense.ExpenseID);
        var testUserBenefiter3 = new UserBenefiter(newUser3, 50, expense.ExpenseID);
        var userBenefiters = new List<UserBenefiter>
            {
                testUserBenefiter2,
                testUserBenefiter3,
            };
        benefitersList.AddRange(userBenefiters);
        await _crudService.AddAsync(expense);

        Assert.Equals(_crudService.GetByIdAsync<User>(testUserBenefiter2.ID), newUser2);
        Assert.Equals(_crudService.GetByIdAsync<User>(testUserBenefiter3.ID), newUser3);

        await _expenseService.CountAsync(100, fromUser1, benefitersList);

        Assert.Equals(200, fromUser1.Balance);
        _crudService.Verify(x => x.SaveChangesAsync(), Times.Once);
        _crudService.Verify(x => x.GetByIdAsync<User>(newUser2.UserID), Times.Once);
        _crudService.Verify(x => x.GetByIdAsync<User>(newUser3.UserID), Times.Once);
    }

    [Test]
    public void CountAsync_InvalidShareSum_ThrowsArgumentException()
    {
        var fromUser1 = new User("testUser1") { Balance = 100 };
        var benefitersList = new List<UserBenefiter>();
        var expense = new Expense("testExpense1", 100, fromUser1.UserID, benefitersList);
        var newUser2 = new User("testUser2") { Balance = 50 };
        var newUser3 = new User("testUser3") { Balance = 50 };
        var testUserBenefiter2 = new UserBenefiter(newUser2, 25, expense.ExpenseID);
        var testUserBenefiter3 = new UserBenefiter(newUser3, 50, expense.ExpenseID);
        var userBenefiters = new List<UserBenefiter>
            {
                testUserBenefiter2,
                testUserBenefiter3,
            };
        benefitersList.AddRange(userBenefiters);

        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _expenseService.CountAsync(100, fromUser1, benefitersList));

        Assert.That(ex.Message, Is.EqualTo("wrong share Sum"));
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Test]
    public async Task CreateAsync_ValidExpense_CreatesExpenseAndUpdatesBalances()
    {
        var user = new User(Guid.NewGuid(), 200, "testUser1");
        var userGuid = Guid.NewGuid();
        var userBenefiterGuid = Guid.NewGuid();
        var expenseGuid = Guid.NewGuid();
        var benefitersDTO = new List<UserBenefiterDTO>() { new UserBenefiterDTO(userBenefiterGuid, 100, expenseGuid) };
        var benefiters = new List<UserBenefiter>() { new UserBenefiter(user, 100, expenseGuid) };
        var expenseDTO = new ExpenseDTO(100, benefitersDTO, "testExpenseDTO1", userGuid);
        var expense = new Expense("testExpenseDTO1", 100, userGuid, benefiters);

        _expenseDTOServiceMock.Setup(x => x.Map(expenseDTO)).Returns(expense);
        IActionResult okResult = new OkResult();
        _crudService.Setup(x => x.AddAsync(expense)).ReturnsAsync(new OkResult());
        _crudService.Setup(x => x.GetByIdAsync<User>(userGuid)).ReturnsAsync(user);

        var result = await _expenseService.CreateAsync(expenseDTO);

        Assert.Equals(expense, result);
        Assert.Equals(100, user.Balance);
        _crudService.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void CreateAsync_NullUser_ThrowsArgumentNullException()
    {
        var userGuid = Guid.NewGuid();
        var user = new User(Guid.NewGuid(), 200, "testUser1");
        var expenseGuid = Guid.NewGuid();
        var userBenefiterGuid = Guid.NewGuid();
        var benefiters = new List<UserBenefiter>() { new UserBenefiter(user, 100, expenseGuid) };
        var benefitersDTO = new List<UserBenefiterDTO>() { new UserBenefiterDTO(userBenefiterGuid, 100, expenseGuid) };
        var expenseDTO = new ExpenseDTO(100, benefitersDTO, "testExpenseDTO1", userGuid);
        var expense = new Expense("testExpenseDTO1", 100, userGuid, benefiters);

        _expenseDTOServiceMock.Setup(x => x.Map(expenseDTO)).Returns(expense);
        _crudService.Setup(x => x.AddAsync(expense)).ReturnsAsync(new OkResult());
        _crudService.Setup(x => x.GetByIdAsync<User>(Guid.NewGuid())).ReturnsAsync(null as User);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _expenseService.CreateAsync(expenseDTO));

        Assert.That(ex.ParamName, Is.EqualTo("user"));
    }
}