using UnityEngine;
using TMPro;

public class MoneyValueUpdate : MonoBehaviour
{
	#region SerializeFields
	[SerializeField] private TMP_Text moneyValueText;
	#endregion

	#region Public Methods
	public void UpdateMoneyText()
	{
		moneyValueText.text = string.Format("{0:C}", PlayerData.Money);
	}
	#endregion
}
