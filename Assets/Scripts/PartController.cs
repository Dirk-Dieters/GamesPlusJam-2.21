using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public bool destroyed = false;
    Transform attachment;
    public int partHP = 20;
    public int damageResist = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (partHP <= 0 && !destroyed)
            DestroyPart();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int damage = (int)(collision.relativeVelocity.magnitude - damageResist);
        if (damage > 0)
            partHP -= damage;
    }

    void DestroyPart()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        destroyed = true;
    }
}