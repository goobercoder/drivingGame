using UnityEngine;

public class AiCar : MonoBehaviour
{

    public Transform[] waypoints;
    private int currentPoint = 0; //seuraava piste
    public float speed = 10f;

    public float turnSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //haetaan seuraava piste

        Transform target = waypoints[currentPoint];
        //luodaan paikka johon auto menee x ja x pisteistä, y pysyy aina samana
        Vector3 targetXZ = new Vector3(target.position.x, transform.position.y, target.position.z);

        //lasketaan suunta
        Vector3 direction = (targetXZ - transform.position).normalized;
        //lasketaan rotaatio
        Quaternion LookRotation = Quaternion.LookRotation(direction);
        //käännetään auto pehmeästi (slerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, turnSpeed * Time.deltaTime);
        //liiku
        transform.Translate(direction * speed * Time.deltaTime);

        //ota seuraava ai piste
        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            currentPoint = +1;
        }
        //kun on valmis kierroksella niin alottaa taas
        if (Vector3.Distance(transform.position, waypoints[waypoints.Length - 1].position) > 2f)
        {
            currentPoint = 0;
        }
        
    }
}
