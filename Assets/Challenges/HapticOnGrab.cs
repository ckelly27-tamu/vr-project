using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections;

public class HapticOnGrab : MonoBehaviour
{
    [Range(0f, 1f)]
    public float amplitude = 0.5f;
    public float duration = 0.2f;
    public int id = 0;

    private Vector3 originalLocation;
    private Quaternion originalRotation;
    public TrophyFlag flag;
    private UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticImpulsePlayer hapticImpulse;

    void Awake()
    {
        originalLocation = transform.position;
        originalRotation = transform.rotation;
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
                StartCoroutine(HapticPulsePattern(amplitude, 0.1f, 0.1f, id + 2, hapticImpulse));
            }
        }
    }

    public void Warn()
    {
        if (hapticImpulse != null)
        {
            hapticImpulse.SendHapticImpulse(1.0f, 4.0f);
        }

        transform.position = originalLocation;
        transform.rotation = originalRotation;
    }

    public void Take()
    {
        if (hapticImpulse != null)
        {
            hapticImpulse.SendHapticImpulse(0.25f, 0.5f);
        }
        flag.RaiseFlag();
    }

    IEnumerator HapticPulsePattern(float amplitude, float pulseDuration, float restDuration, int pulseCount, UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticImpulsePlayer controller)
    {
        for (int i = 0; i < pulseCount; i++)
        {
            controller.SendHapticImpulse(amplitude, pulseDuration);
            yield return new WaitForSeconds(pulseDuration + restDuration);
        }
    }
}