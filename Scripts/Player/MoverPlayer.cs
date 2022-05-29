using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHight;
    [SerializeField] private float _minHight;
    [SerializeField] private float _minLeft;
    [SerializeField] private float _minRight;
    [SerializeField] private Player _player;

    public float _currentMoveSpeed;
    private Vector3 _targetPosition;

    public float CurrentMoveSpeed => _currentMoveSpeed;

    private void Start()
    {
        _targetPosition = transform.position;
        _currentMoveSpeed = _maxMoveSpeed;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _currentMoveSpeed * Time.deltaTime);

        AddSpeed();
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHight)
        SetNextPositionY(_stepSize);
    }

    public void TryMoveDown()
    {
        if(_targetPosition.y > _minHight)
        SetNextPositionY(-_stepSize);
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _minLeft)
            SetNextPositionX(-_stepSize);
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _minRight)
            SetNextPositionX(_stepSize);
    }

    private void SetNextPositionY(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    private void SetNextPositionX(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }

    private void OnEnable()
    {
        _player.SpeedChanged += OnSpeedChanged;
    }

    private void OnSpeedChanged(int value)
    {
        _currentMoveSpeed -= value;
    }

    private void AddSpeed()
    {
        float additionSpeed = Time.deltaTime / 10;

        if (_currentMoveSpeed < _maxMoveSpeed)
            _currentMoveSpeed += additionSpeed;
    }
}
