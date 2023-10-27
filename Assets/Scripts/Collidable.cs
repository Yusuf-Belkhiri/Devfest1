using UnityEngine;

public abstract class Collidable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollide();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollide();
        }
    }
    
    protected abstract void OnCollide();
}
