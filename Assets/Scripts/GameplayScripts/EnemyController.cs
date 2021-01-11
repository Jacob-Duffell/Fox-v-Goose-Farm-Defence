using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Enemy objects.
/// </summary>
public class EnemyController : MonoBehaviour
{
    private AudioSource gooseScream;
    private GameObject healthCanvas;
    private GameObject player;
    private Image healthBar;
    private Vector3 targetPosition;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;

    /// <summary>
    /// Initialises variables for the enemy object.
    /// </summary>
    void Start()
    {
        healthCanvas = transform.GetChild(1).gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
        targetPosition = player.transform.position;
        currentHealth = maxHealth;
        healthBar = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();

        gooseScream = Camera.main.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Updates the position of the enemy UI, handles the movement of the enemy object, and handles logic for the enemy's death.
    /// </summary>
    void Update()
    {
        healthCanvas.transform.LookAt(healthCanvas.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);

        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, 0f, transform.position.z), targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition, Vector3.up);

        if (currentHealth <= 0)
        {
            gooseScream.Play();

            GameHandler.CurrentWeekKills++;

            Destroy();
        }
    }

    /// <summary>
    /// Destroys the enemy object.
    /// </summary>
    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles collision with the player object or projectile object.
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy();
        }

        if (col.tag == "Projectile")
        {
            gooseScream.Play();

            currentHealth -= 1;
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
