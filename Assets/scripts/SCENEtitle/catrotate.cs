using UnityEngine;

public class catrotate : MonoBehaviour
{
    public float moveSpeed = 2f;  
    public float rotateSpeed = 15f; 

    private float originalX; 
    private float originalZ; 
    private Vector3 startPos; // ku o yljäälle
    private Vector3 endPos;   // ku o alhaalla
    private bool movingToEnd = true; // mihi suuntaan menee, ylös vai alas

    void Start()
    {
        //transform.position on objectin nykyinen asento
        originalX = transform.position.x;
        originalZ = transform.position.z;

      
        startPos = new Vector3(originalX, 2, originalZ);
        endPos = new Vector3(originalX, -2, originalZ);
    }

    void Update()
    {


        // mee alas pehmeästi (moveTowards)
        
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPos) < 0.01f)
                movingToEnd = false;
        }
        else
        { //mee ylös
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                movingToEnd = true;
        }

        // pyöri kivasti
        transform.Rotate(0f, rotateSpeed * 100 * Time.deltaTime, 0f);
    }
}
