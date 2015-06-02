using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentController : MonoBehaviour
{
    public GameObject ControlPanel;
    public GameObject DoorCtrPanel;

    void Awake()
    {
        ItrDoor[] allDoors = GameObject.FindObjectsOfType<ItrDoor>();
    }

    public void ShowControlPanel(int[] itrDootArr)
    {
        HideAll();
        ControlPanel.SetActive(true);
    }

    public void HideControlPanel()
    {
        HideAll();
        ControlPanel.SetActive(false);
    }

    private void PrepareDoorCtrPanel(ItrDoor itrObj)
    {
        HideAll();
        DoorCtrPanel.SetActive(true);

        DoorCtrPanel.GetComponentInChildren<Text>().text = itrObj.Name;
        var lockSlider = DoorCtrPanel.GetComponentInChildren<Slider>();
        var openButton = DoorCtrPanel.GetComponentsInChildren<Button>()[0];
        var closeButton = DoorCtrPanel.GetComponentsInChildren<Button>()[1];

        lockSlider.onValueChanged.RemoveAllListeners();
        openButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();

        openButton.onClick.AddListener(itrObj.DoorOpen);
        closeButton.onClick.AddListener(itrObj.DoorClose);

        lockSlider.value = (float)itrObj.LockPos;
        lockSlider.onValueChanged.AddListener((delegate(float arg0)
        {
            itrObj.LockPos = (ItrDoor.LockPosition)arg0;
        }));
    }

    private void HideAll()
    {

    }
}
