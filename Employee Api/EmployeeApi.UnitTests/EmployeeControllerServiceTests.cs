using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Core.Commands.EmployeeCommand;
using EmployeeApi.Core.Queries;
using EmployeeApi.Models;
using EmployeeApi.Web.Services;
using Moq;

namespace EmployeeApi.UnitTests;

public class EmployeeControllerServiceTests
{
    private readonly Mock<ICommandProcessor> _mockCommandProcessor;
    private readonly Mock<IQueryProcessor> _mockQueryProcessor;
    private readonly EmployeeControllerService _employeeControllerService;

    public EmployeeControllerServiceTests()
    {
        _mockCommandProcessor = new Mock<ICommandProcessor>();
        _mockQueryProcessor = new Mock<IQueryProcessor>();
        _employeeControllerService = new EmployeeControllerService(_mockCommandProcessor.Object, _mockQueryProcessor.Object);
    }

    [Fact]
    public async Task CreateAsync_WithValidModel_ShouldCallCommandProcessorHandle()
    {
        // Arrange
        var model = new EmployeeModel
        {
            Name = "John Doe",
            Age = 30
        };

        // Act
        await _employeeControllerService.CreateAsync(model);

        // Assert
        _mockCommandProcessor.Verify(cp => cp.Handle(It.IsAny<EmployeeCommand>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange
        var model = new EmployeeModel
        {
            Name = null,
            Age = 30
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _employeeControllerService.CreateAsync(model));
    }

    [Fact]
    public async Task CreateAsync_WithNegativeAge_ShouldThrowArgumentException()
    {
        // Arrange
        var model = new EmployeeModel
        {
            Name = "John Doe",
            Age = -30
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _employeeControllerService.CreateAsync(model));
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallQueryProcessorHandle()
    {
        // Act
        await _employeeControllerService.GetAllAsync();

        // Assert
        _mockQueryProcessor.Verify(qp => qp.Handle(It.IsAny<GetAllEmployeesQuery>()), Times.Once);
    }
}
