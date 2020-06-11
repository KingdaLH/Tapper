using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPrefab : MonoBehaviour
{

    
    private Rigidbody rb;
    public float forwardSpeed; //Voorwaartse snelheid 
    private float backwardSpeed; //Achteruitgaande snelheid

    private float timer1; //Bepaalt de tijd tussen elke stap ( StepForward() )
    private float timer2; //Timer voor het verwijderen van de prefab na x seconden
    private float respawnTime; //Tijd dat er een nieuwe customer stopt
    public bool waiting; //Checkt of de customer stil moet staan
    public bool served; //Checkt of de customer bediend is
    public bool selfDestruction; //Checkt of de customer verwijderd moet worden
    
    void Start()
    {rb = gameObject.GetComponent<Rigidbody>();
        forwardSpeed = 100.0f;
        backwardSpeed = 0.01f;
        timer1 = 1;
        respawnTime = 1.0f;
        waiting = false;
        served = false;
        selfDestruction = false;}

    void Update()
    {   timer1 = timer1 - Time.deltaTime;
        timer2 = timer2 - Time.deltaTime;
        if (timer1 <= 0){
            timer1 = 1.0f;
            StepForward();}
        if (served)
        {transform.Translate(Vector3.right * -backwardSpeed, Space.World);}
        if (selfDestruction && timer2 <= 0)
        {Destroy(gameObject);}}

    void StepForward() //Stap vooruit
    {
       if (!waiting)
       {rb.AddForce(transform.right * forwardSpeed);}}

    void OnCollisionEnter(Collision collision){   
        if (collision.gameObject.tag == "Wall2" || collision.gameObject.tag == "Customer") //Wanneer de customer het eind van de bar of andere customer raakt 
        {   waiting = true;
            Freeze();
            if (collision.gameObject.tag == "Wall2") 
            {GameManager.health = GameManager.health - 1;}}      
        if (collision.gameObject.tag == "Drink") //Wanneer een drankje de customer raakt
        {   transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), -5);
            served = true;
            timer2 = 1;
            selfDestruction = true;}}

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Customer") //Wanneer de customer stopt met colliden
        {   timer1 = 1;
            waiting = false;
            Unfreeze();}}

    void Freeze() //Zet de customer stil
    {   rb.constraints = RigidbodyConstraints.FreezePositionX |
        RigidbodyConstraints.FreezePositionY |
        RigidbodyConstraints.FreezePositionZ |
        RigidbodyConstraints.FreezeRotationX |
        RigidbodyConstraints.FreezeRotationY |
        RigidbodyConstraints.FreezeRotationZ;}
    void Unfreeze() //Laat de customer weer bewegen (alleen op x as)
    {   rb.constraints =
        RigidbodyConstraints.FreezePositionY |
        RigidbodyConstraints.FreezePositionZ |
        RigidbodyConstraints.FreezeRotationX |
        RigidbodyConstraints.FreezeRotationY |
        RigidbodyConstraints.FreezeRotationZ;}
}
