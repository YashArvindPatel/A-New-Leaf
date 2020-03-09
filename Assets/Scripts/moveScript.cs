using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class moveScript : MonoBehaviour
{
    private Vector2 speedX = new Vector2(1, 0);
    private Vector2 speedY = new Vector2(0, 1);
    public Rigidbody2D rb;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public healthScript health;
    public int damage = 1;
    public bool onDefense = false;
    public cardScript cards;
    public AudioSource audioSource;
    public AudioClip attackAirSound, attackShieldSound, attackEnemySound, defendSound, walkSound;
    public bool attackSoundPlayed = false;
    public bool player1orNot = false;
    // Use when needed to move through keyboard

    //void Update()
    //{
    //    if (Input.GetKeyDown("left"))
    //    {
    //        rb.MovePosition(rb.position - speedX);
    //    }
    //    else if (Input.GetKeyDown("right"))
    //    {
    //        rb.MovePosition(rb.position + speedX);
    //    }
    //    else if (Input.GetKeyDown("up"))
    //    {
    //        rb.MovePosition(rb.position + speedY);
    //    }
    //    else if (Input.GetKeyDown("down"))
    //    {
    //        rb.MovePosition(rb.position - speedY);
    //    }
    //}

    private void Start()
    {
        if(gameObject.name == "Player 1(Clone)")
        {
            player1orNot = true;
        }
    }

    public void moveLeft()
    {
        animator.SetBool("LookUp", false);
        animator.SetBool("LookDown", false);      
        animator.SetTrigger("Walk");
        audioSource.PlayOneShot(walkSound);
        rb.MovePosition(rb.position - speedX);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void moveRight()
    {
        animator.SetBool("LookUp", false);
        animator.SetBool("LookDown", false);
        animator.SetTrigger("Walk");
        audioSource.PlayOneShot(walkSound);
        rb.MovePosition(rb.position + speedX);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void moveStraight()
    {
        animator.SetBool("LookUp", true);
        animator.SetBool("LookDown", false);
        audioSource.PlayOneShot(walkSound);
        rb.MovePosition(rb.position + speedY);
    }

    public void moveBack()
    {
        animator.SetBool("LookDown", true);
        animator.SetBool("LookUp", false);
        audioSource.PlayOneShot(walkSound);
        rb.MovePosition(rb.position - speedY);
    }

    public void attack()
    {
        //play attack animation of player
        animator.SetTrigger("Attack");
        //if hit then reduce health of other player
        Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector3(0.5f, 0.5f, 0.5f), 0, enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            if (!enemy.GetComponent<moveScript>().onDefense)
            {
                audioSource.PlayOneShot(attackEnemySound);
                attackSoundPlayed = true;
                enemy.GetComponent<healthScript>().Damage(damage, player1orNot);
            }
            else
            {
                audioSource.PlayOneShot(attackShieldSound);
                attackSoundPlayed = true;
                enemy.GetComponent<moveScript>().onDefense = false;
                enemy.GetComponent<moveScript>().animator.SetBool("onDefense", false);
                enemy.GetComponent<cardScript>().enableCards();
            }
        }
        if (attackSoundPlayed)
        {
            attackSoundPlayed = false;
        }
        else
        {
            audioSource.PlayOneShot(attackAirSound);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireCube(attackPoint.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    public void defend()
    {      
        if (!onDefense)
        {
            animator.SetTrigger("Defend");
            animator.SetBool("onDefense", true);
            audioSource.PlayOneShot(defendSound);
            onDefense = true;
            cards.disableCards();
        }
        else
        {
            animator.SetBool("onDefense", false);
            audioSource.PlayOneShot(attackShieldSound);
            onDefense = false;
            cards.enableCards();
        }
        //if defend is true then no damage is reduced but your movement is restricted as well
    }
}