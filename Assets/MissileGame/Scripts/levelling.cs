using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelling : MonoBehaviour
{  
    [SerializeField] int levelnum = 5;
    [SerializeField] int currentMissileIndex;
    [SerializeField] GameObject[] rocketIndex;
    [SerializeField] GameObject particles;
    [SerializeField] Transform particleTransform;
    public Text leveltext;
     [SerializeField] Animator[] anim;
    public Animation[] M1anim;
   //public AnimationClip[] animclip;
    // M1Animator anim1;
    //M2Animator anim2;
    //Animation ani;
    // Start is called before the first frame update
    void Start()
    {
        //ani = GetComponent<Animation>();
        //anim1 = FindObjectOfType<M1Animator>();
        //anim2 = FindObjectOfType<M2Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        leveltext.text = "Level: " + levelnum;
        Mathf.Clamp(levelnum, 1,10);
        Mathf.Clamp(currentMissileIndex, 0, 3);
    }
    public void LevelUp()
    {
       
        if (levelnum < 9)
        {
            //Instantiate(particles, transform.position, Quaternion.identity);
            Animations();
           //
        }

        if (currentMissileIndex < rocketIndex.Length - 1)
        {
            foreach (GameObject rocket in rocketIndex)
            {
                rocket.SetActive(false);
            }
            //levelnum++;
            currentMissileIndex++;
            
           // GetComponent<grenade>().Force += 50;
            rocketIndex[currentMissileIndex].SetActive(true);
        }
        else
        {
            rocketIndex[3].SetActive(true);
        } 
    }
    public void levelDown()
    {
       
        if (levelnum >1)
        {
            // Instantiate(particles, transform.position, Quaternion.identity);
            // anim2.shrink();
            Animationsdeg();
        }
       
        if ( currentMissileIndex > 1 )
        {
            foreach (GameObject rocket in rocketIndex)
            {
                rocket.SetActive(false);
            }
            //levelnum--;
            currentMissileIndex--;

            rocketIndex[currentMissileIndex].SetActive(true);
            GetComponent<grenade>().Force -= 50;
        }
        else
        {
            rocketIndex[0].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        {
            LevelUp();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Obstacle")
        {
            levelDown();
            Destroy(other.gameObject);
        }
    }


    void Animations()
    {
        switch (currentMissileIndex)
        {
            case 0:
                // anim1.shrink();
                anim[0].SetBool("shrink", true);               
                break;
            case 1:
            //    // anim2.attach(); 
                anim[1].SetBool("shrink2", true);
               break;
        }
    }
    void Animationsdeg()
    {
        switch (currentMissileIndex)
        {
            case 0:
                //// anim1.attach();
                //anim[0].SetBool("attach", true);               
                break;
            case 1:
                ////anim2.shrink();
                //anim[1].SetBool("shrink2", true);
                break;
        }

    }
}
