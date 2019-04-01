using UnityEngine;
using UnityEngine.Events;

public class MultipleGameEventsListener : MonoBehaviour , IGameEventListener {

    public GameEvent[] events;
    public UnityEvent handler;

    private void OnEnable()
    {
        foreach(var anEvent in events)
            anEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        foreach (var anEvent in events)
            anEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        handler.Invoke();
    }
}