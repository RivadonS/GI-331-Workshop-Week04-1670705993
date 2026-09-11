using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField]
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction interactAction;

    private void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }

    public void Jump()
    {
        Debug.Log("Jump"); // Now unambiguously uses UnityEngine.Debug
    }

    private void OnEnable()
    {
        interactAction.started += OnInteract;
    }

    private void OnDisable()
    {
        interactAction.started -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Interact();
    }

    public void Interact()
    {
        Debug.Log("Interact"); // Now unambiguously uses UnityEngine.Debug
    }
}