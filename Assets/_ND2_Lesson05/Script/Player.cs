using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("à⁄ìÆê›íË")]
    [SerializeField] private float _moveSpeed = 5.0f;

    [Header("êUÇËå¸Ç´ê›íË")]
    [SerializeField] private Transform _lookTarget;

    [Header("ÉVÉáÉbÉgê›íË")]
    [SerializeField] private GameObject _bulletPrehub;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotPower;


    private Vector3 _moveVector = new Vector3(0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movwement();
        LookAt();
        Shot();
    }
    public void Movwement()
    {
        _moveVector = new Vector3(0, 0, 0);

        if (Keyboard.current.wKey.IsPressed())
        {
            _moveVector = new Vector3(0, 0, 1);
        }
        if (Keyboard.current.aKey.IsPressed())
        {
            _moveVector = new Vector3(-1, 0, 0);
        }
        if (Keyboard.current.sKey.IsPressed())
        {
            _moveVector = new Vector3(0, 0, -1);
        }
        if (Keyboard.current.dKey.IsPressed())
        {
            _moveVector = new Vector3(1, 0, 0);
        }
        transform.Translate(_moveVector * _moveSpeed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, _moveVector, Color.green, 0, false);
    }
    public void LookAt()
        {
        transform.LookAt(_lookTarget, Vector3.up);

        Debug.DrawRay(transform.position, transform.forward, Color.blue, 0, false);
        }

    public void Shot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        { 
            GameObject bullet = Instantiate(_bulletPrehub, _shotPoint.position, _shotPoint.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(_shotPoint.forward * _shotPower, ForceMode.Impulse);

        Destroy(bullet, 5.0f);
     }
    }
}
