using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Shop menu in the Hub Menu scene.
/// </summary>
public class ShopMenu : MonoBehaviour
{
    [Header("Lists of items sold")]
    [SerializeField] private SeedData[] seedItems;

    [Header("References")]
    [SerializeField] private Transform seedItemContainer;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject placeSeedsMenu;
    [SerializeField] private GameObject moneyText;

    [Header("Sound")]
    private AudioSource purchaseSuccess;
    private AudioSource purchaseFail;

    /// <summary>
    /// Initialise variables and populate the shop pages.
    /// </summary>
    private void Start()
    {
        PopulateSeedPage();

        AudioSource[] audioSources = GetComponents<AudioSource>();

        purchaseSuccess = audioSources[0];
        purchaseFail = audioSources[1];
    }

    /// <summary>
    /// Purchases the relevant seed if the user has enough money.
    /// </summary>
    /// <param name="seedItem"></param>
    private void OnSeedButtonClick(SeedData seedItem)
    {
        if (GameHandler.CurrentMoney >= seedItem.PurchaseValue)
        {
            purchaseSuccess.Play();

            GameHandler.CurrentMoney -= seedItem.PurchaseValue;
            seedItem.Purchased = true;

            moneyText.GetComponent<TMP_Text>().text = "£" + GameHandler.CurrentMoney;

            ReloadSeedPage();
            PopulateSeedPage();

            placeSeedsMenu.GetComponent<PlaceSeedsMenu>().ReloadPurchasedSeedList();
        }
        else
        {
            purchaseFail.Play();
        }
    }

    /// <summary>
    /// Fills the seed page with all unpurchased seeds.
    /// </summary>
    private void PopulateSeedPage()
    {
        for (int i = 0; i < seedItems.Length; i++)
        {
            SeedData seedItem = seedItems[i];

            if (seedItem.Purchased == false)
            {
                GameObject seedObject = Instantiate(itemPrefab, seedItemContainer);

                // Set the item's name
                seedObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = seedItem.SeedName;

                // Set the item's description
                seedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = seedItem.Description;

                // Set the item's sprite
                seedObject.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = seedItem.Icon;

                // Assign a function to the button
                seedObject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => OnSeedButtonClick(seedItem));

                seedObject.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "£" + seedItem.PurchaseValue;
            }
		}
    }

    /// <summary>
    /// Clears and repopulates the list of unpurchased seeds.
    /// </summary>
    private void ReloadSeedPage()
    {
        int itemCount = seedItemContainer.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            Destroy(seedItemContainer.GetChild(i).gameObject);
        }
    }
}
