using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private bool kill;
    [SerializeField] private bool revive;
    [SerializeField] private float killforce = 5f;

    [SerializeField] private Rigidbody[] RBs;
    [SerializeField] private Collider[] colls;
    [SerializeField] private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        RBs = GetComponentsInChildren<Rigidbody>();
        colls = GetComponentsInChildren<Collider>();
        Revive();
    }

    private void Kill()
    {
        kill = false;
        SetRegdoll(true);
        SetMain(false);
    }
    private void Revive()
    {
        revive = false;
        SetRegdoll(false);
        SetMain(true);
    }

    void SetMain(bool active)
    {
        anim.enabled = active;
        RBs[0].isKinematic = !active;
        colls[0].enabled = active;
    }

    void SetRegdoll(bool active)
    {
        for (int i = 0; i < RBs.Length; i++)
        {
            RBs[i].isKinematic = !active;
        }
        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = active;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Kill();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Revive();
        }
    }
}
