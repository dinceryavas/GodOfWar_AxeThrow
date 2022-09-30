using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public static bool isHit;
    void Start()
    {
        isHit = false;
    }

    void Update()
    {
        if(PlayerAnimation.axeThrow && isHit == false)
        {
            transform.Rotate(new Vector3(0,0,-10));
        }
        if(PlayerAnimation.axeCall)
        {
            transform.Rotate(new Vector3(0, 0, -10));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Unbreakable")
        {
            isHit = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
