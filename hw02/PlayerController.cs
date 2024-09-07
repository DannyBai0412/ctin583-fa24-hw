// TODO: Problem 1: Write in the comments what each line of code is doing.

// What is "using" and what is System.Collections? Please provide comments on what the next three lines mean. 
// The using directive includes namespaces in the code, helping to organize classes and other types while avoiding naming conflicts.
// The System.Collections namespace contains interfaces and classes for managing various object collections, like lists, queues, arrays, and dictionaries.
using System.Collections; // this grants access to collection-related classes from the System.Collections namespace.
using System.Collections.Generic; //this provides generic versions of collection types, allowing for type safety and flexibility.
using UnityEngine; //this is a core namespace in Unity that contains the fundamental classes for Unity development.

public class PlayerController : MonoBehaviour
{
    /* 
    TODO: Problem 2: We are trying to move our player in an open world game. We would like the player to be able to move
    foward, backward, left, and right. In addition, the player should be able to jump and adapt to the world's gravity.
    First, we will need to define some variables in order to control our player with the WASD keys and the Space bar for it to jump. 
    Please define the following private variables and print them out to Unity's console: 
                1. Player or Character's Name
                2. Movement Speed as a float
                3. Gravity Value as a float
                4. Jump Speed as a float
    */

    private string playerName = "JC"; // Player Name
    private float movementSpeed = 5.5; // Movement Speed
    private float gravityValue = 9.8; //Gravity Value
    private float jumpSpeed = 3.5; //Jump Speed

    /*
    When the game starts, we would like to find our character. In our Unity Editor, we have a 3D model of our player and the player is 
    represented as a component in Unity. How do we grab our player controller in code and where should we write this line of code in this
    C# document (PlayerController.cs)?
    */
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        // Print the variables to the Unity console when the game starts.
        Debug.Log("Player Name: " + playerName);
        Debug.Log("Movement Speed: " + movementSpeed);
        Debug.Log("Gravity Value: " + gravityValue);
        Debug.Log("Jump Speed: " + jumpSpeed);

        player = this.GetComponent<PlayerController>();
        // TODO: Problem 3: Describe when you would put code in the Start() function instead of the Update() function. 
        // What is the difference between Start() and Update()?
        /*
        Use the Start() function to initialize variables, set up references, and configure the initial game state. It is called once when the script is first executed
        On the other Hand, use the Update() function for code that needs to run continuously, frame by frame, such as checking for player input or updating the player's position.
        */
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Problem 4: What is an if statement? Write a couple of if statements to move the player with the WASD keys. 
        // We want to transform the player's position along the vertical and horizontal axis then multiply it by 
        // the corresponding variables we defined earlier. Lastly, we will need to multiply it all by Time.DeltaTime

        // Check if the player is pressing the W key for forward movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Check if the player is pressing the S key for backward movement
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

        // Check if the player is pressing the A key for left movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        // Check if the player is pressing the D key for right movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }


    }

    // TODO: Problem 5: What do the lines here do? Please provide inline comments and describe what each line is doing

    [Header("General Setup Settings")] // Adds a section header in the Unity Inspector for better organization
    [SerializeField] private InputAction movement; // Allows private 'movement' InputAction to be modified in the Unity Inspector
    [Tooltip("How fast player moves up and down based upon player input")][SerializeField] float controlSpeed = 30f; // Displays a tooltip in the Inspector and control speed of movement along the vertical axis
    [Tooltip("How far player moves horizontally")][SerializeField] float xRange = 10f; // Tooltip describing the xRange variable and SerializeField maximum horizontal movement range
    [Tooltip("How far player moves vertically")][SerializeField] float yRange = 10f;  // Tooltip describing the yRange variable and SerializeField maximum vertical movement range

    // What do Header, SerializeField, and Tooltip mean?
    //Header will add a custom label on a varaible to make it more organized and readble.
    //SeriaField will make private variables visible and editable.
    //Tooltip will add a hover-over message in a inspector to describe the purpose.

    // TODO: Problem 6: What are Unity's OnEnable() and OnDisable functions?
    // What do movement.Enable() and movement.OnDisable do?

    // OnEnable() called when the script or game object is enabled. Commonly used to initialize or reset state and to enable inputs or actions.
    // On the other hand, OnDisable called when it is disabled. Often used to clean up, save state, or disable inputs/actions to prevent errors or unwanted behavior.

    private void OnEnable()
    {
        movement.Enable(); // Enables the movement InputAction when the script or game object is enabled

    }

    private void OnDisable()
    {
        movement.Disable(); // Disables the movement InputAction when the script or game object is disabled
    }
}