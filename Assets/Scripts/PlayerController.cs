using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //Fuerzas de Salto y Speed
    public int fuerzaSalto;
    public float speed = 0;

    //Rigidbody y Movimientos
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    //UI de MainGame 
    public TextMeshProUGUI countText;
    private int count;

    //UI de MainGame2
    public GameObject winTextObject;
    public TextMeshProUGUI countText2;
    private int count2;
   

   //METODO START inicializa las variables
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Add one to the score variable 'count'
        count = 0;
        count2 = 12;

        // Run the 'SetCountText()' function (see below)
        SetCountText();

        winTextObject.SetActive(false);

        
    }
    
    //METODO ONMOVE
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //METODO FIXUPDATE se encarga de dar la velocidad
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    //METODO ONTRIGGER se encarga de sumar la puntuacion al tocar los pick up y reiniciar al player al caer al vacio
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count2 = count2 + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText2();
        }

        if (other.gameObject.CompareTag("Limite"))
        {
            //SceneManager.LoadScene("Juego");
            Vector3 posicion = new Vector3(0, 0.5f, 0);
            transform.position = posicion;
        }

    }

    //METODO SETCOUNTTEXT se encarga de poner el texto de la puntuacion
    void SetCountText()
    {
        countText.text = "Estrellitas: " + count.ToString();
        

        if (count == 12)
        {
            SceneManager.LoadScene("MiniGame2");
        }
        
    }
    void SetCountText2()
    {
        countText2.text = "Estrellitas: " + count2.ToString();
        

        if (count2 >= 20)
        {
            winTextObject.SetActive(true);
        }
    }

    //HACER QUE SALTE
    public float jumpHeight = 7f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
 

    void Update()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                NumberJumps += 1;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        NumberJumps = 0;
    }
    void OnCollisionExit(Collision other)
    {

    }

}
