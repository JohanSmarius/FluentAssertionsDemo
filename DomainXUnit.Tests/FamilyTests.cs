using Domain;
using FluentAssertions;

namespace DomainXUnit.Tests;

public class FamilyTests
{
    [Fact]
    public void Given_Added_Children_Should_Not_Be_Empty()
    {
        // Arrange
        var sut = new Family(1000, "Test family", "Some street 25");
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
        var sut = new Family(1000, "Test family", "Some street 25");
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().BeEmpty();
    }
    
    [Fact]
    public void Given_Added_Children_Should_Return_Correct_Count()
    {
        // Arrange
        var sut = new Family(1000, "Test family", "Some street 25");
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
        var sut = new Family(1000, "Test family", "Some street 25");
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
        var sut = new Family(1000, "Test family", "Some street 25");
        
        sut.AddChild(new Child() { Name = "Ben", Gender = Gender.Male, Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Gender= Gender.Female, Age = 7});
        
        // Act
        var children = sut.Children();

        // Assert
        children.Should().Contain(child => child.Gender == Gender.Female);
        children.Should().ContainSingle(child => child.Gender == Gender.Female);
    }
    
    
    [Fact]
    public void AverageGiftAmount_Given_Added_Children_With_Gift_Should_Return_Average()
    {
        // Arrange
        var sut = new Family(1000, "Test family", "Some street 25");
        
        sut.AddChild(new Child() { Name = "Ben", Gender = Gender.Male, 
            Gift = new Gift(1) { Price = 12.99m }, Age = 10 });
        sut.AddChild(new Child() { Name = "Iris", Gender= Gender.Female, 
            Gift = new Gift(1) { Price = 15.97m }, Age = 7 });
        
        // Act
        var average = sut.AverageGiftAmount;

        // Assert
        average.Should().BePositive();
        average.Should().Be(14.48m);
        average.Should().BeApproximately(14.4m, 0.1m);
    }

    [Fact]
    public void AddGiftForChild_Given_Child_Found_ShouLd_Add_Gift()
    {
        // Arrange
        var sut = new Family(1000, "Test family", "Some street 25");

        var child = new Child()
        {
            Name = "Ben", Gender = Gender.Male,
            Age = 10
        };
        sut.AddChild(child);
        
        // Act
        sut.AddGiftForChild(child, new Gift(1) { Price = 100m });

        child.Gift.Should().NotBeNull();
        child.Gift?.Price.Should().Be(100m);

    }
    
    [Fact]
    public void AddGiftForChild_Child_Not_Found_Should_Throw_ArgumentException()
    {
        // Arrange
        var sut = new Family(1000, "Test family", "Some street 25");

        var child = new Child()
        {
            Name = "Ben", Gender = Gender.Male,
            Age = 10
        };

        var gift = new Gift(1)
        {
            Price = 100m
        };

        // Act and assert in one
        sut.Invoking(a => a.AddGiftForChild(child, gift)).Should().Throw<ArgumentException>().WithMessage("Child not found");

        child.Gift.Should().BeNull();
    }
    
    [Fact]
    public void AddGiftForChild_Gift_Above_Budget_Should_Throw_GiftException()
    {
        // Arrange
        var sut = new Family(10, "Test family", "Some street 25");

        var child = new Child()
        {
            Name = "Ben", Gender = Gender.Male,
            Age = 10
        };

        var gift = new Gift(1)
        {
            Price = 100m
        };
        
        sut.AddChild(child);

        // Act
        Action action = () => sut.AddGiftForChild(child, gift);

        // Assert
        action.Should().Throw<GiftException>().WithMessage("Gift is too expensive");

        child.Gift.Should().BeNull();
    }
    
    
    


}