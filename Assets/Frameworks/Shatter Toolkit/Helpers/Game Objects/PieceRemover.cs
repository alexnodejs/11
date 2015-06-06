// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit.Helpers
{
    [RequireComponent(typeof(ShatterTool))]
    public class PieceRemover : MonoBehaviour
    {
        public int startAtGeneration = 3;
        public float timeDelay = 5.0f;
        public bool whenOutOfViewOnly = true;
        
        protected ShatterTool shatterTool;
        protected new Renderer renderer;
        protected float timeSinceInstantiated;
        
        public void Start()
        {
            shatterTool = GetComponent<ShatterTool>();
            renderer = GetComponent<Renderer>();
        }
        
        public void Update()
        {
            if (shatterTool.Generation >= startAtGeneration)
            {
                timeSinceInstantiated += Time.deltaTime;
                
                if (timeSinceInstantiated >= timeDelay)
                {
                    if (!whenOutOfViewOnly || !renderer.isVisible)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}