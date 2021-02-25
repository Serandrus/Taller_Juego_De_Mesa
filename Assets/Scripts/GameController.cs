using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPun
{
    [SerializeField]
    private Transform[] spawn_Point = null;

    private void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount;

        PhotonNetwork.Instantiate("Jugador", spawn_Point[i].position, spawn_Point[i].rotation);
    }
}
