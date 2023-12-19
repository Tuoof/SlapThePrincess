using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody body;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        MovePlayer();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        /*float y = Input.GetAxis("Vertical");*/

        Vector3 moveDir = new Vector3(x, 0, 0);
        body.velocity = moveDir * speed;

        if (x != 0 && x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
