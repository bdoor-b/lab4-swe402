using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    [SerializeField]private float speed = 200f;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }
}
