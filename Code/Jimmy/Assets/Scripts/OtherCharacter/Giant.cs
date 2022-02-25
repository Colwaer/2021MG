using System.Collections;
using UnityEngine;

public enum GiantState
{
    None, ChasePupil,
}
public class Giant : MonoBehaviour
{

    public float speed = 2.0f;
    public Transform showUpPos;

    private Rigidbody2D rb;

    public GiantState giantState;

    public AK.Wwise.Event walking;
    public AK.Wwise.Event voice;

    private GiantState lastState;

    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        animator.SetFloat("Horizontal", rb.velocity.x);

        if (giantState == GiantState.None)
            return;
        

    }
    private void FixedUpdate()
    {
        if (giantState == GiantState.None)
            return;
        else if (giantState == GiantState.ChasePupil)
        {

            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        
    }
    public void PlayWalkingSound()
    {
        walking.Post(gameObject);
    }
    public void PlayVoiceSound()
    {
        voice.Post(gameObject);
    }

    public void SwitchState(GiantState state)
    {
        giantState = state;
    }

    public void ShowUpAndShout()
    {
        StartCoroutine(IShowUpAndShout());
    }
    IEnumerator IShowUpAndShout()
    {
        rb.velocity = new Vector2(-1, 0);
        while (Mathf.Abs(transform.position.x - showUpPos.position.x) > 0.3f)
        {
            rb.velocity = new Vector2(-1, 0);
            yield return new WaitForFixedUpdate();
        }
        rb.velocity = Vector2.zero;
    }
}
