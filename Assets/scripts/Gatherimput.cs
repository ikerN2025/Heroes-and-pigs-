using UnityEngine;
using UnityEngine.InputSystem;
public class Gatherimput : MonoBehaviour
{
    //Declarando una variable privada de tipo Imput Acttions
    private InputSystem_Actions controls;
    [SerializeField] private float _valueX;
    public float ValueX { get => _valueX; }

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += StarMove;
        controls.Player.Move.canceled += StopMove;
    }
    private void StarMove(InputAction.CallbackContext context)
    {
        _valueX = context.ReadValue<float>();
    }
    private void StopMove(InputAction.CallbackContext context)
    {
        _valueX = 0;
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.Move.performed -= StarMove;
        controls.Player.Move.canceled -= StopMove;
    }
}