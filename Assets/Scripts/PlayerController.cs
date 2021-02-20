using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool rotateInPlaceActive = false;
    public bool strafeActive = false;
    public float speed = 1;
    Rigidbody rb;
    public Rigidbody[] wheels = new Rigidbody[4];
    public enum DriveType { Front, Rear, Four }
    public DriveType driveType = DriveType.Front;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Mathf.Approximately(0f, Input.GetAxis("Vertical")))
            switch (driveType)
            {
                case DriveType.Front:
                    wheels[0].AddRelativeTorque(new Vector3(speed * Input.GetAxis("Vertical"), 0, 0));
                    wheels[1].AddRelativeTorque(new Vector3(speed * Input.GetAxis("Vertical"), 0, 0));
                    break;
                case DriveType.Rear:
                    break;
                case DriveType.Four:
                    break;
            }
        rb.AddRelativeForce(new Vector3(0,Input.GetAxis("Vertical"),0), ForceMode.Acceleration);
    }
}
