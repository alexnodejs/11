using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentController : MonoBehaviour
{
    public GameObject ControlPanel;
    public ItrDoor[] DoorsArray;
    
    public GameObject DoorCtrPanel;
    public GameObject EnergyCtrPanel;
    public GameObject DoorsListPanel;
    public GameObject EnergyListPanel;

    public GameObject CtrPanButtonPrefab;

    void Awake()
    {
        BuildDoorsListPanel();
    }

    public void ShowControlPanel()
    {
        HideAll();
        ControlPanel.SetActive(true);
    }

    public void HideControlPanel()
    {
        HideAll();
        ControlPanel.SetActive(false);
    }

    public void ShowDoors()
    {
        HideAll();
        DoorsListPanel.SetActive(true);
    }

    public void ShowEnergy()
    {
        HideAll();
        EnergyListPanel.SetActive(true);
    }

    private void BuildDoorsListPanel()
    {
        for (int i = 0; i < DoorsArray.Length; i++)
        {
            float newY = CtrPanButtonPrefab.transform.position.y - (50*i);
            ItrDoor itrObj = DoorsArray[i];
            GameObject button = Instantiate(CtrPanButtonPrefab, new Vector3(0f, newY, 0f), Quaternion.Euler(Vector3.zero)) as GameObject;
            button.GetComponentInChildren<Text>().text = itrObj.Name;
            button.transform.SetParent(DoorsListPanel.transform);
            button.transform.localScale = new Vector3(1,1,1);

            button.GetComponent<Button>().onClick.AddListener(() => PrepareDoorCtrPanel(itrObj));
        }
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

        lockSlider.value = (float)itrObj.lockPos;
        lockSlider.onValueChanged.AddListener((delegate(float arg0)
        {
            itrObj.lockPos = (ItrDoor.LockPosition)arg0;
        }));
    }

    private void HideAll()
    {
        DoorCtrPanel.SetActive(false);
        EnergyCtrPanel.SetActive(false);
        DoorsListPanel.SetActive(false);
        EnergyListPanel.SetActive(false);
    }
}
