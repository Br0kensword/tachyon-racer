using UnityEngine;

public class Avatar : MonoBehaviour
{

    public ParticleSystem shape, trail, burst;

    public float deathCountdown = -1.7f;
    public float respawnTimer = -1.7f;
    
    private Player player;
    private AudioSource avatarSound;

    private void Awake()
    {
        player = transform.root.GetComponent<Player>();
        avatarSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (deathCountdown >= 0f)
        {
            deathCountdown -= Time.deltaTime;
            if (deathCountdown <= 0f)
            {
                deathCountdown = respawnTimer;
                var ss = shape.emission;
                var ts = trail.emission;
                ss.enabled = true;
                ts.enabled = true;
                player.Die();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit something!!!");
        if (deathCountdown < 0f)
        {
            var ss = shape.emission;
            var ts = trail.emission;
            ss.enabled = false;
            ts.enabled = false;
            burst.Emit(burst.main.maxParticles);
            deathCountdown = burst.main.startLifetimeMultiplier;
            avatarSound.Play();
        }
    }
}