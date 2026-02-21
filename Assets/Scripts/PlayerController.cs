using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody rb;
    private GameObject focalPoint;
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float gravityModifier = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");     

        Physics.gravity *= gravityModifier;   
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the vertical input (W/S or Up/Down arrow keys)
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        if (transform.position.y < -5)
        {
            Debug.Log("Game Over!");
        }
    }
}
