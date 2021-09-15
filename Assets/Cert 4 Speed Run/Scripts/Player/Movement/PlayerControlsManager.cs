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
        
            public float speed;
            public float jumpForce;
        
            public float fallMultiplier = 2.5f;
            public float lowJumpMultiplier = 2f;
        
            public bool isGrounded = false;
        
            public float rememberGroundedFor;
            float lastTimeGrounded;
        
            public int defaultAdditionalJumps = 1;
            int additionalJumps;
            public bool isReady=false;
        
        
        
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
        
        
            void Move() {
                float x = Input.GetAxisRaw("Horizontal");
        
                float moveBy = x * speed;
        
                myRigidbody.velocity = new Vector2(moveBy, myRigidbody.velocity.y);
            }
        
            void Jump() {
                if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    additionalJumps--;
                }
            }
        
            void BetterJump() {
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