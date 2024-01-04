using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public List<GameObject> ObjectsToActivateDeactivate;

    public void ActivateDeactivateObjects(bool activate)
    {
        foreach (var obj in ObjectsToActivateDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(activate);
            }
        }
    }
}
