using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    public Transform Axe;
    public static bool axeThrow,axeCall;

    #region Singleton
    public static PlayerAnimation instance = null;
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
        axeThrow = false;
        axeCall = false;
    }
    public void Axe_Throw()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Preparing", false);
        axeThrow = true;
        Axe.SetParent(null);
        Rigidbody rb = Axe.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward*40f,ForceMode.Impulse);
    }
    public void Axe_Call()
    {
        axeCall = true;
    }
    public void Axe_Called()
    {

    }
}
