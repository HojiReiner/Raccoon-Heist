using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    #region Variables/Constants
    [Header("Players")]
    public GameObject Player;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Boom;


    GameObject PlayerUp;
    GameObject PlayerDown;
    Transform Beacon;
    bool transforming = false;
    #endregion


    void Start(){
        PlayerUp = Player1;
        PlayerDown = Player2;
        Player.SetActive(true);
        Player1.SetActive(false);
        Player2.SetActive(false);
        Beacon = transform.Find("Beacon");
        Beacon.parent = Player.transform;
        Beacon.localPosition = Vector3.zero; 
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Transform") && !transforming) Transformation();
        if(Input.GetButtonDown("Change")) Change();
    }

    #region Transformation
    private void Transformation(){
        if(Player.activeSelf){
            Vector3 playerPos = Player.transform.position;
            PlayerUp.transform.position = new Vector3(playerPos.x, playerPos.y + 0.5f, playerPos.z);
            PlayerDown.transform.position = new Vector3(playerPos.x, playerPos.y - 0.5f, playerPos.z);

            StartCoroutine(ani());
            Player.SetActive(false);
            Player1.SetActive(true);
            Player2.SetActive(true);
            PlayerUp.GetComponent<Player>().change(true);
            PlayerDown.GetComponent<Player>().change(false);
            Beacon.parent = PlayerUp.transform;
            Beacon.localPosition = Vector3.zero; 
        
        }else{
            Transform player1Feet = transform.Find("Player1/Feet");
            Transform player2Feet = transform.Find("Player2/Feet");
            Vector3 playerUpPos;
            bool Player1Up = false;
            bool Player2Up = false;

            Collider2D player1Hit = Physics2D.BoxCast(player1Feet.position, new Vector2(0.61f, 0.001f), 0,
                            Vector2.down, 0.2f, LayerMask.GetMask("Player")).collider;

            Collider2D player2Hit = Physics2D.BoxCast(player2Feet.position, new Vector2(0.61f, 0.001f), 0,
                            Vector2.down, 0.2f, LayerMask.GetMask("Player")).collider;
            
            if(player1Hit != null){
                Player1Up = player1Hit.CompareTag("Racoon");
            
            }else if(player2Hit != null){
                Player2Up = player2Hit.CompareTag("Racoon");
            
            }else{
                return;
            }

            if(Player1Up){ 
                PlayerUp = Player1;
                PlayerDown = Player2;
                
            }else if(Player2Up){
                PlayerUp = Player2;
                PlayerDown = Player1;
            }
            
            if(Player1Up || Player2Up){
                playerUpPos = PlayerUp.transform.position;
                Player.transform.position = new Vector3(playerUpPos.x, playerUpPos.y - 0.5f, playerUpPos.z);

                StartCoroutine(ani());
                Player1.SetActive(false);
                Player2.SetActive(false);
                Player.SetActive(true);
                Beacon.parent = Player.transform;
                Beacon.localPosition = Vector3.zero; 
            }
        }
    }

    IEnumerator ani(){
        transforming = true;
        Boom.transform.position = Player.transform.position;
        Boom.SetActive(true);
        yield return new WaitForSeconds(1);
        Boom.SetActive(false);
        transforming = false;

    }

    #endregion

    #region Chnage Players
    private void Change(){
        if(!Player.activeSelf){
            Player player1Movement = Player1.GetComponent<Player>();
            Player player2Movement = Player2.GetComponent<Player>();
            bool p1 = player1Movement.change();
            bool p2 = player2Movement.change();
            if(p1){
                Beacon.parent = Player1.transform;
                Beacon.localPosition = Vector3.zero; 
            }else{
                Beacon.parent = Player2.transform;
                Beacon.localPosition = Vector3.zero; 
            }

            //Player1.GetComponent<Animator>().SetBool("IsRunning", false);
            //Player2.GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }
    #endregion
}
