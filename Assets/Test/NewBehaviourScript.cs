using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D PlayerPhysics;

    public bool isgrounded = false;

    public float movespeed;
    public float jumpheight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            Player.transform.position = new Vector2(Player.transform.position.x + movespeed, Player.transform.position.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.position = new Vector2(Player.transform.position.x - movespeed, Player.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && isgrounded == true)
        {
            PlayerPhysics.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);
        }
    }
}
