using System;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/**
 * Source: https://stackoverflow.com/questions/1293496/serialize-a-static-class
 */
namespace SerializeStatic_NET
{
    public class SerializeStatic
    {
        public static void Load()
        {
            SaveData saveData = new SaveData();

            string savedataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.gd";

            if (File.Exists(savedataPath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(savedataPath, FileMode.Open);
                saveData = (SaveData)bf.Deserialize(file);
                file.Close();
            }

            GameHandler.CurrentMoney = saveData.CurrentMoney;
            GameHandler.CurrentWeekEarnings = saveData.CurrentWeekEarnings;
            GameHandler.CurrentWeekKills = saveData.CurrentWeekKills;
            GameHandler.CurrentWeekNumber = saveData.CurrentWeekNumber;
            GameHandler.CurrentWeekRewardClaimed = saveData.CurrentWeekRewardClaimed;
            GameHandler.MusicVolume = saveData.MusicVolume;
            GameHandler.SfxVolume = saveData.SfxVolume;
            GameHandler.TotalDeaths = saveData.TotalDeaths;
            GameHandler.TotalEarnings = saveData.TotalEarnings;
            GameHandler.TotalKills = saveData.TotalKills;

            Debug.Log(savedataPath);
        }

        public static void Save()
        {
            SaveData saveData = new SaveData();

            saveData.CurrentMoney = GameHandler.CurrentMoney;
            saveData.CurrentWeekEarnings = GameHandler.CurrentWeekEarnings;
            saveData.CurrentWeekKills = GameHandler.CurrentWeekKills;
            saveData.CurrentWeekNumber = GameHandler.CurrentWeekNumber;
            saveData.CurrentWeekRewardClaimed = GameHandler.CurrentWeekRewardClaimed;
            saveData.MusicVolume = GameHandler.MusicVolume;
            saveData.SfxVolume = GameHandler.SfxVolume;
            saveData.TotalDeaths = GameHandler.TotalDeaths;
            saveData.TotalEarnings = GameHandler.TotalEarnings;
            saveData.TotalKills = GameHandler.TotalKills;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.gd");
            bf.Serialize(file, saveData);
            file.Close();
        }
    }
}
