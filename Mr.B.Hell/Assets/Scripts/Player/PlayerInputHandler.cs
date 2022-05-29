using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInput playerInput { get; private set; }
    private Camera cam;
    private CursorManager cursorManager;

    public Vector2 RawMouseInput { get; private set; }
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool PrimaryAttackInput { get; private set; }
    public bool SecondaryAttackInput { get; private set; }
    public bool SpecialAttackInput { get; private set; }

    public Vector2 EditedMouseInput { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
        cursorManager = FindObjectOfType<CursorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        //RawMouseInput = new Vector2(Mathf.Clamp(RawMouseInput.x, -Screen.width, Screen.width), Mathf.Clamp(RawMouseInput.y, -Screen.height, Screen.height));


        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            EditedMouseInput = cam.ScreenToWorldPoint(RawMouseInput);
        }

        // make else for the controller 

        cursorManager.SetCursorPos(EditedMouseInput);

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

        //cursorManager.SetCursorPos(cam.ScreenToWorldPoint(RawMouseInput));

        //if (playerInput.currentControlScheme == "Keyboard&Mouse")
        //{
        //    RawMouseInput = cam.ScreenToWorldPoint(RawMouseInput);
        //}

        //print("mevi" + RawMouseInput);
        //Vector3 mousePosition = Input.mousePosition;
        //RawMouseInput = Camera.main.ScreenToWorldPoint(mousePosition);

        //print(RawMouseInput);
    }
}
