using Photon.Pun;
using UnityEngine;

public class NetworkPlayerController : MonoBehaviourPun, IPunObservable
{
    public Transform headTransform;
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;

    private OVRCameraRig ovrCameraRig;

    private Vector3 headPosition, leftControllerPosition, rightControllerPosition;
    private Quaternion headRotation, leftControllerRotation, rightControllerRotation;

    private void Start()
    {
        // OVRCameraRig의 참조를 가져옵니다.
        ovrCameraRig = FindObjectOfType<OVRCameraRig>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            // 자신의 VR 장치의 위치 및 회전을 가져옵니다.
            headPosition = ovrCameraRig.centerEyeAnchor.position;
            headRotation = ovrCameraRig.centerEyeAnchor.rotation;

            leftControllerPosition = ovrCameraRig.leftControllerAnchor.position;
            leftControllerRotation = ovrCameraRig.leftControllerAnchor.rotation;

            rightControllerPosition = ovrCameraRig.rightControllerAnchor.position;
            rightControllerRotation = ovrCameraRig.rightControllerAnchor.rotation;
        }
        else
        {
            // 동기화된 위치 및 회전으로 모델을 업데이트합니다.
            headTransform.position = headPosition;
            headTransform.rotation = headRotation;

            leftControllerTransform.position = leftControllerPosition;
            leftControllerTransform.rotation = leftControllerRotation;

            rightControllerTransform.position = rightControllerPosition;
            rightControllerTransform.rotation = rightControllerRotation;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 자신의 위치 및 회전 정보를 네트워크에 전송합니다.
            stream.SendNext(headPosition);
            stream.SendNext(headRotation);

            stream.SendNext(leftControllerPosition);
            stream.SendNext(leftControllerRotation);

            stream.SendNext(rightControllerPosition);
            stream.SendNext(rightControllerRotation);
        }
        else
        {
            // 네트워크에서 위치 및 회전 정보를 수신합니다.
            headPosition = (Vector3)stream.ReceiveNext();
            headRotation = (Quaternion)stream.ReceiveNext();

            leftControllerPosition = (Vector3)stream.ReceiveNext();
            leftControllerRotation = (Quaternion)stream.ReceiveNext();

            rightControllerPosition = (Vector3)stream.ReceiveNext();
            rightControllerRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
