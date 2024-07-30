using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    private float halfHeight, halfWidth;

    public BoxCollider2D boundBox;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    private void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    void Update()
    {
        CameraBoundsController();
    }

    private void CameraBoundsController()
    {
        if (player != null)
        {
            transform.position = new Vector3
                (Mathf.Clamp(player.transform.position.x, boundBox.bounds.min.x + halfWidth, boundBox.bounds.max.x - halfWidth),
                Mathf.Clamp(player.transform.position.y, boundBox.bounds.min.y + halfHeight, boundBox.bounds.max.y - halfHeight),
                transform.position.z);
        }
    }
}
