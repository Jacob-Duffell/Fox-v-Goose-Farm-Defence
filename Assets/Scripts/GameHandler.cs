/// <summary>
/// Contains global data to be used across the entire game.
/// </summary>
public static class GameHandler 
{
    private static int currentMoney;

    private static int currentWeekEarnings;
    private static int currentWeekKills;
    private static int currentWeekNumber = 1;
    private static bool currentWeekRewardClaimed = false;

    private static int totalDeaths;
    private static int totalEarnings;
    private static int totalKills;

    private static float musicVolume = 1;
    private static float sfxVolume = 1;

    /// <summary>
    /// The money that the user currently has in their possession.
    /// </summary>
    public static int CurrentMoney { get => currentMoney; set => currentMoney = value; }

    /// <summary>
    /// The money that the user has earned in the past week.
    /// </summary>
    public static int CurrentWeekEarnings { get => currentWeekEarnings; set => currentWeekEarnings = value; }

    /// <summary>
    /// The amount of enemies the user has killed in the past week.
    /// </summary>
    public static int CurrentWeekKills { get => currentWeekKills; set => currentWeekKills = value; }

    /// <summary>
    /// The current week the user has reached.
    /// </summary>
    public static int CurrentWeekNumber { get => currentWeekNumber; set => currentWeekNumber = value; }

    /// <summary>
    /// Stores whether the user has watched a rewarded video advertisement for the current week.
    /// </summary>
    public static bool CurrentWeekRewardClaimed { get => currentWeekRewardClaimed; set => currentWeekRewardClaimed = value; }

    /// <summary>
    /// The total number of times the user has died across all play sessions.
    /// </summary>
    public static int TotalDeaths { get => totalDeaths; set => totalDeaths = value; }

    /// <summary>
    /// The total amount of money the user has earned across all play sessions.
    /// </summary>
    public static int TotalEarnings { get => totalEarnings; set => totalEarnings = value; }

    /// <summary>
    /// The total number of enemies the user has killed across all play sessions.
    /// </summary>
    public static int TotalKills { get => totalKills; set => totalKills = value; }

    /// <summary>
    /// The current music volume level that the user has set.
    /// </summary>
    public static float MusicVolume { get => musicVolume; set => musicVolume = value; }

    /// <summary>
    /// The current SFX volume level that the user has set.
    /// </summary>
    public static float SfxVolume { get => sfxVolume; set => sfxVolume = value; }
}
