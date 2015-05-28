using UnityEngine;
using System.Collections;

using Global;

public class UIController : MonoBehaviour {

	public GameObject Pointer;
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

	void HidePointer()
	{
		_pointCircle.enabled = false;
	}
}
