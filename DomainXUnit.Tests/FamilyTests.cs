using Domain;
using FluentAssertions;

namespace DomainXUnit.Tests;

public class FamilyTests
{
    [Fact]
    public void Given_Added_Children_Should_Not_Be_Empty()
    {
        // Arrange
        var sut = new Family(1000);
        sut.AddChild(new Child() { Name = "Ben", Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Age = 7});
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Given_No_Children_Should_Be_Empty()
    {
        // Arrange
        var sut = new Family(1000);
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().BeEmpty();
    }
    
    [Fact]
    public void Given_Added_Children_Should_Return_Correct_Count()
    {
        // Arrange
        var sut = new Family(1000);
        sut.AddChild(new Child() { Name = "Ben", Gender = Gender.Male, Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Gender= Gender.Female, Age = 7});
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().HaveCount(2);
    }
    
    [Fact]
    public void Given_Added_Children_Should_Return_More_Than_One_Child()
    {
        // Arrange
        var sut = new Family(1000);
        sut.AddChild(new Child() { Name = "Ben", Gender = Gender.Male, Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Gender= Gender.Female, Age = 7});
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().HaveCountGreaterThan(1);
    }

    [Fact]
    public void Given_Added_Children_Should_Return_Girl()
    {
        // Arrange
        var sut = new Family(1000);
        sut.AddChild(new Child() { Name = "Ben", Gender = Gender.Male, Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Gender= Gender.Female, Age = 7});
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().Contain(child => child.Gender == Gender.Female);
    }
}