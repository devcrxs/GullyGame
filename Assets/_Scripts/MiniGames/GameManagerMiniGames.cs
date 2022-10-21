using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerMiniGames : MonoBehaviourPunCallbacks
{
    private bool isWin;
    public static GameManagerMiniGames instance;
    public GameObject canvasWin;
    public event Action OnGoMainScene;
    public Transform point1;
    public Transform point2;
    public GameObject gully1;
    public GameObject gully2;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        canvasWin.SetActive(false);
        if (gully1 != null && gully2 != null && point1 != null && point2 != null)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(gully1.name, point1.position,new Quaternion(0,0,0,0));
            }
            else
            {
                PhotonNetwork.Instantiate(gully2.name, point2.position, new Quaternion(0,180,0,0));

            }
        }
        
    }

    public void GoMainScene()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadSceneAsync(0);
    }
    private void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.PlayerList.Length <= 1 && !isWin)
            {
                isWin = true;
                canvasWin.SetActive(true);
            }
        }
       
    }
}
