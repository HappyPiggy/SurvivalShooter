using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int camRayLength = 100;

    private Rigidbody rb;
    private Vector3 movement;
    private int floorMask;
    private Animator animator;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rb=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0.0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
       // Debug.Log(movement);
        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
       
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;


        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
           // Debug.Log("test");
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        //Debug.Log(walking);
        animator.SetBool("IsWalking", walking);
    }
}
