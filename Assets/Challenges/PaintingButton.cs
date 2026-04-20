using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PaintingButton : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    public PaintingChallenge paintingChallenge;
    public Painting representedPainting;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Button Pressed!");

        paintingChallenge.TestPainting(representedPainting);
        // Your logic here
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnButtonPressed);
    }

}
