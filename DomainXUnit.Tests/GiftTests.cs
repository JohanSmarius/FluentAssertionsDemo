using Domain;
using FluentAssertions;

namespace DomainXUnit.Tests;

public class GiftTests
{
    [Fact]
    public void GivenProductionDuration_ReadyAt_Is_Calculated_Correctly()
    {
        var productionDuration = 2;
        
        var sut = new Gift(productionDuration);
        var giftAvailableAt = sut.ReadyAt;

        giftAvailableAt.Should().BeExactly(TimeSpan.FromTicks(DateTime.Today.AddDays(productionDuration).Ticks));
    }
    
    [Fact]
    public void GivenProductionDuration_ReadyAt_Should_Be_After_Today()
    {
        var productionDuration = 2;
        
        var sut = new Gift(productionDuration);
        var giftAvailableAt = sut.ReadyAt;

        giftAvailableAt.Should().BeAfter(DateTime.Today);
    }
}