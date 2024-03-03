using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void SubscribeToPosition(Transform posSetTo);
    void Launch(Vector3 direction);
}
