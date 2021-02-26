using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TycoonDrop : MonoBehaviour
{
	#region SerializeFields
	[SerializeField] private TycoonDropObject tycoonDropObject;
	#endregion

	#region Components
	private Rigidbody rb;
	#endregion

	#region Private Variables
	private MoneyValueUpdate moneyValueUpdate;
	#endregion

	#region MonoBehaviour
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		moneyValueUpdate = FindObjectOfType<MoneyValueUpdate>();
	}

	private void OnEnable()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}
	#endregion

	#region Public Methods
	public void Collect()
	{
		if(tycoonDropObject)
		{
			PlayerData.AddMoney(tycoonDropObject.DropObjectValue);
		}

		if(!moneyValueUpdate)
		{
			moneyValueUpdate = FindObjectOfType<MoneyValueUpdate>();
		}

		if(moneyValueUpdate)
		{
			moneyValueUpdate.UpdateMoneyText();
		}

		gameObject.SetActive(false);
	}
	#endregion
}
