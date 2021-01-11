using UnityEngine;

/// <summary>
/// Handles logic for the MousePointA object.
/// </summary>
public class MouseFollow : MonoBehaviour
{
    private Vector3 tempPos;

    [SerializeField] private float offsetZ;


    /// <summary>
    /// Initialises variables for MousePointA.
    /// </summary>
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    /// <summary>
    /// Calculates the position of MousePointA relative to where the user is touching the screen.
    /// </summary>
    void Update()
    {
        tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, offsetZ));
        transform.position = new Vector3(tempPos.x, 0f, tempPos.z);
    }
}
