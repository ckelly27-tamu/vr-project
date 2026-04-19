using UnityEngine;

public class TrophyFlag : MonoBehaviour
{
    public TrophyCounter tc;
    private bool raised = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseFlag()
    {
        if (!raised) tc.RaiseFlag();
        raised = true;
    }
}
