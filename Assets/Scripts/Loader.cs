using UnityEngine.SceneManagement;

/// <summary>
/// Handles the loading of game scenes.
/// </summary>
public static class Loader
{
    /// <summary>
    /// Contains all game scenes.
    /// </summary>
    public enum Scene
    {
        MainMenuScene,
        HubMenuScene,
        GameplayScene,
        LoseScene
    }

    /// <summary>
    /// loads the selected game scene.
    /// </summary>
    /// <param name="scene"></param>
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
