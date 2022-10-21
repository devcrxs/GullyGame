using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;
public enum TypeRooms
{
    Football,
    Baseball,
    AmericanFootball,
    Tennis,
    Golf,
    Basketball
}
public class MatchmakingManager : MonoBehaviourPunCallbacks
{
    public TypeRooms typeRooms;
    public string roomSearch = "minigame";
    private string _sceneLoad;
    public string SceneLoad
    {
        set => _sceneLoad = value;
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
        PhotonNetwork.JoinRandomRoom(new ExitGames.Client.Photon.Hashtable(){{roomSearch,typeRooms}},2);
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
            CustomRoomPropertiesForLobby = new string[]{roomSearch},
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable(){{roomSearch,typeRooms}},
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
            PhotonNetwork.LoadLevel(_sceneLoad);
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
