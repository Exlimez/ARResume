using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener {

    public GameEvent anEvent;
    public UnityEvent handler;

    private void OnEnable()
    {
        anEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        anEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        handler.Invoke();
    }
}
