using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public DriftCamera cam;
    public WheelDrive drive;
    public EasySuspension sus;
    public Vector3 startPoint = new Vector3(25, .25f, 25);

    public int HP = 100;
    public int damageResist = 0;
    public int maxSteer = 30;
    public int maxTorque = 900;
    public int brakeTorque = 30000;
    public DriveType driveType = DriveType.RearWheelDrive;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<DriftCamera>();
        drive = gameObject.GetComponent<WheelDrive>();
        sus = gameObject.GetComponent<EasySuspension>();

        if (gameObject.tag != "Player")
        {
            Destroy(GetComponent<WheelDrive>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        int damage = (int)(collision.relativeVelocity.magnitude - damageResist);
        if (damage > 0)
            HP -= damage;
    }

    void Die()
    {
        Debug.Log("Dead");
        HP = 100;
        transform.position = startPoint;
    }
}
