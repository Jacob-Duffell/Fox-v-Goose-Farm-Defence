using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;
using SerializeStatic_NET;

/// <summary>
/// https://unityads.unity3d.com/help/unity/integration-guide-unity#implementing-rewarded-ads
/// </summary>
[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{
    public GameObject advertPanel;
    public GameObject shopMoneyText;

    private Button myButton;

    private const string GAME_ID = "1486550";
    private const string MY_PLACEMENT_ID = "rewardedVideo";

    private void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(MY_PLACEMENT_ID);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(GAME_ID, true);
    }

    private void Update()
    {
        if (myButton.interactable == false)
        {
            myButton.interactable = Advertisement.IsReady(MY_PLACEMENT_ID);
        }
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        advertPanel.SetActive(false);

        Advertisement.Show(MY_PLACEMENT_ID);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == MY_PLACEMENT_ID)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            GameHandler.CurrentWeekRewardClaimed = true;
            GameHandler.CurrentMoney += GameHandler.CurrentWeekEarnings;

            SerializeStatic.Save();

            shopMoneyText.GetComponent<TMP_Text>().text = "£" + GameHandler.CurrentMoney;
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}