using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	#region Private Variables
	private static T instance;
	private static bool gameEnding = false;
	#endregion

	#region Properties
	public static T Instance
	{
		get
		{
			// if game is ending, print warning message and do not try to access singleton instance
			if (gameEnding)
			{
				Debug.LogWarning("The game is ending and this singleton should not be accessed - " + typeof(T).ToString());
				return null;
			}

			// if no instance found, search for one. If more than one instance exists, print a warning to the console
			if (!instance)
			{
				instance = (T)FindObjectOfType(typeof(T));
				if (FindObjectsOfType(typeof(T)).Length > 1)
				{
					Debug.LogError("There should not be more than one instance of this singleton! - " + typeof(T).ToString() + " Reloading the scene might help.");
				}

				if (instance.gameObject)
				{
					DontDestroyOnLoad(Instance.gameObject);
				}
			}

			// if still no instance found, create a new game object, name it, and add singleton component
			if (!instance)
			{
				GameObject singleton = new GameObject();
				singleton.name = "[SNGLTN] " + typeof(T).ToString();
				DontDestroyOnLoad(singleton);
				instance = singleton.AddComponent<T>();
				Debug.Log("Singleton instance of " + typeof(T).ToString() + " created.");
			}

			return instance;
		}
	}
	#endregion

	#region MonoBehaviour
	// when instance is destroyed the game is ending and nothing should be able to access the instance
	private void OnDestroy()
	{
		gameEnding = true;
	}
	#endregion
}
