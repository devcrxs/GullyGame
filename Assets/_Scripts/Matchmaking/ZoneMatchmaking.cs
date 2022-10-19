using UnityEngine;
public class ZoneMatchmaking : MonoBehaviour
{
    [SerializeField] private string nameSceneLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MatchmakingManager>().SceneLoad = nameSceneLoad;
            GameManager.instance.ShowMatchmaking();
        }
    }
    
}
