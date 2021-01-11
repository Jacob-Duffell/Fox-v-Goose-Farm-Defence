using System;

/// <summary>
/// This exclusively is used to deal with saving to or loading from the save data file.
/// </summary>
[Serializable] public class SaveData
{
    private int currentMoney;

    private int currentWeekEarnings;
    private int currentWeekKills;
    private int currentWeekNumber = 1;
    private bool currentWeekRewardClaimed = false;

    private int totalDeaths;
    private int totalEarnings;
    private int totalKills;

    private float musicVolume = 1;
    private float sfxVolume = 1;

    /// <summary>
    /// The money that the user currently has in their possession.
    /// </summary>
    public int CurrentMoney { get => currentMoney; set => currentMoney = value; }

    /// <summary>
    /// The money that the user has earned in the past week.
    /// </summary>
    public int CurrentWeekEarnings { get => currentWeekEarnings; set => currentWeekEarnings = value; }

    /// <summary>
    /// The amount of enemies the user has killed in the past week.
    /// </summary>
    public int CurrentWeekKills { get => currentWeekKills; set => currentWeekKills = value; }

    /// <summary>
    /// The current week the user has reached.
    /// </summary>
    public int CurrentWeekNumber { get => currentWeekNumber; set => currentWeekNumber = value; }

    /// <summary>
    /// Stores whether the user has watched a rewarded video advertisement for the current week.
    /// </summary>
    public bool CurrentWeekRewardClaimed { get => currentWeekRewardClaimed; set => currentWeekRewardClaimed = value; }

    /// <summary>
    /// The total number of times the user has died across all play sessions.
    /// </summary>
    public int TotalDeaths { get => totalDeaths; set => totalDeaths = value; }

    /// <summary>
    /// The total amount of money the user has earned across all play sessions.
    /// </summary>
    public int TotalEarnings { get => totalEarnings; set => totalEarnings = value; }

    /// <summary>
    /// The total number of enemies the user has killed across all play sessions.
    /// </summary>
    public int TotalKills { get => totalKills; set => totalKills = value; }

    /// <summary>
    /// The current music volume level that the user has set.
    /// </summary>
    public float MusicVolume { get => musicVolume; set => musicVolume = value; }

    /// <summary>
    /// The current SFX volume level that the user has set.
    /// </summary>
    public float SfxVolume { get => sfxVolume; set => sfxVolume = value; }
}
