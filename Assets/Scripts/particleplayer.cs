using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleplayer : MonoBehaviour
{
    public ParticleSystem ps;

    public Vector3 target;

    [Header("Enable/Disable Particles")]
    public bool playanimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            if(playanimation == true)
            {
                ps.Play();
            }

        }
    }


}
