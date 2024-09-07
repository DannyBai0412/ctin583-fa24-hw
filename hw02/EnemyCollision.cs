using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // TODO: Problem 7: Why did I not include the words public or private here?
    // What does it mean when I only write void (Movement)? What does void mean?

    //The reason you did not include the words public or private here is that the method defaults to private if you did not specify it.
    //If you only write void(Movement), you will get no return value. Void means the method does not return any value. 
    void Movement()
    {
        // TODO: Problem 8: Please explain what the next 4 lines mean.

        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //This function reads player input from the vertical axis, and ensures the player’s forward/backward movement is smooth and frame-rate independent.
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //Similar to the vertical axis, this reads the horizontal input, and makes the turning speed consistent across frames.

        transform.Translate(Vector3.forward * forwardMovement);
        //This moves the object forward by a certain amount.
        transform.Rotate(Vector3.up * turnMovement);
        //This rotates the object around the Y-axis (which is vertical in 3D space), based on the horizontal input.

        // What is Input.GetAxis, transform.Translate, and transform.Rotate? 
        //Input.GetAxis reads player input for movement.
        //transform.Translate moves the object forward or backward.
        //transform.Rotate rotates the object left or right.
    }


    void Shoot()
    {
        // TODO: Problem 9: Looking at this code, is this code using Unity's Old or New 
        // Input System? Please describe what Instantiate is doing in this if statement.

        //The code is using Unity's Old Input System because it uses Input.GetButtonDown("Fire1"), which is part of the old input system API. The new Input System uses InputAction for handling input.
        //Instantiate is creating a copy (or "instance") of the bulletPrefab at the position and rotation defined by firePosition.

        if (Input.GetButtonDown("Fire1") && myStuff.bullets > 0)
        {
            Rigidbody bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
            bulletInstance.AddForce(firePosition.forward * bulletSpeed);
            myStuff.bullets--;
        }
    }

    /* TODO: Problem 10: In our game, we want our enemy to alternate weapons every couple of frames.
    However, also would like our enemy to lose access to their weapons when they are frozen/disabled.
    First, let's define a public class named Weapon. In the class, define 3 int variables for arrow, sword, and rocket.
    

    Outside of our Weapon class, we would want to define an IEnumerator function. 
    Then in our class, write a for loop that loops between the arrow, sword, and rocket. 
    Use the WaitForSeconds function to tell it to switch weapons every 5 seconds. 

    Remember to call your Coroutine.
    */
}
public class Weapon
{
    public int arrow;
    public int sword;
    public int rocket;
}

IEumerator swtichWeapons()
{
    Weapon enemyWeapon = new Weapon();
    while (true)
    {
        enemyWeapon.arrow = 1;
        yield return new WaitForSeconds(5);

        enemyWeapon.sword = 1;
        enemyWeapon.arrow = 0;
        yield return new WaitForSeconds(5);

        enemyWeapon.rocket = 1;
        enemyWeapon.sword = 0;
        yield return new WaitForSeconds(5);

        enemyWeapon.rocket = 0;
    }

}

void Start()
{
    StartCoroutine(swtichWeapons());
}