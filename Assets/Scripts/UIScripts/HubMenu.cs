using SerializeStatic_NET;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// Handles logic for the Hub Menu screen in the Hub Menu scene.
/// </summary>
public class HubMenu : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject advertPanel;
    [SerializeField] private RectTransform menuContainer;
    [SerializeField] private GameObject placeSeedsMenu;

    [Header("Smooth")]
    [SerializeField] private bool smooth;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 desiredPosition;

    [Header("Sound")]
    private AudioSource clickSound;

    [Header("Logic")]
    private TMP_Text weekTitle;
    private TMP_Text killsText;
    private TMP_Text earningsText;
    private TMP_Text moneyText;
    private Vector3 halfScreen;
    private Vector3[] menuPositions;

    /// <summary>
    /// Initialises variables when the scene is loaded.
    /// </summary>
    private void Start()
    {
        SerializeStatic.Load();

        Advertisement.Initialize("3538102", false);

        StartCoroutine(ShowBannerAd());

        if (GameHandler.CurrentWeekNumber > 1 && !GameHandler.CurrentWeekRewardClaimed)
        {
            advertPanel.SetActive(true);
            advertPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Double your earnings for this week from £" + GameHandler.CurrentWeekEarnings + " to £" + (GameHandler.CurrentWeekEarnings * 2) + " by watching this ad!";
        }

        weekTitle = menuContainer.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        killsText = menuContainer.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
        earningsText = menuContainer.GetChild(0).GetChild(3).GetComponent<TMP_Text>();
        moneyText = menuContainer.GetChild(1).GetChild(2).GetComponent<TMP_Text>();

        weekTitle.text = "Week " + GameHandler.CurrentWeekNumber;
        killsText.text = "Total Kills Last Week: " + GameHandler.CurrentWeekKills;
        earningsText.text = "Total Earnings Last Week: £" + GameHandler.CurrentWeekEarnings;
        moneyText.text = "£" + GameHandler.CurrentMoney;

        // Get all initial positions
        halfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        menuPositions = new Vector3[menuContainer.childCount];

        for (int i = 0; i < menuPositions.Length; i++)
        {
            menuPositions[i] = menuContainer.GetChild(i).position - halfScreen;
        }

        clickSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Updates the position of the menu container object when the user switches between menus.
    /// </summary>
    private void Update()
    {
        if (smooth)
        {
            menuContainer.anchoredPosition = Vector3.Lerp(menuContainer.anchoredPosition, desiredPosition, smoothSpeed);
        }
        else
        {
            menuContainer.anchoredPosition = desiredPosition;
        }
    }

    /// <summary>
    /// Switches between two menus in the Hub Menu scene.
    /// </summary>
    /// <param name="id"></param>
    public void MoveMenu(int id)
    {
        clickSound.Play();

        desiredPosition = -menuPositions[id];
    }

    /// <summary>
    /// Loads the Gameplay scene.
    /// </summary>
    public void StartNewWeek()
    {
        clickSound.Play();

        GameHandler.CurrentWeekEarnings = placeSeedsMenu.GetComponent<PlaceSeedsMenu>().totalProfit;

        Advertisement.Banner.Hide();

        Loader.Load(Loader.Scene.GameplayScene);
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    public void QuitGame()
    {
        clickSound.Play();

        Loader.Load(Loader.Scene.MainMenuScene);
    }

    public void CloseAdvertMenu()
    {
        advertPanel.SetActive(false);
    }

    IEnumerator ShowBannerAd()
    {
        while (!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("banner");
    }
}
