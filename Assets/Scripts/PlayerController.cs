using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private GameObject focalPoint;
    [SerializeField]private float speed = 10f;
    [SerializeField]private float gravityModifier = 1f;

    private bool hasPowerup = false;
    public GameObject powerupIndicator;
    private float powerupStrength = 15.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");     

        Physics.gravity *= gravityModifier;
        powerupIndicator.SetActive(false);  

        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the vertical input (W/S or Up/Down arrow keys)
        float forwardInput = Input.GetAxis("Vertical");
        Vector3 forward = focalPoint.transform.forward;
        forward.y = 0; 
        forward.Normalize();

        rb.AddForce(forward * forwardInput * speed);

        if (transform.position.y < -5)
        {
            Debug.Log("Game Over!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

}
