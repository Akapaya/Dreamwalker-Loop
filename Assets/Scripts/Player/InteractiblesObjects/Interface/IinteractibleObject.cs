using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IinteractibleObject {
    bool InUse { get; set; }

    public void UseObject();
    public void ReleaseObject();
}
