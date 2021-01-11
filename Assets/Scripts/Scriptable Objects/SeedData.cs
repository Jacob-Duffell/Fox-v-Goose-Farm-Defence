using UnityEngine;

/// <summary>
/// This scriptable object contains data of the seeds that are bought and planted in the game.
/// </summary>
[CreateAssetMenu(fileName = "New SeedData", menuName = "Seed Data", order = 51)]
public class SeedData : ScriptableObject
{
    [SerializeField] private string seedName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private int purchaseValue;
    [SerializeField] private int saleValue;
    [SerializeField] private bool purchased;

    /// <summary>
    /// The name of the seed.
    /// </summary>
    public string SeedName { get => seedName; }

    /// <summary>
    /// A description of the seed.
    /// </summary>
    public string Description { get => description; }

    /// <summary>
    /// The sprite used to represent the seed.
    /// </summary>
    public Sprite Icon { get => icon; }

    /// <summary>
    /// The price of buying the seed.
    /// </summary>
    public int PurchaseValue { get => purchaseValue; }

    /// <summary>
    /// The monetary value the player will earn from growing the seed.
    /// </summary>
    public int SaleValue { get => saleValue; }

    /// <summary>
    /// Has the seed been purchased by the user in the store?
    /// </summary>
    public bool Purchased { get => purchased; set => purchased = value; }
}
