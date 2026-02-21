using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    [SerializeField]private float speed = 5.0f;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
        
    }
}
