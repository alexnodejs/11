using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class EnergyLevelController : MonoBehaviour {

	public Hero Scout;
	public GameObject textLabel;
	public Sprite[] levelSptites = new Sprite[9];
	//  private double energyLevel;
	private Hero currentHero;

	void Start () {
		//  energyLevel = 100d;
		currentHero = Scout.GetComponent<ScoutHero>();
	}

	void Update () {
		//  if (Input.GetKey(KeyCode.Z)) {
		//  	if (energyLevel > 0) {
		//  		energyLevel -= 1;
		//  	}
		//  }

		//  if (Input.GetKey(KeyCode.X)) {
		//  	if (energyLevel < 100) {
		//  		energyLevel += 1;
		//  	}
		//  }

		int spriteIndex = (int)Math.Floor(currentHero.EnergyLevel / 10);
		this.gameObject.GetComponent<Image>().sprite = levelSptites[spriteIndex];

		textLabel.GetComponent<Text>().text = currentHero.EnergyLevel.ToString() + "%";
	}
}
