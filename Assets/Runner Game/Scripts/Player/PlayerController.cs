using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
	#region Unity Fields
	[SerializeField] float forwardSpeed;
	[SerializeField] float sideSpeed;
    [SerializeField] Joystick gameJoystick;
    #endregion
    #region Fields
    Vector3 _moveDirection;
    #endregion
    #region Unity Methods
    protected override void Start()
    {
        base.Start();
        isControlEnabled = true;
        isPlayedDead = false;
    }
    private void FixedUpdate()
    {
        if (!isControlEnabled || isPlayedDead)
            return;

        _moveDirection.z = forwardSpeed * Time.fixedDeltaTime;
        _moveDirection.y = 0f;
        _moveDirection.x = gameJoystick.Direction.x * sideSpeed * Time.fixedDeltaTime;
        rb.AddForce(_moveDirection, ForceMode.VelocityChange);
    }
    #endregion
}
