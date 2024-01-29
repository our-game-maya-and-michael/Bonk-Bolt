using UnityEngine;
using UnityEngine.InputSystem;

/**
 *  This component allows the player to add force to its object using the arrow keys.
 *  Works with a 3D RigidBody.
 */
[RequireComponent(typeof(Rigidbody))]
public class KeyboardForceAdder : MonoBehaviour {
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce = 5f;
    [SerializeField] InputAction moveRL;

    [Tooltip("The foward and backword force that the player's feet use for walking, in newtons.")]
    [SerializeField] InputAction moveFB;

    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] InputAction jump;

    [Range(0,1f)]
    [SerializeField] float slowDownAtJump = 0.5f;


    void OnValidate() {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (jump == null)
            jump = new InputAction(type: InputActionType.Button);
        if (jump.bindings.Count == 0)
            jump.AddBinding("<Keyboard>/space");

        if (moveRL == null)
            moveRL = new InputAction(type: InputActionType.Button);
        if (moveRL.bindings.Count == 0)
            moveRL.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/rightArrow")
                .With("Negative", "<Keyboard>/leftArrow");

        if (moveFB == null)
            moveFB = new InputAction(type: InputActionType.Button);
        if (moveFB.bindings.Count == 0)
            moveFB.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/upArrow")
                .With("Negative", "<Keyboard>/downArrow");
    }

    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private ForceMode walkForceMode = ForceMode.Force;
    private ForceMode jumpForceMode = ForceMode.Impulse;
    private bool playerWantsToJump = false;
    private void OnEnable() {
        moveRL.Enable();
        moveFB.Enable();
        jump.Enable();
    }

    private void OnDisable() {
        moveRL.Disable();
        moveFB.Disable();
        jump.Disable();
    }

    private void Update() {
        // Keyboard events are checked each frame, so we should check them in Update.
        if (jump.WasPressedThisFrame())
            playerWantsToJump = true;
    }

    /*
     * Note that updates related to the physics engine should be done in FixedUpdate and not in Update!
     */
    private void FixedUpdate() {

            float rightLeft = moveRL.ReadValue<float>();
            rb.AddForce(new Vector3(rightLeft * walkForce, 0, 0), walkForceMode);
        float fb = moveFB.ReadValue<float>();
        rb.AddForce(new Vector3(0, 0, fb * walkForce), walkForceMode);
        if (playerWantsToJump) {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!
                rb.velocity = new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
                playerWantsToJump = false;
            }
        
    }
}
