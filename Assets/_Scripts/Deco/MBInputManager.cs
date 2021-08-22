using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Madbricks
{
    public class MBInputManager : MonoBehaviour
    {
        private static MBInputManager _instance;

        public static MBInputManager GetInstance(){
            if(_instance == null){
                var newGameObject = new GameObject();
                newGameObject.name = "MBInputManager";
                _instance = newGameObject.AddComponent<MBInputManager>();
            }
            return _instance;
        }

        public Vector2 Direction { get; private set; }

        public bool SpecialPressedThisFrame => Input.GetKeyDown(KeyCode.Space);

        private void Update()
        {
            UpdateDirection();
        }

        private void UpdateDirection()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Direction = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Direction = Vector2.down;
            }
            else
            {
                Direction = Vector2.zero;
            }
        }
    }
}