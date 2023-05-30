using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float followSpeed = 5f;  // Adjust the follow speed as needed

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the object to the player
            Vector3 direction = player.position - transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Move the object towards the player
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}