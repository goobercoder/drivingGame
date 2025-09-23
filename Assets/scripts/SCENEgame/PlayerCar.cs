using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    //making som variables
    public float speed = 10f;
    public float turnSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //luetaan pysty ja vaakasuuntainen liike
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        //tehään liike z suunnassa tai "forward"
        transform.Translate(Vector3.forward * move);

        //käännetään autoa y akselissa eli vasen tai oikee
        transform.Rotate(Vector3.up * turn);
        
    }
}
