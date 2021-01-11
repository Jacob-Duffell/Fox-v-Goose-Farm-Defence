using SerializeStatic_NET;
using UnityEngine;

/// <summary>
/// Functions to be used in the Main Menu and Game Over Menu scenes.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueGameButton;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private SeedData[] seeds;

    /// <summary>
    /// Initialise variables.
    /// </summary>
    private void Start()
    {
        SerializeStatic.Load();

        if (GameHandler.CurrentWeekNumber == 1)
        {
            continueGameButton.SetActive(false);
        }
    }

    /// <summary>
    /// Start a new game from week 1, losing any previously saved progress.
    /// </summary>
    public void StartNewGame()
    {
        seeds[0].Purchased = true;

        for (int i = 1; i < seeds.Length; i++)
        {
            seeds[i].Purchased = false;
        }

        GameHandler.CurrentMoney = 0;
        GameHandler.CurrentWeekEarnings = 0;
        GameHandler.CurrentWeekKills = 0;
        GameHandler.CurrentWeekNumber = 1;GameHandler.CurrentWeekRewardClaimed = false;

        SerializeStatic.Save();

        Loader.Load(Loader.Scene.HubMenuScene);
    }

    /// <summary>
    /// Continue the saved game, if they have any saved data.
    /// </summary>
    public void ConinueGame()
    {
        Loader.Load(Loader.Scene.HubMenuScene);
    }

    /// <summary>
    /// Closes the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Opens the Main Menu scene.
    /// </summary>
    public void QuitToMainMenu()
    {
        Loader.Load(Loader.Scene.MainMenuScene);
    }

    /// <summary>
    /// Opens the credits menu.
    /// </summary>
    public void OpenCreditsMenu()
    {
        creditsPanel.SetActive(true);
    }

    /// <summary>
    /// Closes the credits menu.
    /// </summary>
    public void CloseCreditsMenu()
    {
        creditsPanel.SetActive(false);
    }
}