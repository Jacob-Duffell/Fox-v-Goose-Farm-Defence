using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Soil objects.
/// </summary>
public class Soil : MonoBehaviour, IDropHandler
{
	public GameObject placeSeedsMenu;
	public SeedData seedData;

	/// <summary>
	/// Called when a Purchased Seed object is dropped onto the Soil object.
	/// </summary>
	/// <param name="eventData"></param>
	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag.gameObject.tag == "PurchasedSeed")
		{
			seedData = eventData.pointerDrag.GetComponent<PurchasedSeed>().seedData;

			transform.GetChild(2).GetComponent<Image>().sprite = seedData.Icon;

			Color newColour = transform.GetChild(2).GetComponent<Image>().color;
			newColour.a = 1f;

			transform.GetChild(2).GetComponent<Image>().color = newColour;

			placeSeedsMenu.GetComponent<PlaceSeedsMenu>().CalculateTotalProfit();
		}
	}
}
