using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator powerupAnim;
    void Start()
    {
        powerupAnim = GetComponent<Animator>();  
        powerupAnim.SetBool("isSpinning", true); 
        
    }

}
