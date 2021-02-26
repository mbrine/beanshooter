using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Game Item", menuName = "BeanGame/Game Item")]
	public class GameItem : ScriptableObject
	{
		public class Rarity
		{
			public enum Level
			{
				UNDEFINED,
				NORMAL,
				UNCOMMON,
				RARE,
				VERYRARE,
				LEGENDARY,
			}

			Dictionary<Level, Color> RarityColor = new Dictionary<Level, Color>()
			{
				{Level.UNDEFINED,        new Color(0.00f, 0.00f, 0.00f)},
				{Level.NORMAL,           new Color(0.73f, 0.73f, 0.73f)},
				{Level.UNCOMMON,         new Color(0.00f, 1.00f, 0.00f)},
				{Level.RARE,             new Color(0.00f, 0.00f, 1.00f)},
				{Level.VERYRARE,         new Color(0.80f, 0.00f, 0.60f)},
				{Level.LEGENDARY,        new Color(1.00f, 0.60f, 0.00f)},
			};
			
			public void AddRarityColor(Level rarityLevel, Color rarityColor)
			{
				RarityColor.Add(rarityLevel, rarityColor);
			}
		}

		public string       itemName;
		public Rarity.Level itemRarity = Rarity.Level.UNDEFINED;

		public Sprite       itemSprite;
		public int          itemLevel; // THIS IS NOT THE SAME AS WEAPON/ARMOR LEVEL
		
	}
}