// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit.Helpers
{
    public class MouseInstantiate : MonoBehaviour
    {
        public GameObject prefabToInstantiate;
        
        public float speed = 7.0f;
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && prefabToInstantiate != null)
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                GameObject newGameObject = (GameObject)Instantiate(prefabToInstantiate, mouseRay.origin, Quaternion.identity);
                
                Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = mouseRay.direction * speed;
                }
            }
        }
    }
}