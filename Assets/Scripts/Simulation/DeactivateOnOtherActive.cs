using UnityEngine;

public class DeactivateOnOtherActive : MonoBehaviour
{
    public GameObject otherObject; 
    private void Update()
    {
        
        if (otherObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
