using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;

public class HandTriggerZone : MonoBehaviour
{
    [Range(0f, 1f)]
    public float amplitude = 0.5f;
    public float duration = 0.2f;
    public int id = 0;

    public event Action<XRBaseInputInteractor> OnHandEntered;
    public event Action<XRBaseInputInteractor> OnHandExited;

    public AudioSource testSound;
    public AudioSource errorSound;
    public TMP_Text textMeshPro;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        var interactor = obj.GetComponent<XRBaseInputInteractor>();
        if (interactor != null) {
            var hapticImpulse = interactor.GetComponent<UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticImpulsePlayer>();
            if (hapticImpulse != null)
            {
                hapticImpulse.SendHapticImpulse(amplitude, duration);
            }
            textMeshPro.text = "Enter: " + other.gameObject.name;
            //OnHandEntered?.Invoke(interactor);
        }   
        else
        {
            var food = obj.GetComponent<HapticOnGrab>();
            if (food.id == this.id)
            {
                food.Take();
                obj.SetActive(false);
                testSound.Play();
            } else
            {
                food.Warn();
                errorSound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var obj = other.gameObject;
        var interactor = obj.GetComponent<XRBaseInputInteractor>();
        if (interactor != null) {
            
            textMeshPro.text = "Exit: " + obj.name;
            OnHandExited?.Invoke(interactor);
        } 
    }
}
