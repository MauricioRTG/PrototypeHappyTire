using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Vector3 Changeposition;
    public int constantSpeed;
    public Rigidbody tire;
    // Start is called before the first frame update
    // Update is called once per frame
    void LateUpdate()
    {
        
        tire.velocity = constantSpeed * (tire.velocity.normalized);

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            tire.MovePosition(tire.position + Changeposition * Time.fixedDeltaTime);
        }
         if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tire.MovePosition(tire.position + (-Changeposition) * Time.fixedDeltaTime);
        }
            
    }
}
