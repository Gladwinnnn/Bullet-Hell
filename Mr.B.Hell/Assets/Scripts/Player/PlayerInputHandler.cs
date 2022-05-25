using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMouseInput { get; private set; }
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool PrimaryAttackInput { get; private set; }
    public bool SecondaryAttackInput { get; private set; }
    public bool SpecialAttackInput { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PrimaryAttackInput = true;
        }

        if (context.canceled)
        {
            PrimaryAttackInput = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SecondaryAttackInput = true;
        }

        if (context.canceled)
        {
            SecondaryAttackInput = false;
        }
    }

    public void OnSpecialAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SpecialAttackInput = true;
        }

        if (context.canceled)
        {
            SpecialAttackInput = false;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {

        RawMouseInput = context.ReadValue<Vector2>();

        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            RawMouseInput = cam.ScreenToWorldPoint((Vector3)RawMouseInput) - transform.position;
        }

        //print("mevi" + RawMouseInput);
        //Vector3 mousePosition = Input.mousePosition;
        //RawMouseInput = Camera.main.ScreenToWorldPoint(mousePosition);

        //print(RawMouseInput);
    }
}
