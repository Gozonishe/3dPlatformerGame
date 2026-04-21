using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement")]
    public float speedMultiplier = 0.25f;
    public float waitTimeAtPoints = 3f;

    private bool waitingAtPoint = false;
    private float waitTimer = 0;
    private bool movingTowardB = true;
    private float percentMoved = 0;

    void Start()
    {
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitingAtPoint)
        {
            Wait();
        }
        else
        {
            Move();
        }
    }

    private void Wait()
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= waitTimeAtPoints)
        {
            waitingAtPoint = false;
            waitTimer = 0;
        }
    }

    private void Move()
    {
        if (movingTowardB)
        {
            percentMoved += speedMultiplier * Time.deltaTime;
            if (percentMoved >= 1)
            {
                movingTowardB = false;
                waitingAtPoint = true;
            }
        } else
        {
            percentMoved -= speedMultiplier * Time.deltaTime;
            if (percentMoved <= 0)
            {
                movingTowardB = true;
                waitingAtPoint = true;
            }
        }
        transform.position = Vector3.Lerp(pointA.position, pointB.position, percentMoved);
    }
}
