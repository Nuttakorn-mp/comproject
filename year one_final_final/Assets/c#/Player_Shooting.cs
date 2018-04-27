using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public int numplayer;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    float gol = 1.0f;
    float timer_;
    float timerskill;
    public int stardamage;
    float starspeeddamage;
    public bool playeratt;
    float timer_da;
    float timer_sp;
    void Awake()
    {
        
        starspeeddamage = timeBetweenBullets;
        stardamage = damagePerShot;
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    void Update()
    {
        removeskill();
        if (playeratt != true)
        {
            if (numplayer == 1)
            {
                if (!Input.GetKey(KeyCode.G))
                {
                    gunLine.enabled = false;
                    gunLight.enabled = false;
                    return;
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.L))
                {
                    gunLine.enabled = false;
                    gunLight.enabled = false;
                    return;

                }
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                gunLine.enabled = false;
                gunLight.enabled = false;
                return;
            }
        }
        

            timer += Time.deltaTime;

        if (gol > 0 && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            gunAudio.Play();
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            zombieH enemyHealth = shootHit.collider.GetComponent<zombieH>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
    public void moredamge(int a,float s_time)
    {
        timerskill = s_time;
        damagePerShot = a;
    }
    public void morespeeddamge(float a, float s_time)
    {
        timerskill = s_time;
        timeBetweenBullets = a;
    }
    void removeskill()
    {
        
        if (stardamage != damagePerShot)
        {
            timer_da += Time.deltaTime;
            if (timer_da > timerskill)
            {
                damagePerShot = stardamage;
                timer_da = 0f;
            }
        }
        if (starspeeddamage != timeBetweenBullets)
        {
            timer_sp += Time.deltaTime;
            if (timer_sp > timerskill)
            {
                timeBetweenBullets = starspeeddamage;
                timer_sp = 0f;
            }
        }
    }
}
