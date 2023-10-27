
public class Spike : Collidable
{
    protected override void OnCollide()
    {
        GameManager.Instance.RestartGame();
    }
}
