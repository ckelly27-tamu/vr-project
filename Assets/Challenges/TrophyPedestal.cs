using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TrophyPedestal : MonoBehaviour
{
    private TrophyFlag flag;
    public GameObject trophy;
    public AudioSource errorSND;
    public AudioSource successSND;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        socket.selectEntered.AddListener(OnObjectSnappedIn);
        socket.selectExited.AddListener(OnObjectSnappedOut);
    }

    void OnObjectSnappedIn(SelectEnterEventArgs args)
    {
        trophy = args.interactableObject.transform.gameObject;
        flag = trophy.GetComponent<TrophyFlag>();
        
        if (flag != null)
        {
            if (trophy.tag == "Trophy") {
                flag.RaiseFlag();
                successSND.Play();
            }
            else{
                //vinylComponent.Reset();
                errorSND.Play();
            }
        }
    }

    void OnObjectSnappedOut(SelectExitEventArgs args)
    {
        trophy = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
