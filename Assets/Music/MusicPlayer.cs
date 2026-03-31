using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    private bool isPlaying = false;
    private Animator animator;
    public GameObject animatedVinyl;
    public GameObject playingVinyl;
    private Vinyl vinylComponent;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = false;
    }

    void Awake()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        playingVinyl = other.gameObject;
        audioSource = playingVinyl.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            VPlay();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (playingVinyl == other.gameObject)
        {
            VPause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void VPlay()
    {
        isPlaying = true;
        animator.SetBool("IsPlaying", true);
        audioSource.Play();
    }
    void VPause()
    {
        isPlaying = false;
        animator.SetBool("IsPlaying", false);
        audioSource.Stop();
    }
}
