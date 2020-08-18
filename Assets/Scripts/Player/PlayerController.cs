using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float cellSize = 2.56f;
    GridController gridController;
    bool controlable = true;

    private void Awake()
    {
        gridController = FindObjectOfType<GridController>();
    }

    private void Update()
    {
        if (!controlable)
            return;
        Move();
        Action();
    }

    public void FreezeControlFor(float time)
    {
        StartCoroutine(FreezeControlCoroutine(time));
    }

    IEnumerator FreezeControlCoroutine(float time)
    {
        controlable = false;
        yield return new WaitForSeconds(time);
        controlable = true;
    }

    private void Move()
    {
        int x = 0, y = 0;

        if (Input.GetKeyDown(KeyCode.W))
            y = 1;
        else if (Input.GetKeyDown(KeyCode.S))
            y = -1;
        else if (Input.GetKeyDown(KeyCode.A))
            x = -1;
        else if (Input.GetKeyDown(KeyCode.D))
            x = 1;

        transform.Translate(new Vector3(x, y) * cellSize);
    }

    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            gridController.ActivateCell(transform.position);
    }
}
