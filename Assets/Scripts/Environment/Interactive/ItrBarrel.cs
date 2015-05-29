using UnityEngine;
using System.Collections;
using Global;

public class ItrBarrel : InteractiveObject
{
    private bool _isGrabed;

    public void GrabBarrel()
    {
        if (CurHeroGameObject != null)
        {
            if (!_isGrabed)
            {
                _isGrabed = true;
                gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.transform.parent.SetParent(CurHeroGameObject.GetComponent<Hero>().GrabPointGameObject.transform);
            }
            else
            {
                _isGrabed = false;
                gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                CurHeroGameObject.GetComponent<Hero>().GrabPointGameObject.transform.DetachChildren();
            }
        }
    }
}
