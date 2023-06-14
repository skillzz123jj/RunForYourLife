using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float height = 2f;

    private Vector3 offset;

    void Start()
    {
        offset = player.forward * distance;
        offset.y = height;
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
