using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CertIVSpeedrun.Camera
{
    public class FollowAheadScript : MonoBehaviour
    {
        
    #region Singleton Code
        private static FollowAheadScript _instance;
        public static FollowAheadScript Instance
        {
            get { return _instance; }
        }

        private void MakeSingleton()
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
        
        // The transform it follows.
        [SerializeField] private Transform followTransform;
        // The x offset.
        [SerializeField] private float xOffset = 0;
        // The y offset.
        [SerializeField] private float yOffset = 0;
        // The slow multiplier offset.
        [SerializeField] private float slowMultiplier = 0.4f;
        // The speed to get there.
        [SerializeField] private float speed = 10;
        // The player to follow.
        [SerializeField] private Rigidbody myPlayerRigidbody;

        private Vector3 pointToMoveTo;
        
        [Header("Zoom Out Data")]
        [SerializeField] private UnityEngine.Camera mainCamera;
        [SerializeField] private float zoomOutTime = 1.2f;
        [SerializeField] private float zoomOutDistance = 7;
        [SerializeField] private float newYoffset = 2.5f;
        [SerializeField] private float newXoffset = 2;
        [SerializeField] private bool turnOnGUI = false;


        private void Awake()
        {
            MakeSingleton();
            mainCamera = GetComponent<UnityEngine.Camera>();
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            // this.transform.position = new Vector3(followTransform.position.x + xOffset, followTransform.position.y + yOffset, this.transform.position.z) + myPlayerRigidbody.velocity*slowMultiplier;
            pointToMoveTo = new Vector3(followTransform.position.x + xOffset, followTransform.position.y + yOffset, this.transform.position.z) + myPlayerRigidbody.velocity*slowMultiplier;
            transform.localPosition = Vector3.Lerp (transform.position, pointToMoveTo, Time.deltaTime*speed);
        }

        public void FollowThisPlayer(Transform _PlayerTransform, Rigidbody _PlayerRigidbody)
        {
            followTransform = _PlayerTransform;
            myPlayerRigidbody = _PlayerRigidbody;
        }

        // This will be done when the player starts their movement
        public void ZoomOutCam()
        {
            StartCoroutine(CameraZoomOut(zoomOutTime));
            StartCoroutine(NewCameraOffset(zoomOutTime));
        }

        private IEnumerator NewCameraOffset(float _zoomOutTime)
        {
            float timeElapsed = 0;

            float originalXOffset = xOffset;
            float originalYOffset = yOffset;
            while (timeElapsed < _zoomOutTime)
            {
                xOffset = Mathf.Lerp(originalXOffset, newXoffset, timeElapsed / _zoomOutTime);
                yOffset = Mathf.Lerp(originalYOffset, newYoffset, timeElapsed / _zoomOutTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            xOffset = newXoffset;
            yOffset = newYoffset;
            yield return null;
        }

        private IEnumerator CameraZoomOut(float _zoomOutTime)
        {
            float timeElapsed = 0;

            while (timeElapsed < _zoomOutTime)
            {
                mainCamera.orthographicSize = Mathf.Lerp(4, zoomOutDistance, timeElapsed / _zoomOutTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            mainCamera.orthographicSize = zoomOutDistance;
            yield return null;
        }

        public void OnGUI()
        {
            if(turnOnGUI)
            {
                GUI.Box(new Rect(10, 10, 100, 90), "Testing Menu");

                if(GUI.Button(new Rect(20, 40, 80, 20), "Zoom Out Button"))
                {
                    ZoomOutCam();
                }
            }
        }
    }
}