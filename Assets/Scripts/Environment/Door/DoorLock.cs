using UnityEngine;
using System.Collections;
using Global;

public class DoorLock : MonoBehaviour 
{
    public GameObject canvasUI;

    private DoorAPI doorAPI;

    void Awake()
    {
        doorAPI = GetComponentInParent<DoorAPI>();
    }

    void OnMouseEnter()
    {
        if (doorAPI.isHeroAround)
            canvasUI.SetActive(true);
    }

    void OnMouseExit()
    {
        if (doorAPI.isHeroAround)
            canvasUI.SetActive(false);
    }
}
