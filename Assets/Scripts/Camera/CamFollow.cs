using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public float speed;
    public Transform PlayerPos;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - PlayerPos.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = PlayerPos.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
