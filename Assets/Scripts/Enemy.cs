using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    [SerializeField]private float speed = 3f;
    private GameObject player;
    private GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3  lookDirection = (player.transform.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            gm.UpdateScore(5);
            Destroy(gameObject);
        }
        
    }
}
