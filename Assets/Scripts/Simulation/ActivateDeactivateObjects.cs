using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateObjects : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate;
    public List<GameObject> objectsToActivate;

    private bool hasActivated = false;

    private void Update()
    {
        if (!hasActivated)
        {
            // Deactivate objects from the first list
            foreach (var obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }

            // Activate objects from the second list
            foreach (var obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            hasActivated = true; // Set the flag to indicate activation has occurred
        }
    }
}
