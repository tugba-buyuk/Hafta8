using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class finito : MonoBehaviour
{
    public Text zaman, can;
    float zamanSayaci=100;
    float canSayaci=5;
    bool oyunDevam = true;
    
    


    float inputX;
    float inputY;
    public Transform Model;
    Animator anim;
    Vector3 StickDirection;
    Camera mainCam;
    public float damp;
    [Range(1, 20)]
    public float rotationSpeed;



    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    private void OnCollisionEnter(Collision coll)
    {
        string objTag = coll.gameObject.tag;
        if (objTag.Equals("ev"))
        {
            SceneManager.LoadScene("Win");



        }else if (objTag.Equals("ayi") || objTag.Equals("wolf"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci <= 0)
            {
                oyunDevam = false;
            }
        }
    }
    private void Update()
    {
        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci + "";
        if (zamanSayaci <= 0)
        {
            oyunDevam = false;
        }
    }

    private void LateUpdate()
    {
        if (oyunDevam)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            StickDirection = new Vector3(inputX, 0, inputY);

            InputMove();
            InputRotation();

        }
        else
        {
            SceneManager.LoadScene("Lost");
        }
    }

    void InputMove()
    {
        anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude, damp, Time.deltaTime * 10);

    }
    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        Model.forward = Vector3.Slerp(Model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }

}
