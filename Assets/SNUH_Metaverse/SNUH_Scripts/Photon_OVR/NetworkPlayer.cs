using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftController;
    public Transform rightController;

    private OVRCameraRig cameraRig;
    private PhotonView photonView;

    private void Start()
    {
        cameraRig = FindObjectOfType<OVRCameraRig>();
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            rightController.gameObject.SetActive(false);
            leftController.gameObject.SetActive(false);
            head.gameObject.SetActive(false);
                        // Head position and rotation
            head.position = cameraRig.centerEyeAnchor.position;
            head.rotation = cameraRig.centerEyeAnchor.rotation;

            // Left controller position and rotation
            leftController.position = cameraRig.leftHandAnchor.position;
            leftController.rotation = cameraRig.leftHandAnchor.rotation;

            // Right controller position and rotation
            rightController.position = cameraRig.rightHandAnchor.position;
            rightController.rotation = cameraRig.rightHandAnchor.rotation;

        }

    }
}

