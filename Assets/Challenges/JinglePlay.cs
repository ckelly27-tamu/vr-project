using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class JinglePlay : MonoBehaviour
{
    public AudioSource audioSource;
    
    private XRSimpleInteractable interactable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        audioSource.Play();
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnButtonPressed);
    }
}
