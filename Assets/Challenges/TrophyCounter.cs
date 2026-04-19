using UnityEngine;
using TMPro;

public class TrophyCounter : MonoBehaviour
{
    public int RequiredFlags = 5;
    public GameObject trophyObject;
    public TMP_Text textMeshPro;

    private int currentFlags = 0;

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
        textMeshPro.text = "" + currentFlags + "/" + RequiredFlags;
    }

    public void RaiseFlag()
    {
        currentFlags++;
        if (currentFlags >= RequiredFlags)
        {
            trophyObject.SetActive(true);
        }

        textMeshPro.text = "" + currentFlags + "/" + RequiredFlags;
    }
}
