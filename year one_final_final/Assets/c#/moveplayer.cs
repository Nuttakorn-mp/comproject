using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    Animator anim;
    Rigidbody r;
    Vector3 movement;
    public int speed;
    public float timer;
    public int startspeed ;
    
    public float starttimer;
    public GameObject gun;
    Player_Shooting shoot;
    Color startcolor =  Color.yellow;
    public bool mouseatt;
    Light lt;
    Quaternion newRotation;
    public int numplayer = 1;
    float h;
    float v;
    public int moreda =0;
    public int startda;
    int lowspeed;
    float timesloww ;
    void Start()
    {
        timesloww = 0;
        anim = GetComponent<Animator>();
        shoot = gun.gameObject.GetComponent<Player_Shooting>();
        startda = shoot.damagePerShot;
        startspeed = speed;
        r = GetComponent<Rigidbody>();
        lt = gun.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if(speed > 26)
        {
            speed = 26;
        }
        if (startspeed > 26)
        {
            startspeed = 26;
        }

        shoot.stardamage = startda + moreda;
        if (numplayer == 1)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            h = Input.GetAxisRaw("XPlayerTwo");
            v = Input.GetAxisRaw("YPlayerTwo");

        }
        movement.Set(h, 0f, v);

        movement = movement.normalized * (speed-lowspeed) * Time.deltaTime;

        r.MovePosition(transform.position + movement);
        Animating(h, v);

        removeskill();
        //Animating(h,v);
        if (mouseatt == true)
        {
            Turning();
        }
        else
        {
            turingnomouse();
        }
        

        
    }
    private void LateUpdate()
    {
        timesloww -= Time.deltaTime;
        if (timesloww < 0)
        {
            lowspeed = 0;
        }
        
    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

             newRotation = Quaternion.LookRotation(playerToMouse);
            
            r.MoveRotation(newRotation);
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("walk", walking);
    }
    public void speedt(int a,float s_time)
    {
        speed = speed + a;
        timer = s_time;
        starttimer = timer;
    }
    public void removeskill()
    {
        
        if ( timer > 0  && speed != startspeed )
        {
            timer -= Time.deltaTime;
            if (timer < 0 )
            {
                speed = startspeed;
                timer = starttimer;
            }
            
        }
        if ( timer > 0  && startcolor != lt.color)
        {
            timer -= Time.deltaTime;
            if (timer < 0 )
            {
                lt.color = Color.yellow;
                timer = starttimer;
            }
            
        }
        
    }
    public void moredamge(int a,float  s_time)
    {

        shoot.moredamge(a, s_time);
        lt.color = Color.red;
        timer = s_time;
        starttimer = timer;
    }
    public void morespeeddamge(float a, float s_time)
    {
        shoot.morespeeddamge(a, s_time);
        timer = s_time;
        starttimer = timer;
    }
    void turingnomouse()
    {
        if (numplayer == 2)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                newRotation = Quaternion.Euler(0f, 270f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                newRotation = Quaternion.Euler(0f, 0f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                newRotation = Quaternion.Euler(0f, 90f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                newRotation = Quaternion.Euler(0f, 180f, 0f);
                r.MoveRotation(newRotation);
            }
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.A))
            {
                newRotation = Quaternion.Euler(0f, 270f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                newRotation = Quaternion.Euler(0f, 0f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                newRotation = Quaternion.Euler(0f, 90f, 0f);
                r.MoveRotation(newRotation);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                newRotation = Quaternion.Euler(0f, 180f, 0f);
                r.MoveRotation(newRotation);
            }
        }
    }
    
    public void slow(int a, float timeslow)
    {
        if (speed - lowspeed < 3)
        {
            return;
        }
        lowspeed += a;
        timesloww = timeslow;
    }

}
