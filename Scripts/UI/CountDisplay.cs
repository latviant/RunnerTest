using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private Player _player;
    private float _countDistance;
    private int _countDisplay;
    

    private void Start()
    {
        _countDistance = 0;
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(_player.TryGetComponent<MoverPlayer>(out MoverPlayer mover))
        {
            _countDistance += Time.deltaTime * mover.CurrentMoveSpeed / 10;
            _countDisplay = (int)_countDistance;
            _counter.text = _countDisplay.ToString();
        }     
    }
}
