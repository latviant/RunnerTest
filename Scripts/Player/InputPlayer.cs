using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoverPlayer))]
public class InputPlayer : MonoBehaviour
{
    [SerializeField] private Joystick joyStick;
    private MoverPlayer _mover;
   
    private void Start()
    {
        _mover = GetComponent<MoverPlayer>();
    }

    private void Update()
    {
        if (joyStick.Vertical > 0)
            _mover.TryMoveUp();

        if (joyStick.Vertical < 0)
            _mover.TryMoveDown();

        if (joyStick.Horizontal < 0)
            _mover.TryMoveLeft();

        if (joyStick.Horizontal >0)
            _mover.TryMoveRight();
    }
}
