using task04;

namespace task04tests;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
        Assert.Equal(0, cruiser.Position);
        Assert.Equal(0, cruiser.Angle);
        Assert.Equal(50, cruiser.RotateSpeed);
        Assert.Equal(500, cruiser.BulletCount);
    }
    
    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        ISpaceship fighter = new Fighter();
        Assert.Equal(100, fighter.Speed);
        Assert.Equal(20, fighter.FirePower);
        Assert.Equal(0, fighter.Position);
        Assert.Equal(0, fighter.Angle);
        Assert.Equal(100, fighter.RotateSpeed);
        Assert.Equal(2000, fighter.BulletCount);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }
    
    [Fact]
    public void Cruiser_ShouldBeMorePowerfulThanFighter()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();
        Assert.True(fighter.FirePower < cruiser.FirePower);
    }
    
    [Fact]
    public void Fighter_ShouldBeMovingFasterThanCruiser()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();
        fighter.MoveForward();
        cruiser.MoveForward();
        Assert.True(fighter.Position > cruiser.Position);
    }
    
    [Fact]
    public void Fighter_ShouldBeRotateFasterThanCruiser()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();
        fighter.Rotate(10);
        cruiser.Rotate(10);
        Assert.True(fighter.Angle > cruiser.Angle);
    }
    
    [Fact]
    public void Cruiser_ShouldBeShootsMorePowerfulThanFighter()
    {
        ISpaceship fighter = new Fighter();
        ISpaceship cruiser = new Cruiser();
        fighter.Fire();
        cruiser.Fire();
        Assert.True((500 - cruiser.BulletCount) * cruiser.FirePower > 
                    (2000 - fighter.BulletCount) * fighter.FirePower);
    }
}
