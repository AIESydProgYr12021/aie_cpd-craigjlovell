using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoyStick : MonoBehaviour
{
    [SerializeField] private VirtualJoyStickMain inputSource;
    private Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        rigid.velocity = inputSource.Direction;
    }
}
