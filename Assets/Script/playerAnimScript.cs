using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow)){
            anim.SetBool("isWalking",true);
        }
        else{
            anim.SetBool("isWalking",false);
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)){
            anim.SetTrigger("jump");
        }
    }
}
