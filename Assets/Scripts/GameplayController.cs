using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeanGame
{
	public class GameplayController
	{
		private static GameplayController _instance = null;
		
		private GameplayController()
		{
			// some initing i guess, dont know what to do here
		}

		public static GameplayController Instance =>  _instance ?? (_instance = new GameplayController());

		public static Weapon GenerateWeapon(int iLevel)
		{
			return null;
		}
		
	}
}