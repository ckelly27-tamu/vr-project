using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

using TMPro;

public class MusicPlayer : MonoBehaviour
{
    private bool isPlaying = false;
    //private Animator animator;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public GameObject playingVinyl;
    private Vinyl vinylComponent;
    private TrophyFlag flag;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = false;
    }

    void Awake()
    {
        socket.selectEntered.AddListener(OnObjectSnappedIn);
        socket.selectExited.AddListener(OnObjectSnappedOut);
    }

    void OnObjectSnappedIn(SelectEnterEventArgs args)
    {
        playingVinyl = args.interactableObject.transform.gameObject;
        audioSource = playingVinyl.GetComponent<AudioSource>();
        flag = playingVinyl.GetComponent<TrophyFlag>();

        if (audioSource != null)
        {
            VPlay();
        } else
        {
            
        }
        
        if (flag != null)
        {
            flag.RaiseFlag();
        }
    }

    void OnObjectSnappedOut(SelectExitEventArgs args)
    {
        if (audioSource != null) VPause();
        playingVinyl = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void VPlay()
    {
        isPlaying = true;
        //animator.SetBool("IsPlaying", true);
        audioSource.Play();
    }
    void VPause()
    {
        isPlaying = false;
        //animator.SetBool("IsPlaying", false);
        audioSource.Stop();
    }
}
