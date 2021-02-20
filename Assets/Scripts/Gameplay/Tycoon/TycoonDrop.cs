using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TycoonDrop : MonoBehaviour
{
	#region Components
	private Rigidbody rb;
	#endregion

	#region MonoBehaviour
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
	#endregion

	#region Public Methods
	public void Collect()
	{
		gameObject.SetActive(false);
	}
	#endregion
}
