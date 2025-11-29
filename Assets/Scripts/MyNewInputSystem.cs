using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MyNewInputSystem : InputSystem_Actions, IStartable
    {
        public int Priority => -1;
        public void Start() => Enable();
    }
}