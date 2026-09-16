using UnityEngine;

//DragonMove Class and Functions
public class DragonMove : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{
    public float speed = 5;
    public bool goingUp = true;

    private float ratTimer = 0;
    private float fireballTimer = 0;

    private float ratWaitTime = 3;
    private float fireballWaitTime = 5;

    public GameObject ratPrefab;
    public GameObject fireballPrefab;

    // Update is called once per frame
    void Update()
    {

        //Spawning Rat & Fireball
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;

        if(ratTimer > ratWaitTime)
        {
            Instantiate(ratPrefab, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWaitTime = Random.Range(1f, 2f);;
        }

        if(fireballTimer > fireballWaitTime)
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
