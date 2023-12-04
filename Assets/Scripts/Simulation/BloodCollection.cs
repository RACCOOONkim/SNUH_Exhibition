using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodCollection : MonoBehaviour
{
    // 이벤트 핸들러 정의
    public delegate void OnLeftHandTriggerEnterEvent();
    public event OnLeftHandTriggerEnterEvent OnLeftHandTriggerEnter;

    public Image imageToDisable; // 비활성화될 Image UI
    public Image imageToEnable;  // 활성화될 Image UI
    public GameObject hand; 
    public GameObject handMesh; 
    public GameObject handRay; 
    public Material originalMaterial;
    public Material newMaterial;
    public LayerMask triggerLayer;
    public GameObject alert;

    public float collisionDuration = 5f;
    private float collisionTimer = 0f;
    private bool isColliding = false;
    private bool outCheck = false;
    private bool endSimul = false;
    private bool hasSwitchedText = false;

    private void Update()
    {
        Renderer renderer = hand.GetComponent<Renderer>();
        if (!isColliding)
        {
            collisionTimer = 0f;
            renderer.material = originalMaterial;
            handMesh.SetActive(true);
            handRay.SetActive(true);
            if(outCheck && endSimul == false) 
            {
                alert.SetActive(true);
                outCheck = false;
            }
            
            CheckForCollision();
        }
        else
        {
            collisionTimer += Time.deltaTime;
            renderer.material = newMaterial;
            outCheck = true;
            handMesh.SetActive(false);
            handRay.SetActive(false);
            alert.SetActive(false);
            CheckForCollision();
            if (collisionTimer >= collisionDuration && !hasSwitchedText)
            {
                StartCoroutine(SwitchImage());
                hasSwitchedText = true;
            }
        }
    }

    private void CheckForCollision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        bool hasCollision = false;

        foreach (var collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("LeftHand"))
            {
                hasCollision = true;
                if (OnLeftHandTriggerEnter != null)
                    OnLeftHandTriggerEnter();
                break;
            }
        }

        isColliding = hasCollision;
    }

    private IEnumerator SwitchImage()
    {
        if (imageToDisable != null)
        {
            for (float t = 0; t < 2f; t += Time.deltaTime)
            {
                imageToDisable.color = new Color(imageToDisable.color.r, imageToDisable.color.g, imageToDisable.color.b, Mathf.Lerp(1, 0, t / 2f));
                yield return null;
            }
            imageToDisable.gameObject.SetActive(false);
        }

        if (imageToEnable != null)
        {
            imageToEnable.gameObject.SetActive(true);
            for (float t = 0; t < 2f; t += Time.deltaTime)
            {
                imageToEnable.color = new Color(imageToEnable.color.r, imageToEnable.color.g, imageToEnable.color.b, Mathf.Lerp(0, 1, t / 2f));
                yield return null;
            }
            alert.SetActive(false);
            endSimul = true;
        }
    }
}
