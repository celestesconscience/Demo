using UnityEngine; //Using Unity's Programming tools

//PlayerMovement Class and Functions
public class PlayerMovement : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{
    public float speed = 4;
    public int score = 0;
    
    // Update is called once per frame
    void Update()
    {
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

        // // Traveling left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        // // Traveling right
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        // Construct Movement
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -8f, -4f), // <-- Stop left and right
                Mathf.Clamp(transform.position.y, -4f, 4f), // <-- Stop up and down
                transform.position.z
                );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            if (collision.gameObject.GetComponent<ProjectileMove>() != null)
            {
                score += collision.gameObject.GetComponent<ProjectileMove>().points;
                print(score);
            }
        }

        Destroy(collision.gameObject);
    }
}
