using UnityEngine;

public class PaintingChallenge : MonoBehaviour
{
    public GameObject painting1;
    public GameObject painting2;
    public GameObject painting3;
    public GameObject painting4;
    public GameObject painting5;
    public GameObject painting6;
    public GameObject painting7;
    public GameObject painting8;
    public GameObject painting9;

    public GameObject prize;


    private GameObject rightPainting;
    private Painting rightPaintingScript;
    private AudioSource audioSource = null;

    public AudioSource correctAS;
    public AudioSource incorrectAS;

    private int totalRounds = 3;
    private int goodRounds = 0;
    private bool scramble = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        SelectPainting();
    }

    public void Reshuffle()
    {
        if (audioSource != null) audioSource.Stop();
        if (rightPaintingScript != null) rightPaintingScript.ReleasePainting();
        SelectPainting();
    }

    void SelectPainting()
    {
        int randomInt = Random.Range(1, 9); // Next(min, maxExclusive)

        switch (randomInt)
        {
            case 1:
            default:
            rightPainting = painting1;
            break;

            case 2:
            rightPainting = painting2;
            break;

            case 3:
            rightPainting = painting3;
            break;

            case 4:
            rightPainting = painting4;
            break;

            case 5:
            rightPainting = painting5;
            break;

            case 6:
            rightPainting = painting6;
            break;

            case 7:
            rightPainting = painting7;
            break;

            case 8:
            rightPainting = painting8;
            break;

            case 9:
            rightPainting = painting9;
            break;
        }

        audioSource = rightPainting.GetComponent<AudioSource>();
        if (audioSource != null) audioSource.Play();

        if (scramble) {
            switch (randomInt)
            {
                case 1:
                default:
                rightPainting = painting1;
                break;

                case 2:
                rightPainting = painting2;
                break;

                case 3:
                rightPainting = painting3;
                break;

                case 4:
                rightPainting = painting4;
                break;

                case 5:
                rightPainting = painting5;
                break;

                case 6:
                rightPainting = painting6;
                break;

                case 7:
                rightPainting = painting7;
                break;

                case 8:
                rightPainting = painting8;
                break;

                case 9:
                rightPainting = painting9;
                break;
            }
        }

        rightPaintingScript = rightPainting.GetComponent<Painting>();
        if (rightPaintingScript != null) rightPaintingScript.SelectPainting();
    }

    public void TestPainting(Painting p)
    {
        if (p.id == rightPaintingScript.id)
        {
            correctAS.Play();
            goodRounds++;

            if (goodRounds >= totalRounds)
            {
                prize.SetActive(true);
                if (audioSource != null) audioSource.Stop();
            if (rightPaintingScript != null) rightPaintingScript.ReleasePainting();
            } else { 
                Reshuffle(); 
            }
            
        } else if (goodRounds < totalRounds)
        {
            incorrectAS.Play();
            goodRounds = 0;

            int randomInt = Random.Range(1, 9);
            if (randomInt == 7)
            {
                scramble = true;
            } else
            {
                scramble = false;
            }

            Reshuffle();
        }
    }
}
