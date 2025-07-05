
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    // reference to rigidbody
    private Rigidbody rocketRigidbody;

    // rocket launch force
    private float rocketLaunchForce;

    // maximum ceiling height;
    private float maximumCeilingHeight = 10000f;

    // reference to rocket camera
    public GameObject rocketCamera;

    // reference to astronaut camera
    public GameObject astronautCamera;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to rigidbody
        rocketRigidbody = GetComponent<Rigidbody>();

        // prevent rocket from automatic launch
        rocketRigidbody.isKinematic = true;

        // de-activate the rocket camera
        rocketCamera.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // when the player touches the rocket
        // launch the rocket
        rocketRigidbody.AddForce(Vector3.up * rocketLaunchForce);

        // if the rocket has reached maximum ceiling height
        if (transform.position.y > maximumCeilingHeight)
        {
            // we have entered space
            // so load the space scene
            SceneManager.LoadScene(1);
        }
    }


    private void OnTriggerEnter(Collider collidingObject)
    {
        // if the player touches the rocket
        if (collidingObject.CompareTag("Player"))
        {
            // de-activate the astronaut camera
            astronautCamera.SetActive(false);

            // activate the rocket camera
            rocketCamera.SetActive(true);
            
            // launch the rocket
            rocketRigidbody.isKinematic = false;

            // set the launch force
            rocketLaunchForce = 5f;
        }
    }


} // end of class
