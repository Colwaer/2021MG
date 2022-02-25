using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnEnable() {
        GameManager1_2.instance.OnFireplaceBurned();
    }
}
