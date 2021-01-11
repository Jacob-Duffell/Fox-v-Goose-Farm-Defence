using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Place Seeds menu in the Hub Menu scene.
/// </summary>
public class PlaceSeedsMenu : MonoBehaviour
{
	[Header("Lists of seed items")]
	[SerializeField] private SeedData[] seedItems;

	[Header("References")]
	[SerializeField] private Transform purchasedSeedContainer;
	[SerializeField] private GameObject farmGrid;
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private TMP_Text profitText;

	[NonSerialized]	public int totalProfit = 0;

	/// <summary>
	/// Initialise the UI for this menu.
	/// </summary>
	private void Start()
    {
		PopulatePurchasedSeedList();
    }

	/// <summary>
	/// Populates the seed list with all purchased seeds.
	/// </summary>
	private void PopulatePurchasedSeedList()
	{
		for (int i = 0; i < seedItems.Length; i++)
		{
			SeedData seedItem = seedItems[i];

			if (seedItem.Purchased)
			{
				GameObject seedObject = Instantiate(itemPrefab, purchasedSeedContainer);

				// Set the item's image
				seedObject.transform.GetChild(1).GetComponent<Image>().sprite = seedItem.Icon;

				// Pass through the Scriptable Object
				seedObject.GetComponent<PurchasedSeed>().seedData = seedItem;
			}
		}
	}

	/// <summary>
	/// Updates the total profit the user will earn if they survive the next in-game week.
	/// </summary>
	public void CalculateTotalProfit()
	{
		totalProfit = 0;

		for (int i = 0; i < farmGrid.transform.childCount; i++)
		{
			GameObject soilTile = farmGrid.transform.GetChild(i).gameObject;

			if (soilTile.tag == "Soil")
			{
				if (soilTile.GetComponent<Soil>().seedData != null)
				{
					totalProfit += soilTile.GetComponent<Soil>().seedData.SaleValue;
				}
			}
		}

		profitText.text = "Profit: £" + totalProfit;
	}

	/// <summary>
	/// Empties and repopulates the Purchased Seed list.
	/// </summary>
	public void ReloadPurchasedSeedList()
	{
		int purchasedSeedCount = purchasedSeedContainer.childCount;

		for (int i = 0; i < purchasedSeedCount; i++)
		{
			Destroy(purchasedSeedContainer.GetChild(i).gameObject);
		}

		PopulatePurchasedSeedList();
	}
}
