using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
	#region Private Variables
	private static float money;
	#endregion

	#region Properties
	public static float Money { get { return money; } }
	#endregion

	#region Public Methods
	public static void SetMoney(float value)
	{
		money = value;
	}

	public static void AddMoney(float value)
	{
		money += value;
	}
	#endregion
}
