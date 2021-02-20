using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
	#region SerializeFields
	[Header("Objects")]
	[SerializeField] private GameObject prefabToPool;

	[Header("Pool Properties")]
	[SerializeField] private int amountToPool;
	[SerializeField] private bool shouldExpand;
	#endregion

	#region Properties
	public GameObject PrefabToPool { get { return prefabToPool; } }
	public int AmountToPool { get { return amountToPool; } }
	public bool ShouldExpand { get { return shouldExpand; } }
	#endregion
}

public class ObjectPooler : Singleton<ObjectPooler>
{
	#region SerializeFields
	[SerializeField] private List<ObjectPoolItem> itemsToPool;
	#endregion

	#region Private Variables
	private List<GameObject> pooledObjects;
	#endregion

	#region MonoBehaviour
	private void Start()
	{
		pooledObjects = new List<GameObject>();
		foreach (ObjectPoolItem item in itemsToPool)
		{
			if (item.PrefabToPool.tag == "Untagged")
			{
				Debug.LogErrorFormat(item.PrefabToPool,
					"{0} - This item to pool is untagged and will be irretrievable from the pool!",
					item.PrefabToPool.name);
			}

			GameObject parentObj = new GameObject();
			parentObj.name = string.Format("{0} Pool", item.PrefabToPool.name);

			for (int i = 0; i < item.AmountToPool; i++)
			{
				GameObject obj = Instantiate(item.PrefabToPool, parentObj.transform);
				obj.SetActive(false);
				pooledObjects.Add(obj);
			}
		}
	}
	#endregion

	#region Public Methods
	public GameObject GetObjectFromPool(string tag)
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (pooledObjects[i].tag == tag && !pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		foreach (ObjectPoolItem item in itemsToPool)
		{
			if (item.PrefabToPool.tag == tag && item.ShouldExpand == true)
			{
				GameObject parentObj = GameObject.Find(string.Format("{0} Pool", item.PrefabToPool.name));
				if (parentObj == null)
				{
					parentObj = new GameObject();
					parentObj.name = string.Format("{0} Pool", item.PrefabToPool.name);
				}

				GameObject obj = Instantiate(item.PrefabToPool, parentObj.transform);
				obj.SetActive(false);
				pooledObjects.Add(obj);
				return obj;
			}
		}
		return null;
	}
	#endregion
}
