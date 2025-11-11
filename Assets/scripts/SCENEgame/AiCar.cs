using UnityEngine;
using UnityEngine.UI;

public class AiCar : MonoBehaviour
{

    public Transform[] waypoints;
    private int currentPoint = 0; //seuraava piste
    public float speed = 10f;

    public float turnSpeed = 5f;
    public Slider mySlider; //get the speed slider
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame  
    void Update()
    {
        speed = mySlider.value;
        turnSpeed = mySlider.value / 2;
        //haetaan seuraava piste

        Transform target = waypoints[currentPoint];
        //luodaan paikka johon auto menee x ja x pisteistä, y pysyy aina samana
        Vector3 targetXYZ = new Vector3(target.position.x, target.position.y, target.position.z);

        //lasketaan suunta
        Vector3 direction = (targetXYZ - transform.position).normalized;
        //lasketaan rotaatio
        Quaternion LookRotation = Quaternion.LookRotation(direction);
        //käännetään auto pehmeästi (slerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, turnSpeed * Time.deltaTime);
        //liiku
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //ota seuraava ai piste
        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            currentPoint = (currentPoint + 1) % /*toi juttu kattoo että ei mennä yli listan pituuden*/waypoints.Length;
        }


    }
    
}
