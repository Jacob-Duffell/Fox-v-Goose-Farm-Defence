using UnityEngine;

/// <summary>
/// Handles logic for the camera in the gameplay scene of the game.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// Updates the camera position relative to the position of MousePointB.
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}