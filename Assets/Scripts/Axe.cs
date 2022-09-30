using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform returnPos, curvePos;
    float time = 0;
    Vector3 oldPos;
    public static bool isHit;
    Rigidbody rb;
    #region Singleton
    public static Axe instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            if (time < 1f)
            {
                rb.position = getBQCPoint(time, oldPos, curvePos.position, returnPos.position);
                time += Time.deltaTime;
            }
            else
            {
                ResetAxe();
            }
        }

    }
    public void ReturnAxe()
    {
        rb.isKinematic = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        oldPos = transform.position;
        PlayerAnimation.axeCall = true;
        rb.velocity = Vector3.zero;
         
    }
    public void ResetAxe()
    {
        isHit = false;
        transform.GetComponent<BoxCollider>().enabled = true;
        transform.parent = returnPos.parent;
        transform.position = returnPos.position;
        transform.rotation = returnPos.rotation;
        rb.isKinematic = true;
        time = 0f;
        PlayerAnimation.axeThrow = false;
        PlayerAnimation.instance.Axe_Called();
        PlayerAnimation.axeCall = false;
        PlayerMovement.axeThrowed = false;
    }
    Vector3 getBQCPoint(float t, Vector3 p0,Vector3 p1,Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Unbreakable")
        {
            isHit = true;
            rb.isKinematic = true;
        }
    }
}
