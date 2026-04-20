using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement")]
    public float speed = 0.5f;
    public float waitTimeAtPoints = 1f;

    private bool waitingAtPoint = false;
    private float waitTimer = 0f;
    private bool movingTowardB = true;
    private float percentMoved = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
