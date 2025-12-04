using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    // Rotation speed in degrees per second
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    void Update()
    {
        // Rotate the prefab continuously
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
