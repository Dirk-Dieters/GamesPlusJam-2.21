using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
	#region Serialize Fields
	[SerializeField] private float conveyorSpeed;
	#endregion

	#region Components
	private Rigidbody rb;
	#endregion

	#region MonoBehaviour
	// Start is called before the first frame update
	private void Start()
	{
		rb = GetComponent<Rigidbody>();

		if (rb == null)
		{
			Debug.LogErrorFormat(gameObject, "{0} - Somehow this game object does not have a rigidbody component!", gameObject.name);
		}
	}

	// FixedUpdate is called a set amount of times per second, best for physics updates
	private void FixedUpdate()
	{
		if (rb != null)
		{
			Vector3 pos = rb.position;
			rb.position += -transform.forward * conveyorSpeed * Time.fixedDeltaTime;
			rb.MovePosition(pos);
		}
	}
	#endregion
}
