using UnityEngine;

//DragonMove Class and Functions
public class DragonMove : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject. 
                                       // class acts as a container for the code that will control the dragon's movement and behavior
{
    public float speed = 5; // <-- Speed of the dragon's movement
    public bool goingUp = true; // <-- Direction of the dragon's movement

    private float ratTimer = 0; // <-- Timer for spawning rats
    private float fireballTimer = 0; // <-- Timer for spawning fireballs

    private float ratWaitTime = 3; // <-- Time interval for spawning rats
    private float fireballWaitTime = 5; // <-- Time interval for spawning fireballs

    public GameObject ratPrefab; // <-- Prefab for the rat GameObject
    public GameObject fireballPrefab; // <-- Prefab for the fireball GameObject

    // Update is called once per frame
    void Update()
    {

        //Spawning Rat & Fireball
        ratTimer += Time.deltaTime; // <-- Increment the rat timer by the time elapsed since the last frame
        fireballTimer += Time.deltaTime; // <-- Increment the fireball timer by the time elapsed since the last frame

        if(ratTimer > ratWaitTime) // <-- Check if the rat timer has exceeded the wait time, if it has, spawn a new rat and reset the timer and wait time
        {
            Instantiate(ratPrefab, transform.position, Quaternion.identity); // <-- Create a new instance of the ratPrefab at the dragon's position with no rotation
            ratTimer = 0; // <-- Reset the rat timer to 0
            ratWaitTime = Random.Range(1f, 2f); // <-- Set the next rat spawn time to a random value between 1 and 2 seconds
        }

        if(fireballTimer > fireballWaitTime) // Same as above but for fireball
        {
            Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWaitTime = Random.Range(1f, 3f);
        }

        // Traveling up
        transform.Translate(transform.up * speed * Time.deltaTime);

        // Stop from going off screen Up
        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }

        // Stop from going off screen Down
       if(transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
