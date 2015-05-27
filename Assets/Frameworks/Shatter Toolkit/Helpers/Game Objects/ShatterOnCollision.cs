// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit.Helpers
{
    public class ShatterOnCollision : MonoBehaviour
    {
        public float requiredVelocity = 1.0f;
        public float cooldownTime = 0.5f;
        
        protected float timeSinceInstantiated;
        
        public void Update()
        {
            timeSinceInstantiated += Time.deltaTime;
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (timeSinceInstantiated >= cooldownTime)
            {
                if (collision.relativeVelocity.magnitude >= requiredVelocity)
                {
                    // Find the new contact point
                    foreach (ContactPoint contact in collision.contacts)
                    {
                        // Make sure that we don't shatter if another object in the hierarchy was hit
                        if (contact.otherCollider == collision.collider)
                        {
                            contact.thisCollider.SendMessage("Shatter", contact.point, SendMessageOptions.DontRequireReceiver);
                            
                            break;
                        }
                    }
                }
            }
        }
    }
}