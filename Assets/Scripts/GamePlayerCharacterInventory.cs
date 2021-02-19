using System.Collections.Generic;


namespace BeanGame
{
	public class GamePlayerCharacterInventory
	{
		public Weapon         weapon;
		public int            inventorySpace;

		public List<GameItem> items
		{
			get;
			private set;
		}

		public int Count => items.Count;
		public int Space => inventorySpace - items.Count;


		public void AddItem(GameItem i)
		{
			// just do full check in the ui or smth
			// with this you can force an item into the player's inv
			// e.g. a quest item that is absolutely mandatory that they
			// should be using or something idk
			items.Add(i);
		}

		public void RemItem(GameItem i)
		{
			if (i != null)
			{
				items.Remove(i);
			}
		}

		public void MovItem(GameItem i, int slot)
		{
			
		}

		public void SwpItem(GameItem i1, GameItem i2)
		{
			
		}

		public void InitInventory()
		{
			for (int i = 0; i < inventorySpace; i++)
			{
				items.Add(null);
			}
		}
	}
}