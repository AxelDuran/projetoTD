using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveDirection : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveChar();
    }

   private void MoveChar()
    {
        Vector2 pos = TestInputManager.GetInstance().GetMoveDirection();
        
        rb.velocity= new Vector3(pos.x * speed, 0, pos.y * speed);
        
    }
}
