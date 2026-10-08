using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    void Start()
    {
        
    }

    void Update()
    {
        // If an object goes past top
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // object goes past bottom
        else if (transform.position.z < lowerBound)
        {
            // make gam over message
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
