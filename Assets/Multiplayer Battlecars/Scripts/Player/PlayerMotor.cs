using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battlecars.Player
{
    public class PlayerMotor : MonoBehaviour
    {
        private bool isEnabled = false;

        public void Enable() => isEnabled = true;

        // Update is called once per frame
        void Update()
        {
            if(!isEnabled)
                return;

            transform.position += (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * Time.deltaTime;
        }
    }   
}