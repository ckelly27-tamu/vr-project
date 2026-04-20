using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VinylPoster : MonoBehaviour
{
    private Vinyl vinylComponent;
    private TrophyFlag flag;
    public GameObject playingVinyl;
    public AudioSource errorSND;
    public AudioSource successSND;

    public int id = 0;
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
        playingVinyl = args.interactableObject.transform.gameObject;
        flag = playingVinyl.GetComponent<TrophyFlag>();
        vinylComponent = playingVinyl.GetComponent<Vinyl>();
        
        if (flag != null)
        {
            if (vinylComponent.id == this.id) {
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
        playingVinyl = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
