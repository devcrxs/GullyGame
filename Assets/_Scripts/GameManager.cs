using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action OnShowMatchmaking;
    public event Action OnHideMatchmaking;
    public event Action OnFindMatchmaking;
    public event Action OnStopMatchmaking;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ShowMatchmaking()
    {
        OnShowMatchmaking?.Invoke();
    }

    public void HideMatchmaking()
    {
        OnHideMatchmaking?.Invoke();
    }
    public void FindMatchmaking()
    {
        OnFindMatchmaking?.Invoke();
    }

    public void StopMatchmaking()
    {
        OnStopMatchmaking?.Invoke();
    }
}
