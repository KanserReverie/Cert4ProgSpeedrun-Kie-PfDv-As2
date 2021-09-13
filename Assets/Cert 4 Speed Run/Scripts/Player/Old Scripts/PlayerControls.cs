using UnityEngine.SceneManagement;
using UnityEngine;

namespace BladeRapid
{
    public class PlayerControls : MonoBehaviour
    {
        [Header("Speed Vars")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, jumpSpeed;
        private float _gravity = 10.0f;
        private Vector3 _moveDir;
        private CharacterController _charC;

        private void Awake()
        {
            _charC = GetComponent<CharacterController>();
        }

        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if(_charC.isGrounded)
            {
                // If holding down space
                if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.Space))
                {
                    moveSpeed = runSpeed;
                }
                else if(!Input.GetKey(KeyCode.UpArrow) ||Input.GetKey(KeyCode.Space))
                {
                    moveSpeed = walkSpeed;
                }

                _moveDir = transform.TransformDirection(new Vector3(moveSpeed, 0, 0));
                if(Input.GetKeyUp(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
        
        private void OnControllerColliderHit(ControllerColliderHit _collision)
        {
            if(_collision.gameObject.CompareTag("Finish"))
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
        }
        
    }
}