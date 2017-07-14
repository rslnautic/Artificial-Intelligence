using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using Completed;
using System;

public class Move : MonoBehaviour
{
    public enum MoveDirection
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public enum MindType
    {
        Breadth,
        PathFinding
    }

    public MindType mind;
    public Vector2 end;
    public float speed = 1.0f;

    private Rigidbody2D rb;
    private GameManager gameManager;

    private Vector2 last;

    public IMind MindController { get; set; }

    public bool keyControl = false;
    private float cooldown = 1.0f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Array values = Enum.GetValues(typeof(MindType));
        System.Random random = new System.Random();
        mind = (MindType)values.GetValue(random.Next(values.Length));

        switch (mind)
        {
            case MindType.Breadth:
                MindController = BreadthMind.getBreathMind();
                break;
            case MindType.PathFinding:
                MindController = PathfindingMind.getPathfindingMind();
                break;
            default:
                MindController = new RandomMind();
                break;
        }
    }

    public void MoveLeft()
    {
        if (end.x == 0)
            return;
        end += Vector2.left;
        Debug.Log("Celda" + last + "->Left\n");
    }

    public void MoveUp()
    {
        if (end.y == gameManager.Map.rows)
            return;
        end += Vector2.up;
        Debug.Log("Celda" + last + "->Up\n");
    }

    public void MoveDown()
    {
        if (end.y == 0)
            return;
        end += Vector2.down;
        Debug.Log("Celda" + last + "->Down\n");
    }

    public void MoveRight()
    {
        if (end.y == gameManager.Map.cols)
            return;
        end += Vector2.right;
        Debug.Log("Celda" + last + "->Right\n");
    }

    public void KeyControl()
    {
        cooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
                cooldown = 1.0f;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveUp();
                cooldown = 1.0f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
                cooldown = 1.0f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
                cooldown = 1.0f;
            }
        }
    }

    public bool AtDestination()
    {
        if (Vector2.Distance(last, end) > float.Epsilon)
        {
            var dist = Vector2.Distance(transform.position, end);
            return dist < 0.1;
        }
        else
        {
                return true;
            }
    }

    Vector2 goalPos;

    // Update is called once per frame
    void Update()
    {

        if (gameManager == null)
        {
            var gO = GameObject.Find("GameManager") as GameObject;
            gameManager = gO.GetComponent<GameManager>();
            goalPos = new Vector2(gameManager.Map.cols - 1, gameManager.Map.rows - 1);
        }
            
        if (!AtDestination())
        {
            MoveNeed = false;
            Vector2 pos = Vector2.Lerp(transform.position, end, Time.deltaTime*speed);
            rb.MovePosition(pos);
        }
        else
        {
            transform.position = end;
            MoveNeed = true;
            if (keyControl)
            {
                KeyControl();
            }
            else
            {
                if (MindController != null)
                {
                    if (MoveNeed)
                    {
                        last = new Vector2(end.x, end.y);
                        MoveDirection dir;
                        if(GameManager.instance.ForPlanner)
                        {
                            if(Strips.plan.Count != 0 && end == Strips.plan[0].position)
                            {
                                Strips.plan.RemoveAt(0);
                            } else
                            {
                                for (int i = 0; i < Strips.plan.Count; i++)
                                {
                                    if (end == Strips.plan[i].position)
                                    {
                                        Strips.plan.RemoveAt(i);
                                    }
                                }
                            }

                            if (Strips.plan.Count != 0)
                            {
                                dir = MindController.GetNextMove(end, Strips.plan[0].position);
                            }
                            else {
                                dir = MindController.GetNextMove(end, goalPos);
                            }
                        } else
                        {
                            dir = MindController.GetNextMove(end, new Vector2(gameManager.Map.cols - 1, gameManager.Map.rows - 1));
                        }

                        if (dir == MoveDirection.Left)
                        {
                            MoveLeft();
                        }
                        if (dir == MoveDirection.Up)
                        {
                            MoveUp();
                        }
                        if (dir == MoveDirection.Down)
                        {
                            MoveDown();
                        }
                        if (dir == MoveDirection.Right)
                        {
                            MoveRight();
                        }
                    }
                }
                    
            }
        }
    }

    public bool MoveNeed { get; set; }
}