using UnityEngine; //Using Unity's Programming tools
using TMPro; //Pulling from TextMesh Pro library

//PlayerMovement Class and Functions
public class PlayerMovement : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{
    public float speed = 4; // <-- Speed of the player's movement
    public int scoreVal = 0; // <-- Player's score
    public TextMeshProUGUI scoreBox; // <-- Reference to the score display UI element

    // Bat Spit Projectile
    public GameObject batspitPrefab; // <-- Reference to the batspit GameObject prefab
    private float batspitCooldown = 1.5f; // <-- Timer for controlling the rate of fire for the bat spit projectile, 
                                         // starts at 1.5 second so the player can'tfire immediately at the start of the game

    // Update is called once per frame
    void Update()
    {
        // Update the batspit cooldown timer
        if(batspitCooldown > 0)
        {
            batspitCooldown -= Time.deltaTime;
        }

        // Attack Projectile
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) && batspitCooldown <= 0) // <-- Check if the player has pressed the spacebar or E key and if the cooldown timer has expired
        {
            //Spawning Bat Spit Projectile
            Instantiate(batspitPrefab, transform.position, Quaternion.identity); // <-- Create a new instance of the batspitPrefab at the 
                                                                                // player's position with no rotation
            batspitCooldown = 1.5f; // <-- Set the cooldown timer
        }

        // Traveling up
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        // Traveling down
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }

        // Traveling left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        // Traveling right
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        // Constrict Movement
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -8f, -4f), // <-- Stop left and right
                Mathf.Clamp(transform.position.y, -4f, 4f), // <-- Stop up and down
                transform.position.z // <-- Keep the z position the same
                );
    }

    private void OnTriggerEnter2D(Collider2D collision) // <-- Function that is called when the player collides with another object
    {
        if(collision.gameObject.CompareTag("Projectile")) // <-- Check if the collided object has the tag "Projectile"
        {      
            if(collision.gameObject.GetComponent<ProjectileMove>() != null) // <-- Check if the collided object has a ProjectileMove component
            {
                scoreVal += collision.gameObject.GetComponent<ProjectileMove>().points; // <-- Add the points from the projectile to the player's score
                scoreBox.text = "Score: " + scoreVal; // <-- Update the score display with the new score
                print(scoreVal); // <-- Print the new score to the console for debugging purposes
                
                Destroy(collision.gameObject); // <-- Destroy the collided object (the projectile) after it has been processed
            }
        }
    }
}
