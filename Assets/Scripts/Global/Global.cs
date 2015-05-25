using UnityEngine;
using System.Collections;

namespace Global
{ 
	#region Constants

	public static class Const
	{
		public const string GAME_NAME = "Space Hunta";
		public const string GAME_VERSION = "0.1";
	}

	public static class Tags
	{
		public const string player = "Player";
		public const string untagged = "Untagged";
		public const string respawn = "Respawn";
		public const string finish = "Finish";
		public const string editorOnly = "EditorOnly";
		public const string minCamera = "MainCamera";
		public const string gameController = "GameController";
		public const string gameManager = "GameManager";
		public const string heroes = "Heroes";
		public const string weapon = "Weapon";
        public const string actionBar = "ActionBar";
    }

	public static class Layers
	{
		public const string defaultL = "Default";
		public const string transparentFX = "TransparentFX";
		public const string ignoreRaycast = "Ignore Raycast";
		public const string water = "Water";
		public const string ui = "UI";
		public const string gameManager = "GameManager";
		public const string heroes = "Heroes";
	}

    // Objects materials and damage:
    public static class DamageValues
    {
        public const float ShotGun = 2f;
        public const float Explosion = 200f;
        public const float SelfFire = 20f;
    }

    public enum ObjMaterials
    {
        Other,
        Metal,
        Glass,
        Brick,
        Stone,
        Meat
    }

    public enum DamageType
    {
        Other,
        Kinetik,
        Termal,
        Electro,
        Explosion
    }

	#endregion
}
