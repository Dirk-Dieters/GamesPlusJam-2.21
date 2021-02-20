using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float lerpt = 0;
    public float cameraDistance = 1;
    public float cameraMoveSpeed = 0.1f;
    public float cameraHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(transform.position, player.transform.position) > cameraDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, cameraMoveSpeed * Time.deltaTime);
        }
        if (!Mathf.Approximately(cameraHeight, transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
        }
    }
}
