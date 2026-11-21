using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        Vector3 mousePositon = Mouse.current.position.value;

        Vector3 screenPosition = mousePositon;
        screenPosition.z = 10;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
    }
}
