using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
     SteamVR_Action_Vector2 locomotion = null;

    [SerializeField]
    CharacterController controller = null;

    [SerializeField]
    Camera camera;

    public float speed = 1f;
    private bool checkWalk = false;
    private bool IsGrounded;
    private Vector3 PlayerVelocity = Vector3.zero;
    public float gravity = -9.8f;

    

    public void ProcessMove(Vector2 input)
    {
        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Vector3 cameraRight = camera.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDir = Vector3.zero;
        moveDir = cameraForward * input.y + cameraRight * input.x;

        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        

        PlayerVelocity.y += gravity * Time.deltaTime;
        if (IsGrounded && PlayerVelocity.y < 0)
            PlayerVelocity.y = -2.0f;

        controller.Move(PlayerVelocity * Time.deltaTime);
    }


    private void Awake()
    {
        locomotion = SteamVR_Actions.default_locomotion;
        controller = GetComponent<CharacterController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        if (locomotion.axis.magnitude > 0.1f)
        {
            Vector2 dir = locomotion.axis;
            ProcessMove(dir);
        }

    }
}
