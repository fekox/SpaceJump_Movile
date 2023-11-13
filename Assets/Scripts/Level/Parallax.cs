using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool scrollLeft;

    [SerializeField] private bool isNotTheLevelScene;

    private float textureWidth;
    void Start()
    {
        SetupTexture();

        if (scrollLeft) 
        {
            moveSpeed = -moveSpeed;
        }
    }

    private void Update()
    {
        if (isNotTheLevelScene) 
        {
            Scroll();
            CheckReset();
        }
    }

    private void SetupTexture() 
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    public void Scroll() 
    {
        float speedX = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(speedX, 0f, 0f);
    }

    public void CheckReset() 
    {
        if ((Mathf.Abs(transform.position.x) - textureWidth) > 0) 
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
}
