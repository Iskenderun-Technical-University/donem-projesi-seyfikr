using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{

    Animator anim;
  
    bool beardied;
    public Transform hedefoyuncu;
    public float kovalamamesafe;
    float mesafe;
    NavMeshAgent bearnavmsh;
    void Start()
    {

        anim = GetComponent<Animator>();
        
        bearnavmsh = this.GetComponent<NavMeshAgent>();

    }
    void FixedUpdate()
    {   
            mesafe = Vector3.Distance(this.transform.position, hedefoyuncu.transform.position);
            if (mesafe < kovalamamesafe)
            {
                this.transform.LookAt(hedefoyuncu.transform.position);
                bearnavmsh.isStopped = false;
                bearnavmsh.SetDestination(hedefoyuncu.transform.position);
                //yurume
                anim.SetBool("yuruyor", true);
                
            }
            else
            {
                bearnavmsh.isStopped = true;
                anim.SetBool("yuruyor", false);
               
            }
           
        }

    }
  
    
  
   

