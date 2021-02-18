using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;

namespace BeanGame
{
    public static class GameSaveLoadHandler
    {
        public static bool SavePlayerCharacter(GamePlayerCharacter c)
        {
            if (c == null) return false;

            if (!Directory.Exists(GameStrings.SavesLocation))
                Directory.CreateDirectory(GameStrings.SavesLocation);

            GameCharacterSave save = new GameCharacterSave();

            save.CharacterName = c.characterName;
            save.CharacterID = c.characterID;
            save.BaseHealth = c.baseHealth;

            File.WriteAllText(
                Path.Combine(GameStrings.SavesLocation, $"SAVE_{ c.characterID }.bgsave"), 
                JsonUtility.ToJson(save, true));
            return true;
        }

        public static GamePlayerCharacter LoadPlayerCharacter(this GameObject go, string directory)
        {
            try
            {
                string input = File.ReadAllText(directory); 
                GameCharacterSave save = JsonUtility.FromJson<GameCharacterSave>(input);
                GamePlayerCharacter temp = go.AddComponent<GamePlayerCharacter>();
                
                temp.characterName = save.CharacterName;
                temp.characterID = save.CharacterID;
                temp.baseHealth = save.BaseHealth;
                
                return temp;
            }
            catch (ArgumentException e)
            {
                
                return null;
            }
        }

        public static List<string> GetListOfCharacters()
        {
            DirectoryInfo dir = new DirectoryInfo(GameStrings.SavesLocation);
            FileInfo[] files = dir.GetFiles("*.bgsave");
            List<string> charNames = new List<string>();
            foreach (var file in files)
            {
                string input = File.ReadAllText(file.ToString()); 
                GameCharacterSave save = JsonUtility.FromJson<GameCharacterSave>(input);
                charNames.Add(save.CharacterName);
            }
            return charNames;
        }
    }
}

