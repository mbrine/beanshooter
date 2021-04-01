using System.Collections.Generic;


namespace BeanGame
{
	public class PlayerInventory
	{
		public int            inventorySpace;
		public List<GameItem> items
		{
			get;
		}

		public int Count => items.Count;
		public int Space => inventorySpace - items.Count;

		public Looks equippedVanitySlot1;
		public Looks equippedVanitySlot2;
		public Looks equippedVanitySlot3;
		public Looks equippedVanitySlotOutfit; 
		
		public Weapon equippedWeapon1; // DPAD-UP
		public Weapon equippedWeapon2; // DPAD-LF
		public Weapon equippedWeapon3; // DPAD-RT
		public Weapon equippedWeapon4; // DPAD-DN

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

		public void MovItem(int slot1, int slot2)
		{
			if (items[slot2] != null)
			{
				items[slot2] = items[slot1];
			}
			else
			{
				SwpItem(items[slot1], items[slot2]);
			}
		}

		public void SwpItem(GameItem i1, GameItem i2)
		{
			GameItem temp;
			temp = i1;
			i1 = i2;
			i2 = temp;
		}

		public void EquipWeapon(Weapon w, int slot)
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