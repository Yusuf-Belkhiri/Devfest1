
public class Door : Collidable
{
    protected override void OnCollide()
    {
        GameManager.Instance.GameWon();
    }
}
