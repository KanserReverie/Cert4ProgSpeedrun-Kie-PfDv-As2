using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CertIVSpeedrun.Environment;
using System;
using System.Runtime.CompilerServices;

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
            [SerializeField] private bool useButtonDown= false;

            [SerializeField] private Button activateButton;

            public ActivatePoint currentPointActive; 
            
        
        
            void Start()
            {
                currentPointActive = null;
                additionalJumps = defaultAdditionalJumps;
                activateButton.interactable = false;
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


            // If the point is now active then do the thing.
            public void ThisPointIsActive(ActivatePoint _currentActivePoint)
            {
                currentPointActive = _currentActivePoint;
                activateButton.interactable = true;
            }

            // For when the Activate Button is hit.
            public void ActivateButton()
            {
                if(currentPointActive != null)
                {
                    currentPointActive.ActivateThisPoint();
                }
                activateButton.interactable = false;
            }
            
            // If the point is now active then do the thing.
            public void LeaveActivePoint()
            {
                activateButton.interactable = false;
                currentPointActive = null;
            }

            // This will be for the move left button.
            public void MoveLeftButton()
            {
                leftButtonDown = true;
            }
            // This will be for the move left button release.
            public void MoveLeftButtonUp()
            {
                leftButtonDown = false;
            }
            
            // This will be for the move right button.
            public void MoveRightButton()
            {
                rightButtonDown = true;
            }
            // This will be for the move right button release.
            public void MoveRightButtonUp()
            {
                rightButtonDown = false;
            }
            // This will be for the jump button.
            public void JumpButton()
            {
                jumpButtonDown = true;
            } 
            // This will be for the jump button release.
            public void JumpButtonUp()
            {
                jumpButtonDown = false;
            } 

            public void Move()
            {
                float x = Input.GetAxis("Horizontal");
                if(leftButtonDown || rightButtonDown)
                {
                    x = 0;
                    
                    if (leftButtonDown)
                    {
                        x =+ -1;
                    }
                    
                    if (rightButtonDown)
                    {
                        x =+ 1;
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

                    jumpButtonDown = false;
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