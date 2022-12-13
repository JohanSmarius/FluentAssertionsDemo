using Domain;
using FluentAssertions;

namespace DomainXUnit.Tests;

public class ChildTests
{
    [Fact]
    public void Given_Gift_Added_To_Child_HasGift_Should_Return_True()
    {
        var sut = new Child() {Age = 10, Gender = Gender.Female, Gift = new Gift(1), Name = "Iris"};

        sut.HasGift().Should().BeTrue("Gift has been added");
    }
    
    [Fact]
    public void Given_No_Gift_Added_To_Child_Gift_Should_Be_Null()
    {
        var sut = new Child() {Age = 10, Gender = Gender.X, Name = "Iris"};

        sut.Gift.Should().BeNull("No gift was assigned in object initializer");
    }
    
    [Fact]
    public void Given_Name_Assigned_To_Child_Should_Not_Be_Empty()
    {
        var sut = new Child() {Age = 10, Gender = Gender.X, Name = "Iris"};

        sut.Name.Should().NotBeNullOrEmpty("Name has been set");
    }

    [Fact]
    public void Given_Name_And_Age_Assigned_To_String_Should_Return_Correct_Format()
    {
        var sut = new Child() {Age = 10, Gender = Gender.X, Name = "Iris"};

        sut.ToString().Should().StartWith("IRIS").And.NotStartWith("10").And.
            Contain("-", Exactly.Once()).And.EndWith("10");
    }
    
    [Fact]
    public void Given_Name_And_Age_Assigned_To_String_Should_Return_Correct_Format_Through_RegEx()
    {
        var sut = new Child() {Age = 10, Gender = Gender.X, Name = "Iris"};

        sut.ToString().Should().MatchRegex("[I].* - 10");
    }
    
    [Fact]
    public void Given_Gender_Assigned_Should_Return_Correct_Enum()
    {
        var sut = new Child() {Age = 10, Gender = Gender.X, Name = "Iris"};

        sut.Gender.Should().Be(Gender.X);
    }
    

    
}