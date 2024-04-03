using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayer;

    private List<int> playerNumbers = new List<int> { 1, 2, 3, 4, 5, 6 }; // 사용 가능한 플레이어 번호 리스트
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        int assignedNumber = AssignPlayerNumber();
        string playerPrefabName = "Network Player" + assignedNumber;

        spawnedPlayer = PhotonNetwork.Instantiate(playerPrefabName, transform.position, transform.rotation);
    }
    
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);
    }

    // 사용 가능한 플레이어 번호를 반환하는 함수
    private int AssignPlayerNumber()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.ContainsKey("PlayerNumber"))
            {
                int takenNumber = (int)player.CustomProperties["PlayerNumber"];
                playerNumbers.Remove(takenNumber); // 이미 사용 중인 번호를 리스트에서 제거
            }
        }

        // 사용 가능한 가장 낮은 번호 할당
        int availableNumber = playerNumbers[0];
        playerNumbers.RemoveAt(0);
        PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "PlayerNumber", availableNumber } });

        return availableNumber;
    }
}
