using UnityEngine;
using System.Collections;

using Global;

public class GameManager : MonoBehaviour 
{
    private HeroesController heroesCtr;
    private CameraController cameraCtr;
    private UIController uiCtr;
    private EnemyController enemyCtr;
    private WeaponFactory weaponFact;
    private NeutralsController neutralsCtr;

    public HeroesController GetHeroesCtr()
    {
        if (!heroesCtr)
            heroesCtr = GetComponent<HeroesController>();

        return heroesCtr;
    }

    public EnemyController GetEnemyCtr()
    {
        if (!enemyCtr)
            enemyCtr = GetComponent<EnemyController>();

        return enemyCtr;
    }

    public CameraController GetCameraCtr()
    {
        if (!cameraCtr)
            cameraCtr = GetComponent<CameraController>();

        return cameraCtr;
    }

    public UIController GetUICtr()
    {
        if (!uiCtr)
            uiCtr = GetComponent<UIController>();

        return uiCtr;
    }

    public WeaponFactory GetWeaponFact()
    {
        if (!weaponFact)
            weaponFact = GetComponent<WeaponFactory>();

        return weaponFact;
    }

    public NeutralsController GetNeutralsCtr()
    {
        if (!neutralsCtr)
            neutralsCtr = GetComponent<NeutralsController>();

        return neutralsCtr;
    }
}
