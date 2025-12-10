using UnityEngine;

public class Interactable : MonoBehaviour, IInteraction
{
    [SerializeField]
    protected GameObject interactUIObject;

    private bool hasInteracted;
    private void Awake()
    {
        interactUIObject.SetActive(false);
    }

    protected virtual void OnInteract()
    {
    }

    protected virtual void OnStartSee()
    {

    }

    protected virtual void OnStopSeen()
    {

    }


    public void Interact()
    {
        if (hasInteracted) return;

        interactUIObject.SetActive(false);
        OnInteract();
        hasInteracted = true;
    }

    public void OnSeen()
    {
        if (hasInteracted) return;
        interactUIObject.SetActive(true);
        OnStartSee();
    }

    public void OnStopSee()
    {
        if (hasInteracted) return;

        interactUIObject.SetActive(false);
        OnStopSeen();
    }
}
