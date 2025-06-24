namespace task04;

public class Cruiser : ISpaceship
{
    public int Speed { get; } = 50;
    public int FirePower { get; } = 100;
    public int Position { get; private set; } = 0;
    public int Angle { get; private set; } = 0;
    public int RotateSpeed { get; } = 50;
    public int BulletCount { get; private set; } = 500;

    public void MoveForward()
    {
        Position += Speed * 2;
    }

    public void Rotate(int angle)
    {
        Angle = (Angle + angle * RotateSpeed * 2) % 360;
    }

    public void Fire()
    {
        if (BulletCount >= 3)
        {
            BulletCount -= 3;
        }
    }
}
