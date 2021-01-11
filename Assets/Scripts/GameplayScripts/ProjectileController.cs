using UnityEngine;

/// <summary>
/// Handles logic for Projectile objects.
/// </summary>
public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    
    /// <summary>
    /// Updates the projectile.
    /// Primarily updates the lifetime of the projectile, deciding when it should be destroyed.
    /// </summary>
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy();
        }
    }

    /// <summary>
    /// Destroys the projectile.
    /// </summary>
    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the projectile object's collision with enemy objects.
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy();
        }
    }
}
