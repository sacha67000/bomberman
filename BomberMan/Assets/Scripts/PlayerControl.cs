using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed = 6.0F;
    public float rotateSpeed = 6.0F;
    private float gravity = 20.0F;
    public int bombRange = 3;
    public int bombNumber = 2;
    public int player;

    private Vector3 moveDirection = Vector3.zero;

    private MapScript map;

    public GameObject bomb;

    private Animation anim;

    void Start()
    {
        map = GameObject.Find("Map").GetComponent<MapScript>();
        anim = GameObject.Find("Player" + player).GetComponent<Animation>();
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Horizontal_Player" + player) > 0)
            {
                transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                anim.Play("Run01");
            }
            else if (Input.GetAxis("Horizontal_Player" + player) < 0)
            {
                transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                anim.Play("Run01");
            }
            else if (Input.GetAxis("Vertical_Player" + player) > 0)
            {
                transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                anim.Play("Run01");
            }
            else if (Input.GetAxis("Vertical_Player" + player) < 0)
            {
                transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                anim.Play("Run01");
            }
            moveDirection = new Vector3(Input.GetAxis("Horizontal_Player" + player), 0, Input.GetAxis("Vertical_Player" + player));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= (speed / 2);
            if (Input.GetButtonUp("Fire" + player))
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

    public void DestroyPlayer()
    {
        map.players.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
