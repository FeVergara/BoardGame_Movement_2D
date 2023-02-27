using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 3f;

    public int waypointIndex = 0;

    public ControlGame game;


    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < game.GetComponent<ControlGame>().numberDiceTotal)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex + 1].transform.position, moveSpeed * Time.deltaTime);
            

            switch (waypointIndex)
            {
                case 2:
                    if (game.GetComponent<ControlGame>().numberDice % 2 == 0)
                    {
                        waypointIndex += 6;
                        game.GetComponent<ControlGame>().numberDiceTotal += 6;
                        print("par");
                    }else
                    {
                        if (transform.position == waypoints[waypointIndex + 1].transform.position)
                        {
                            print("impar");
                            waypointIndex++;
                        }

                    }
                    break;


                case 8:
                    if (transform.position.y > 1)
                    {
                        waypointIndex += 2;
                        game.GetComponent<ControlGame>().numberDiceTotal += 2;
                        print("8");
                    }else
                    {
                        if (transform.position == waypoints[waypointIndex + 1].transform.position)
                        {
                            print("default");
                            waypointIndex++;
                        }
                    }
                    break;


                case 15:
                    if(game.GetComponent<ControlGame>().numberDice % 2 == 0)
                    {
                        waypointIndex ++;
                        game.GetComponent<ControlGame>().numberDiceTotal ++;
                        print("par");
                    }
                    else
                    {
                        if (transform.position == waypoints[waypointIndex + 1].transform.position)
                        {
                            waypointIndex++;
                            print("impar");
                        }
                    }
                    break;



                case 16:
                    if (transform.position.y > 3)
                    {
                        SceneManager.LoadScene(1);
                    }else
                    {
                        if (transform.position == waypoints[waypointIndex + 1].transform.position)
                        {
                            print("impar");
                            waypointIndex++;
                        }
                    }
                    break;


                case 18:
                    if (transform.position.y < 1)
                    {
                        SceneManager.LoadScene(1);
                    }else
                    {
                        if (transform.position == waypoints[waypointIndex + 1].transform.position)
                        {
                            print("impar");
                            waypointIndex++;
                        }
                    }
                    break;


                default:
                    if (transform.position == waypoints[waypointIndex + 1].transform.position)
                    {
                        waypointIndex++;
                        print("default");
                    }
                    break;
            }
        }
    }
}