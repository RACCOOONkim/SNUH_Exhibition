using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using OVR;

public class NetworkAvartarMapper : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform head, hands, controllers;
    private Transform leftController, rightController;

    private PhotonView photonView;

    private Transform headRig, leftControllerRig, rightControllerRig;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        leftController = controllers.GetChild(0);
        rightController = controllers.GetChild(1);

        // Oculus Integration에서의 Player Rig 참조를 얻습니다.
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null)
        {
            headRig = cameraRig.centerEyeAnchor;
            leftControllerRig = cameraRig.leftHandAnchor;
            rightControllerRig = cameraRig.rightHandAnchor;
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(head, headRig);
            MapPosition(leftController, leftControllerRig);
            MapPosition(rightController, rightControllerRig);
        }
    }

    private void MapPosition(Transform target, Transform rigTransform)
    {
        target.SetPositionAndRotation(rigTransform.position, rigTransform.rotation);
    }
}
