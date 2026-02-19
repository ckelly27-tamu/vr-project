using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    private bool isPlaying = false;
    private Animator animator;
    public GameObject vinyl;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI buttonText;
    public Button PlayPauseButton;
    public GameObject musicObject;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = musicObject.GetComponent<AudioSource>();
        animator = vinyl.GetComponent<Animator>();
        PlayPauseButton.onClick.AddListener(PlayPause);
        isPlaying = true;
        VPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayPause()
    {
        if (isPlaying)
        {
            isPlaying = false;
            VPause();
        } else
        {
            isPlaying = true;
            VPlay();
        }
    }

    void VPlay()
    {
        animator.SetBool("IsPlaying", true);
        statusText.text = "Playing";
        buttonText.text = "Pause";
        audioSource.Play();
    }
    void VPause()
    {
        animator.SetBool("IsPlaying", false);
        statusText.text = "Paused";
        buttonText.text = "Play";
        audioSource.Pause();
    }
}
