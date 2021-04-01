using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Status Effect", menuName = "BeanGame/Status Effect", order = 10)]
	public class StatusEffect : ScriptableObject
	{
		public Texture2D effectIcon;
		public string effectTitle;
		public string effectDesc;

		public float effectDuration;
		public float effectTimer; // TO BE UPDATED BY Time.deltaTime

		public int effectMaxStacks;
		public int effactCurrentStacks;

		public bool isDebuff;
		public bool timerResetsWhenReapplied; // idk

		public StatusEffect GetFresh()
		{
			return Instantiate(this);
		}
	}
}