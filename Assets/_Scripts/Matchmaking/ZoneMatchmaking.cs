using Photon.Pun;
using UnityEngine;
public class ZoneMatchmaking : MonoBehaviour
{
    [SerializeField] private TypeRooms typeRoom;
    [SerializeField] private string nameSceneLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MatchmakingManager>().SceneLoad = nameSceneLoad;
            FindObjectOfType<MatchmakingManager>().typeRooms = typeRoom;
            PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable()
                { { "minigame", typeRoom } });
            GameManager.instance.ShowMatchmaking();
        }
    }
    
}
