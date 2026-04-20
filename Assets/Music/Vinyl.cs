using UnityEngine;

public class Vinyl : MonoBehaviour
{
    public int id = 0;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
