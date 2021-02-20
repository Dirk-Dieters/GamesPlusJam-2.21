using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TycoonCollector : MonoBehaviour
{
	#region MonoBehaviour
	private void OnTriggerEnter(Collider other)
	{
		TycoonDrop dropObject = other.GetComponent<TycoonDrop>();
		if (dropObject != null)
		{
			dropObject.Collect();
		}
	}
	#endregion
}
