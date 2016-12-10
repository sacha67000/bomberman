using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed = 6.0F;
    private float gravity = 20.0F;
    public int bombRange = 3;
    public int bombNumber = 2;
    private Vector3 moveDirection = Vector3.zero;

    private MapScript map;

    public GameObject bomb;

    void Start()
    {
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= (speed / 2);
            if (Input.GetButtonUp("Jump"))
            {
                SpawnBomb();
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void SpawnBomb()
    {
        float x = GetBombPosition(this.gameObject.transform.position.x);
        float z = GetBombPosition(this.gameObject.transform.position.z);
        if (map.blockArray[(int)x, (int)z] == null && bombNumber > 0)
        {
            map.blockArray[(int)x, (int)z] = (GameObject)Instantiate(bomb, new Vector3(x, 0.5f, z + 0.35f), Quaternion.identity);
            map.blockArray[(int)x, (int)z].GetComponent<BombScript>().bombRange = this.bombRange;
            map.blockArray[(int)x, (int)z].GetComponent<BombScript>().owner = this.gameObject;
            bombNumber -= 1;
        }
    }

    float GetBombPosition(float pos)
    {
        float number_end = pos % 1;
        float result = (int)pos;
        if (number_end >= 0.5)
            result += 1;
        return result;
    }
}
