// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit.Helpers
{
    public class MouseShatter : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    hit.collider.SendMessage("Shatter", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}