using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public Vector2 JumpForce;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) 
        {
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }
}
