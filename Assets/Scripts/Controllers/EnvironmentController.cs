using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICode;

public class EnvironmentController : MonoBehaviour
{
    public GameObject ControlPanel;
    public GameObject DoorCtrPanel;
    public GameObject DoorsListPanel;

    private List<ItrDoor> _allDoors;
    private int[] _curDoorsId;

    void Awake()
    {
        _allDoors = GameObject.FindObjectsOfType<ItrDoor>().ToList();
    }

    public void ShowControlPanel(int[] itrDootArr)
    {
        _curDoorsId = itrDootArr;
        HideAll();
        ControlPanel.SetActive(true);
    }

    public void HideControlPanel()
    {
        HideAll();
        ControlPanel.SetActive(false);
    }

    public void ShowDoorsListPanel()
    {
        HideAll();
        DoorsListPanel.SetActive(true);
        foreach (Button button in DoorsListPanel.GetComponentsInChildren<Button>())
        {
            button.gameObject.SetActive(false);
        }

        foreach (int doorId in _curDoorsId)
        {
            DoorsListPanel.transform.GetChild(doorId).gameObject.SetActive(true);
        }
    }

    public void PrepareDoorCtrPanel(int doorId)
    {
        foreach (ItrDoor door in _allDoors)
        {
            if (door.DoorId == doorId)
            {
                HideAll();
                DoorCtrPanel.SetActive(true);

                DoorCtrPanel.GetComponentInChildren<Text>().text = door.Name;
                var lockSlider = DoorCtrPanel.GetComponentInChildren<Slider>();
                var openButton = DoorCtrPanel.GetComponentsInChildren<Button>()[0];

                lockSlider.onValueChanged.RemoveAllListeners();
                openButton.onClick.RemoveAllListeners();

                openButton.onClick.AddListener(door.DoorOpenClose);

                lockSlider.value = (float)door.LockPos;
                lockSlider.onValueChanged.AddListener((delegate(float arg0)
                {
                    door.LockPos = (ItrDoor.LockPosition)arg0;
                }));

                return;
            }
        }
    }

    private void HideAll()
    {
        DoorCtrPanel.SetActive(false);
        DoorsListPanel.SetActive(false);
    }
}
