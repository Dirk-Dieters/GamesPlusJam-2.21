using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<string> labels;
    public List<int> Values;
    public Text text;
    public List<GameObject> watchtargets;

    // Start is called before the first frame update
    void Start()
    {
        Values.Add(watchtargets[0].GetComponent<RobotController>().HP);
        Values.Add(watchtargets[1].GetComponent<RobotController>().HP);
        Values.Add(watchtargets[2].GetComponent<PartController>().partHP);
    }
    
    // Update is called once per frame
    void Update()
    {
        Values[0] = (watchtargets[0].GetComponent<RobotController>().HP);
        Values[1] = (watchtargets[1].GetComponent<RobotController>().HP);
        Values[2] = (watchtargets[2].GetComponent<PartController>().partHP);

        text.text = "";
        for (int i = 0; i < labels.Count; i++)
        {
            text.text += labels[i] + ": " + Values[i].ToString() + "\n";
        }
    }
}
