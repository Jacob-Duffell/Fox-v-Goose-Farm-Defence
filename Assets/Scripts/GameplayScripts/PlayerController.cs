using SerializeStatic_NET;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Player object.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private AudioSource bowPull;
    private float currentDistance;
    private float safeDistance;
    private float shotPower;
    private GameObject arrow;
    private GameObject circle;
    private GameObject mousePointA;
    private GameObject mousePointB;
    private Vector3 shotDirection;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxDistance = 3.0f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Image healthBar;

    /// <summary>
    /// Initialises variables when the player is intantiated.
    /// </summary>
    void Start()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        circle = GameObject.FindGameObjectWithTag("Circle");

        currentHealth = maxHealth;

        bowPull = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Updates the player object.
    /// Primarily handles logic for the player's death.
    /// </summary>
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameHandler.TotalDeaths++;

            GameHandler.CurrentMoney = 0;
            GameHandler.CurrentWeekEarnings = 0;
            GameHandler.CurrentWeekKills = 0;
            GameHandler.CurrentWeekNumber = 1;
            GameHandler.CurrentWeekRewardClaimed = false;

            SerializeStatic.Save();

            Loader.Load(Loader.Scene.LoseScene);
        }
    }

    /// <summary>
    /// Plays the relevant audio when the player object is touched.
    /// </summary>
    private void OnMouseDown()
    {
        bowPull.Play();
    }

    /// <summary>
    /// When mouse is being dragged, make MousePointB mirror MousePointA.
    /// </summary>
    private void OnMouseDrag()
    {
        // Calculate distance between the player character and the player's touch position
        currentDistance = Vector3.Distance(mousePointA.transform.position, transform.position);

        // Cap the total distance dragged to the max distance
        if (currentDistance <= maxDistance)
        {
            safeDistance = currentDistance;
        }
        else
        {
            safeDistance = maxDistance;
        }

        ArrowAndCircleCalc();

        // Calculate power and direction
        shotPower = Mathf.Abs(safeDistance) * 13;

        mousePointB.transform.position = mousePointA.transform.position * -1;
        transform.LookAt(mousePointB.transform.position);

        shotDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);
    }

    /// <summary>
    /// Fire a projectile when the user lifts their finger from the player object.
    /// </summary>
    private void OnMouseUp()
    {
        arrow.GetComponent<Renderer>().enabled = false;
        circle.GetComponent<Renderer>().enabled = false;

        Vector3 push = shotDirection * shotPower * -1;

        GameObject currentProjectile = Instantiate(projectile);

        currentProjectile.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        currentProjectile.transform.rotation = transform.rotation;
        currentProjectile.GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);

        mousePointB.transform.position = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Make the player lose health when an enemy collides with it.
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            currentHealth -= 1;
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    /// <summary>
    /// Calculates the position, rotation and scale of the arrow and circle objects when the mouse is being dragged.
    /// </summary>
    private void ArrowAndCircleCalc()
    {
        arrow.GetComponent<Renderer>().enabled = true;
        circle.GetComponent<Renderer>().enabled = true;

        // Calculate position
        if (currentDistance <= maxDistance)
        {
            arrow.transform.position = new Vector3((2 * transform.position.x) - mousePointA.transform.position.x, 1.5f, (2 * transform.position.z) - mousePointA.transform.position.z);
        }
        else
        {
            Vector3 dimXZ = mousePointA.transform.position - transform.position;
            float difference = dimXZ.magnitude;
            arrow.transform.position = transform.position + ((dimXZ / difference) * maxDistance * -1);
            arrow.transform.position = new Vector3(arrow.transform.position.x, 1.5f, arrow.transform.position.z);
        }

        circle.transform.position = transform.position + new Vector3(0, 0.05f, 0);
        arrow.transform.rotation = transform.rotation;

        float arrowScaleX = Mathf.Log(1 + safeDistance / 2, 2) * 2f;
        float arrowScaleZ = Mathf.Log(1 + safeDistance / 2, 2) * 2f;

        float circleScaleX = Mathf.Log(1 + safeDistance / 2, 2) * 5f;
        float circleScaleZ = Mathf.Log(1 + safeDistance / 2, 2) * 5f;

        arrow.transform.localScale = new Vector3((1 + arrowScaleX) / 2, 0.001f, (1 + arrowScaleZ) / 2);
        circle.transform.localScale = new Vector3(1 + circleScaleX, 0.001f, 1 + circleScaleZ);
    }
}
