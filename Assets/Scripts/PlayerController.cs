using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    public InputAction moveAction;
    public InputAction shootAction;

    public float xRange = 10;

    public GameObject foodPrefabs;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        var horiInput = moveAction.ReadValue<Vector2>().x;
        //horiInput = .x;
        transform.Translate(horiInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y,transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (shootAction.triggered)
        {
            Instantiate(foodPrefabs, transform.position, Quaternion.identity);
        }

        if (shootAction.IsPressed())
        {
            Instantiate(foodPrefabs, transform.position, Quaternion.identity);
        }


        //Invoke("Shoot", 20.0f);

    }

    //void Shoot()
    //{
    //    if (shootAction.IsPressed())
    //    {
    //        Instantiate(foodPrefabs, transform.position, Quaternion.identity);
    //    }
    //}

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, 1);

        //Gizmos.color = Color.purple;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
                        new Vector3(-xRange, transform.position.y, transform.position.z), 
                        (new Vector3(xRange, transform.position.y, transform.position.z)));
            

    }

}