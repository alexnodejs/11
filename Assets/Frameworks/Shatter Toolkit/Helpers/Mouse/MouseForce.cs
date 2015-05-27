// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit.Helpers
{
    public class MouseForce : MonoBehaviour
    {
        public float impulseScale = 25.0f;
        
        protected Rigidbody grabBody;
        protected Vector3 grabPoint;
        protected float grabDistance;
        
        public void Update()
        {
            GrabBody();
            
            ReleaseBody();
        }
        
        public void FixedUpdate()
        {
            MoveBody();
        }
        
        protected void GrabBody()
        {
            if (grabBody == null)
            {
                // Let the player grab a rigidbody
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        if (hit.rigidbody != null)
                        {
                            grabBody = hit.rigidbody;
                            grabPoint = grabBody.transform.InverseTransformPoint(hit.point);
                            grabDistance = hit.distance;
                        }
                    }
                }
            }
        }
        
        protected void ReleaseBody()
        {
            if (grabBody != null)
            {
                // Let the player release the rigidbody
                if (Input.GetMouseButtonUp(0))
                {
                    grabBody = null;
                }
            }
        }
        
        protected void MoveBody()
        {
            if (grabBody != null)
            {
                // Move the grabbed rigidbody
                Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, grabDistance);
                
                Vector3 targetPoint = Camera.main.ScreenToWorldPoint(screenPoint);
                Vector3 anchorPoint = grabBody.transform.TransformPoint(grabPoint);
                
                Debug.DrawLine(targetPoint, anchorPoint, Color.red);
                
                Vector3 impulse = (targetPoint - anchorPoint) * (impulseScale * Time.fixedDeltaTime);
                
                grabBody.AddForceAtPosition(impulse, anchorPoint, ForceMode.Impulse);
            }
        }
    }
}