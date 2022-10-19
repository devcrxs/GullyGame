using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundAll;
    [SerializeField] private Transform canvasFindMatchmaking;
    [SerializeField] private Transform canvasStopMatchmaking;
    private void Start()
    {
        backgroundAll.SetActive(false);
        GameManager.instance.OnShowMatchmaking += ShowMatchmaking;
        GameManager.instance.OnHideMatchmaking += HideMatchmaking;
        GameManager.instance.OnFindMatchmaking += FindMatchmaking;
        GameManager.instance.OnStopMatchmaking += StopMatchmaking;
    }

    private void ShowMatchmaking()
    {
        FindObjectOfType<Joystick>().IsTouchJoystick = false;
        FindObjectOfType<Joystick>().transform.GetChild(0).
                transform.GetComponent<RectTransform>().anchoredPosition =Vector3.zero;
        backgroundAll.SetActive(true);
        canvasFindMatchmaking.gameObject.SetActive(true);
    }

    private void HideMatchmaking()
    {
        FindObjectOfType<Joystick>().IsTouchJoystick = true;
        backgroundAll.SetActive(false);
        canvasFindMatchmaking.gameObject.SetActive(false);
    }

    private void StopMatchmaking()
    {
        backgroundAll.SetActive(true);
        canvasStopMatchmaking.gameObject.SetActive(false);
        canvasFindMatchmaking.gameObject.SetActive(true);
    }

    private void FindMatchmaking()
    {
        backgroundAll.SetActive(true);
        canvasStopMatchmaking.gameObject.SetActive(true);
        canvasFindMatchmaking.gameObject.SetActive(false);
    }
}
