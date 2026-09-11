using UnityEngine;

//DragonMove Class and Functions
public class DragonMove : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{
    public float speed = 5;

    public bool goingUp = true;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);

        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }
       if(transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
