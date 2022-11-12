using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Global.ID
{
    public class IDGenerator
    {
        public string GenerateID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

