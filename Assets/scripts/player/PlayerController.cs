using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    public float speed = 10;
    CharacterController characterController;


    void Awake()
    {
        controls = new PlayerControls();
        characterController = GetComponent<CharacterController>();
        controls.Player.Move.performed += context => SendDebug(context.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void SendDebug(Vector2 coordinates)
    {
        Debug.Log("Thumb-stick coordinates = " + coordinates);
    }

    void Update()
    {
        float vertical = Physics.gravity.y * Time.deltaTime;
        Vector2 move = controls.Player.Move.ReadValue<Vector2>() * speed * Time.deltaTime;
        Vector3 movement = new Vector3(move.x, vertical, move.y);
        characterController.Move(movement);
    }
}
