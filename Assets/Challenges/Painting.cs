using UnityEngine;

public class Painting : MonoBehaviour
{
    private bool isRightPainting = false;
    public int id = 0;
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
        
    }

    public void SelectPainting()
    {
        isRightPainting = true;
    }

    public void ReleasePainting()
    {
        isRightPainting = false;
    }

    public bool GetIsRightPainting()
    {
        return isRightPainting;
    }

    public void TestPainting()
    {
        
    }
}
