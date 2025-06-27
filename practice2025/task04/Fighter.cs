namespace task04;

public class Fighter : ISpaceship
{
    public int Speed { get; } = 100;
    public int FirePower { get; } = 20;
    public int Position { get; private set; } = 0;
    public int Angle { get; private set; } = 0;
    public int RotateSpeed { get; } = 100;
    public int BulletCount { get; private set; } = 2000;

    public void MoveForward()
    {
        Position += Speed * 5;
    }

    public void Rotate(int angle)
    {
        Angle = (Angle + angle * RotateSpeed * 5) % 360;
    }

    public void Fire()
    {
        if (BulletCount > 0)
        {
            BulletCount -= 1;
        }
    }
}
