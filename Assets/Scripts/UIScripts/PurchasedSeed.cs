using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles logic for the Purchased Seed object.
/// </summary>
public class PurchasedSeed : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private CanvasGroup canvasGroup;
	private int originalIndex;
	private Transform originalParent;
	private Vector3 startPosition;

	[NonSerialized] public SeedData seedData;

	/// <summary>
	/// Initialize variables when the Purched Seed is instantiated.
	/// </summary>
	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	/// <summary>
	/// Called when the user starts dragging the Purchased Seed object from the list of purchased seeds.
	/// </summary>
	/// <param name="eventData"></param>
	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = 0.6f;

		startPosition = transform.localPosition;
		originalParent = transform.parent;
		originalIndex = transform.GetSiblingIndex();

		transform.SetParent(transform.parent.parent.parent, true);
	}

	/// <summary>
	/// Called while the user is dragging the Purchased Seed object.
	/// </summary>
	/// <param name="eventData"></param>
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	/// <summary>
	/// Called when the user releases the Purchased Seed object they have been dragging.
	/// If the Purchased Seed object is placed over a soil object, the soil will contain the seed data.
	/// </summary>
	/// <param name="eventData"></param>
	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;

		transform.SetParent(originalParent, true);
		transform.SetSiblingIndex(originalIndex);
		transform.localPosition = startPosition;
	}
}
