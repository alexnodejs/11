using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class HealthLevelController : MonoBehaviour {

	public Hero Scout;
	public GameObject textLabel;
	public Sprite[] levelSptites = new Sprite[9];
	private Hero currentHero;

	void Start () {
		currentHero = Scout.GetComponent<ScoutHero>();
	}

	void Update () {

		int spriteIndex = (int)Math.Floor(currentHero.HealthLevel / 10);
		this.gameObject.GetComponent<Image>().sprite = levelSptites[spriteIndex];

		textLabel.GetComponent<Text>().text = currentHero.HealthLevel.ToString() + "%";
	}
}
