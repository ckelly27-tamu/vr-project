using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HapticOnGrab : MonoBehaviour
{
    [Range(0f, 1f)]
    public float amplitude = 0.5f;
    public float duration = 0.2f;
    public int id = 0;

    private Vector3 originalLocation;
    private Quaternion originalRotation;

    private UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticImpulsePlayer hapticImpulse;

    void Awake()
    {
        originalLocation = gameObject.location;
        originalRotation = gameObject.rotation;
    }
    private void OnEnable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // XRI v3: cast to XRBaseInputInteractor and use HapticImpulsePlayer
        var interactor = args.interactorObject as XRBaseInputInteractor;
        if (interactor != null)
        {
            hapticImpulse = interactor.GetComponent<UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticImpulsePlayer>();
            if (hapticImpulse != null)
            {
                hapticImpulse.SendHapticImpulse(amplitude, duration);
            }
        }
    }

    public void Warn()
    {
        if (hapticImpulse != null)
        {
            hapticImpulse.SendHapticImpulse(1.0f, 4.0f);
        }

        gameObject.location = originalLocation;
        gameObject.rotation = originalRotation;
    }

    public void Take()
    {
        if (hapticImpulse != null)
        {
            hapticImpulse.SendHapticImpulse(0.25f, 0.5f);
        }
    }
}