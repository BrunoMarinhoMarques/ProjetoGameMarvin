using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Rigidbody rb;
    public float speedMove;
    public float speedRot;
    public float limitSpeed;
    public bool onTheFloorOkJump = true;
    public bool itIsRunning;
    public float jumpForce;
    public bool jump;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        onTheFloorOkJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //INPUT MOVEMENT CHARACTER
        //pega a chave digitada e verifica se o W foi digitado
        if (Input.GetKey(KeyCode.W))
        {
            //adicionar uma forca ao Rigibody(personagem)
            //transfor.forward representa para ir para a frente do personagem e multiplica
            //para saber o quanto ele desloca para frente a cada segundo
            if(rb.velocity.z <= limitSpeed && rb.velocity.z >= -limitSpeed)
            {

                rb.AddForce(transform.forward * speedMove * Time.deltaTime);

            }

            if (onTheFloorOkJump)
            {
                itIsRunning = true;
                anim.SetBool("isRunning", true);
            }
           
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(rb.velocity.z <= limitSpeed && rb.velocity.z >= -limitSpeed)
            {
                rb.AddForce(transform.forward * -speedMove * Time.deltaTime);
            }

            if (onTheFloorOkJump)
            {
                itIsRunning = true;
                anim.SetBool("isRunningBack", true);
            }

        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(0, speedRot * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(0, -speedRot * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onTheFloorOkJump==true)
        {
            rb.AddForce(0, jumpForce, 0);
            jump = true;
            onTheFloorOkJump = false;
            anim.SetBool("isJumping", true);
        }


        //PARA A ANIMACAO DE CORRER QUANDO SOLTO A TECLA S OU W
        if (Input.GetKeyUp(KeyCode.W))
        {
            itIsRunning=false;
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            itIsRunning = false;
            anim.SetBool("isRunningBack", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            
            //verifica se está no chao
            onTheFloorOkJump = true;

            //torna o pulo falso pois esta no chao
            jump = false;

            //torna animacao do pulo falsa
            anim.SetBool("isJumping", false);
        }
    }
}
