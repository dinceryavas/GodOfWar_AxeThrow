using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    public Transform AxeTransform;
    public static bool axeThrow,axeCall;
    Animator anim;
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
        anim = GetComponent<Animator>();

        axeThrow = false;
        axeCall = false;
    }
    public void Axe_Throw()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Preparing", false);
        axeThrow = true;
        AxeTransform.SetParent(null);
        Rigidbody rb = AxeTransform.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward*40f,ForceMode.Impulse);
    }
    public void Axe_Call()
    {
        axeCall = true;
        Axe.instance.ReturnAxe();
    }
    public void Axe_Called()
    {
        anim.SetTrigger("Called");
    }
}
