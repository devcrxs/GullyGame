using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;
public class MatchmakingManager : MonoBehaviourPunCallbacks
{
    private string sceneLoad;
    public string SceneLoad
    {
        set => sceneLoad = value;
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        GameManager.instance.OnFindMatchmaking += FindMatchmaking;
        GameManager.instance.OnStopMatchmaking += StopMatchmaking;
    }

    private void StopMatchmaking()
    {
        PhotonNetwork.LeaveRoom();
    }

    private void FindMatchmaking()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        MakeRoom();
    }

    private void MakeRoom()
    {
        int randomNameRoom = Random.Range(0, 5000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom("RoomName: " + randomNameRoom, roomOptions);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneLoad);
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
