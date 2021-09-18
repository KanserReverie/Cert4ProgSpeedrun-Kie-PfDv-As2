using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Player
{
    public class PlayerControlsManager : MonoBehaviour
    {
        // Its now a singleton
    #region Singleton Code
        private static PlayerControlsManager _instance;
        public static PlayerControlsManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    #endregion
        
            public Rigidbody myRigidbody;
        
            public float speed = 2;
            public float jumpForce = 4;
        
            public float fallMultiplier = 2.5f;
            public float lowJumpMultiplier = 2f;
        
            public bool isGrounded = false;
        
            public float rememberGroundedFor;
            float lastTimeGrounded;
        
            public int defaultAdditionalJumps = 1;
            int additionalJumps;
            public bool isReady=false;

            [SerializeField] private bool leftButtonDown = false;
            [SerializeField] private bool rightButtonDown = false;
            [SerializeField] private bool jumpButtonDown= false;
            
        
        
            void Start()
            {
                additionalJumps = defaultAdditionalJumps;
            }
        
            void Update()
            {
                if(isReady)
                {
                    Move();
                    Jump();
                    BetterJump();
                    CheckIfGrounded();
                }
            }


            // This will be for the move left button.
            public void MoveLeftButton()
            {
                leftButtonDown = true;
            }
            public void MoveLeftButtonUp()
            {
                leftButtonDown = false;
            }
            
            // This will be for the move right button.
            public void MoveRightButton()
            {
                rightButtonDown = true;
            }
            // This will be for the move right button.
            public void MoveRightButtonUp()
            {
                rightButtonDown = false;
            }
            // This will be for the jump button.
            public void JumpButton()
            {
                jumpButtonDown = true;
            } 
            // This will be for the jump button.
            public void JumpButtonUp()
            {
                jumpButtonDown = false;
            } 

            public void Move()
            {
                float x = Input.GetAxis("Horizontal");
                if(leftButtonDown || rightButtonDown)
                {
                    if(leftButtonDown && rightButtonDown)
                    {
                        x = 0;
                    }
                    else if (leftButtonDown)
                    {
                        x = -1;
                    }
                    else if (rightButtonDown)
                    {
                        x = 1;
                    }
                }
                float moveBy = x * speed;
                myRigidbody.velocity = new Vector3(moveBy, myRigidbody.velocity.y,0);
            }

            public void Jump()
            {
                if(Input.GetButtonDown("Jump") || jumpButtonDown)
                {
                    if(isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)
                    {
                        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                        additionalJumps--;
                    }
                }
            }

            public void BetterJump() 
            {
                if (myRigidbody.velocity.y < 0)
                {
                    Vector2 HoriVerti = Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
                    myRigidbody.velocity += new Vector3(HoriVerti.x, HoriVerti.y, 0);
                }
                else if (myRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
                {
                    Vector2 HoriVerti2 = Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
                    myRigidbody.velocity += new Vector3(HoriVerti2.x, HoriVerti2.y, 0);
                }   
            }
        
            void CheckIfGrounded() {
        
                if (isGrounded) 
                {
                    additionalJumps = defaultAdditionalJumps;
                }
                else 
                {
                    if (isGrounded) 
                    {
                        lastTimeGrounded = Time.time;
                    }
                    isGrounded = false;
                }
            }
    }
}