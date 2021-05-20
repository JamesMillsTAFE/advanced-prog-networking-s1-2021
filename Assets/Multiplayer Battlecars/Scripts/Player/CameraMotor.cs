using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battlecars.Player
{
    public class CameraMotor : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = Vector3.zero;
        [SerializeField, Range(0, 1)] private float damping = .5f;

        private Vector3 velocity = Vector3.zero;

        // Start is called before the first frame update
        private void Start()
        {
            transform.position = target.position + offset;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Vector3 position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, damping);
            transform.position = position;

            transform.LookAt(target);
        }
    }
}