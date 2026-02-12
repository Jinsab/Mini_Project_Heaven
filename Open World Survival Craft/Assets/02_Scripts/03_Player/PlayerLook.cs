using UnityEngine;
using UnityEngine.InputSystem;

public enum LookDirection
{
    Down,
    Up,
    Side
}

public class PlayerLook : MonoBehaviour
{
    public LookDirection CurrentLookDirection { get; private set; }

    private Camera mainCam;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        mainCam = Camera.main;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        UpdateLookDirection();
    }

    void UpdateLookDirection()
    {
        Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());

        Plane groundPlane = new Plane(Vector3.up, transform.position);
        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorld = ray.GetPoint(distance);
            Vector3 dir = mouseWorld - transform.position;

            dir.y = 0;

            Vector2 flatDir = new Vector2(dir.x, dir.z).normalized;

            if (Mathf.Abs(flatDir.x) > Mathf.Abs(flatDir.y))
            {
                CurrentLookDirection = LookDirection.Side;
                spriteRenderer.flipX = flatDir.x > 0;
            }
            else
            {
                if (flatDir.y > 0)
                    CurrentLookDirection = LookDirection.Up;
                else
                    CurrentLookDirection = LookDirection.Down;
            }
        }

        Debug.Log(CurrentLookDirection);
    }
}
