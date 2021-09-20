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
            public bool leftground = false;
            public float rememberGroundedFor;
            private float lastTimeGrounded;
            public int defaultAdditionalJumps = 1;
            private int additionalJumps;
            public bool isReady=false;

            [SerializeField] private bool leftButtonDown = false;
            [SerializeField] private bool rightButtonDown = false;

            [SerializeField] private Button activateButton;

            public ActivatePoint currentPointActive;
            private bool pointActive;
            private bool jumpingNow= false;
            
        
        
            void Start()
            {
                pointActive = false;
                currentPointActive = null;
                additionalJumps = defaultAdditionalJumps;
                activateButton.interactable = false;
            }
        
            void Update()
            {
                if(isReady)
                {
                    Move();
                    if(Input.GetButtonDown("Jump")) {Jump();}
                    BetterJump();
                    CheckIfGrounded();
                    CheckButtonActivation();
                    Quit();
                }
            }

            private void Quit()
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
                }
            }

            private void CheckButtonActivation()
            {
                if(pointActive)
                {
                    if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Submit"))
                    {
                        ActivateButton();
                    }
                }
            }


            // If the point is now active then do the thing.
            public void ThisPointIsActive(ActivatePoint _currentActivePoint)
            {
                currentPointActive = _currentActivePoint;
                activateButton.interactable = true;
                pointActive = true;
            }

            // For when the Activate Button is hit.
            public void ActivateButton()
            {
                if(currentPointActive != null)
                {
                    currentPointActive.ActivateThisPoint();
                }
                activateButton.interactable = false;
                pointActive = false;
            }
            
            // If the point is now active then do the thing.
            public void LeaveActivePoint()
            {
                activateButton.interactable = false;
                currentPointActive = null;
                pointActive = false;
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
                if((isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor )&& additionalJumps >= 0)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    additionalJumps--;
                    jumpingNow = true;
                }
            }

            public void BetterJump() 
            {
                if (myRigidbody.velocity.y < 0)
                {
                    Vector2 HoriVerti = Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
                    myRigidbody.velocity += new Vector3(HoriVerti.x, HoriVerti.y, 0);
                    jumpingNow = false;
                }
                else if (myRigidbody.velocity.y > 0 && !Input.GetButtonDown("Jump")) 
                {
                    Vector2 HoriVerti2 = Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
                    myRigidbody.velocity += new Vector3(HoriVerti2.x, HoriVerti2.y, 0);
                }   
            }
        
            void CheckIfGrounded() {
        
                if (isGrounded && !jumpingNow) 
                {
                    additionalJumps = defaultAdditionalJumps;
                    leftground = false;
                }
                else 
                {
                    if (!leftground) 
                    {
                        lastTimeGrounded = Time.time;
                    }
                    leftground = true;
                    isGrounded = false;
                }
            }
    }
}