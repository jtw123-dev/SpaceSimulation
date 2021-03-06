using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            _rotSpeed = 0;
            transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            _rotSpeed = 100;
        }

        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
     
        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed+=20;
            if (_currentSpeed > 100)
            {
                _currentSpeed = 100;
            }
        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed-=20;
            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }
        }//decrease speed

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeed * Time.deltaTime);


        
        
        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }
}
