using UnityEngine; //Using Unity's Programming tools

//PlayerMovement Class and Functions
public class PlayerMovement : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{
    public float speed = 4;
    
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
        // if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Translate(-transform.right * speed * Time.deltaTime);
        // }

        // // Traveling right
        // if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Translate(transform.right * speed * Time.deltaTime);
        // }

        // Construct Movement
        transform.position = new Vector3((transform.position.x), 
                Mathf.Clamp(transform.position.y, -4f, 4f),
                transform.position.z);
    
    }
}
