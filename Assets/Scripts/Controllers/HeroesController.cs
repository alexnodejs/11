using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Global;

public class HeroesController : MonoBehaviour
{
    public List<Hero> HeroesList;
    public delegate void FreeMode();
    public delegate void FollowMode(GameObject target);
    public static event FollowMode onFollowMode;
    public static event FreeMode onFreeMode;

    private int _curHeroID;
    private Hero _curHero;
	private int selectebleMask;
	private float range = 100f;
	private RaycastHit shootHit;
	private Ray ray;
	private UIController uiCtr;
	
	private bool isFollowMode = false;

	void Start() 
	{
		selectebleMask = LayerMask.GetMask(Layers.heroes);
		uiCtr = GetComponent<UIController>();

        SelectHeroWithIndex(0);
	    
	}

	void Update () 
	{
		if (InputManager.Fire1() && !InputManager.Shift() && !isFollowMode)
		{
			SelectHero();
		}

	    if (InputManager.TabUp())
	    {
	        NextHero();
	    }

		if (InputManager.Fire2())
		{
			GetDistinationPosition();
		}

		if (InputManager.Space())
		{
			SetHeroOrientation();
			if (InputManager.Fire1())
			{
				HeroMustShoot();
			}
		}

		if (InputManager.Follow())
		{
			SetUpCameraMode();
		}

	    if (InputManager.UseUp())
	    {
            _curHero.TryToInteract();
	    }

	    if (InputManager.ControlUp())
	    {
	        if (_curHero is ScoutHero)
	        {
	            ScoutHero scout = _curHero as ScoutHero;
                scout.DuckModeToggle();
	        }
	    }

	    if (InputManager.ShiftUp())
	    {
            if (_curHero is ScoutHero)
            {
                ScoutHero scout = _curHero as ScoutHero;
                scout.ScoutRunToggle();
            }
	    }
	}

	void SetUpCameraMode()
	{
		if (onFollowMode != null && !isFollowMode)
		{
            onFollowMode(_curHero.gameObject);
			isFollowMode = true;
		}
		else if (onFreeMode != null)
		{
			onFreeMode();
			isFollowMode = false;
		}
	}

    private void SelectHeroWithIndex(int index)
    {
        if (_curHero)
            _curHero.UnselectHero();

        _curHero = HeroesList[index];
        _curHeroID = index;
        _curHero.SelectHero();
    }

    private void NextHero()
    {
        int newHeroID = _curHeroID + 1;
        if (newHeroID < HeroesList.Count)
        {
            SelectHeroWithIndex(newHeroID);
        }
        else
        {
            SelectHeroWithIndex(0);
        }
    }

	void SelectHero()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out shootHit, range, selectebleMask))
		{
		    Hero hero = shootHit.rigidbody.GetComponent<Hero>();
		    if (hero)
		    {
		        for (int i = 0; i < HeroesList.Count; i++)
		        {
		            Hero heroFromList = HeroesList[i];
		            if (heroFromList.Equals(hero))
		            {
		                SelectHeroWithIndex(i);
		            }
		        }
		    }
		}
	}

	void GetDistinationPosition()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		uiCtr.HighlightDestinationPoint(ray);
        _curHero.SetDistinationPosition(ray);
	}

    void SetHeroOrientation()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _curHero.OrientateHero(ray);
	}

	void HeroMustShoot()
	{
        //_curHero.AttackCharacter();
	}
}