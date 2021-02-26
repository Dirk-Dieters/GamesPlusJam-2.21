using System.Collections;
using UnityEngine;

public class TycoonDropper : MonoBehaviour
{
	#region SerializeFields
	[SerializeField] private float dropTime;
	[SerializeField] private GameObject prefabToDrop;
	[SerializeField] private Transform dropPosition;
	#endregion

	#region MonoBehaviour
	private void Start()
	{
		StartCoroutine(DropTycoonItem());
	}
	#endregion

	#region Coroutines
	private IEnumerator DropTycoonItem()
	{
		while (true)
		{
			yield return new WaitForSeconds(dropTime);
			GameObject drop = ObjectPooler.Instance.GetObjectFromPool(prefabToDrop.tag);
			drop.transform.position = dropPosition.position;
			drop.SetActive(true);
		}
	}
	#endregion
}
