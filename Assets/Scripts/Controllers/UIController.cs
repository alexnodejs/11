using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Global;
using ICode;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject Pointer;
    public GameObject HeroesPanel;
    public Text ScoutHealthLevelText;
    public Text WarBotHealthLevelText;
    public Text TechBotHealthLevelText;

	private SpriteRenderer _pointCircle;
	
	void Start () 
	{
		_pointCircle = Pointer.GetComponent<SpriteRenderer>();
	}

	void Update () 
	{

	}

	public void HighlightDestinationPoint(Ray ray)
	{
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
		{
            Vector3 targetPoint = hitInfo.point;
			_pointCircle.enabled = true;
			Pointer.transform.position = targetPoint + new Vector3(0, 0.2f, 0);
            CancelInvoke("HidePointer");
			Invoke("HidePointer", 0.5f);
		}
	}

    public void UpdateHeroesStatus(List<Hero> heroesList)
    {
        foreach (var hero in heroesList)
        {
            if (hero.GetComponent<ScoutHero>())
            {
                ScoutHealthLevelText.text = hero.HealthLevel.ToString();
            }

            if (hero.GetComponent<WarBotHero>())
            {
                WarBotHealthLevelText.text = hero.HealthLevel.ToString();
            }

            if (hero.GetComponent<TechBotHero>())
            {
                TechBotHealthLevelText.text = hero.HealthLevel.ToString();
            }
        }
    }

	void HidePointer()
	{
		_pointCircle.enabled = false;
	}
}
