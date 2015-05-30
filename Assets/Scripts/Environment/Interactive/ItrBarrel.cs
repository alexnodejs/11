using UnityEngine;
using System.Collections;
using Global;

public class ItrBarrel : InteractiveObject
{
    private bool _isGrabed;

    protected override void OnUseButtonUp()
    {
        base.OnUseButtonUp();

        if (CurHeroGameObject != null)
        {
            if (!_isGrabed)
            {
                _isGrabed = true;
                gameObject.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.transform.parent.SetParent(CurHeroGameObject.GetComponent<Hero>().GrabPointGameObject.transform);
                gameObject.transform.parent.transform.localPosition = Vector3.zero;
                gameObject.transform.parent.transform.rotation = Quaternion.Euler(Vector3.zero);
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
