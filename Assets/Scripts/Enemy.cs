using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    [SerializeField]private float speed = 200f;
    private GameObject player;
    Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        direction = (player.transform.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }
}
