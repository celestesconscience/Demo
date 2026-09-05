using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    // Update is called once per frame
    void Update()
    {
        // Traveling up
        if(Input.GetKey(Keycode.W))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
    }
}
