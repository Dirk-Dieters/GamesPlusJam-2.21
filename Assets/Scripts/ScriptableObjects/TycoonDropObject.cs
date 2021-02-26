using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tycoon Drop", menuName = "ScriptableObjects/Tycoon/TycoonDrop")]
public class TycoonDropObject : ScriptableObject
{
	#region SerializeFields
	[SerializeField] private string dropObjectName;
	[SerializeField] private string dropObjectDescription;
	[SerializeField] private float dropObjectValue;
	#endregion

	#region Properties
	public string DropObjectName { get { return dropObjectName; } }
	public string DropObjectDescription { get { return dropObjectDescription; } }
	public float DropObjectValue { get { return dropObjectValue; } }
	#endregion
}
