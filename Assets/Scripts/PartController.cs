using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public bool destroyed = false;
    Transform attachment;

    // Start is called before the first frame update
    void Start()
    {
        attachment = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyed)
        {
            transform.position = attachment.position;
            transform.rotation = attachment.rotation;
        }
    }
}