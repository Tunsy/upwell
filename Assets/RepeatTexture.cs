using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatTexture : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite[] sprites;
    Collider2D col;
    public bool isForeground;

    void Awake()
    {
        // Get the current sprite with an unscaled size
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        if (sprites.Length == 0) return;

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childSprite.sprite = sprites[(int)Random.Range(0, sprites.Length)];
        if (isForeground)
            childSprite.sortingLayerName = "Tiles";
        else
            childSprite.sortingLayerName = "Background";
        childPrefab.transform.position = transform.position;


        // Loop through and spit out repeated tiles
        GameObject child;
        for (int j = 0, m = (int)Mathf.Ceil(col.bounds.size.x/spriteSize.x); j < m; j++){
            for (int i = 0, l = (int)Mathf.Round(col.bounds.size.y/spriteSize.y); i < l; i++)
            {
                child = Instantiate(childPrefab) as GameObject;
                childSprite.sprite = sprites[(int)Random.Range(0, sprites.Length)];
                childSprite.color = sprite.color;
                child.transform.position = transform.position - (new Vector3(spriteSize.x * j, spriteSize.y * i, 0)
                    - new Vector3(0, transform.localScale.y == 1 ? 0 : (1 / 2f * sprite.bounds.size.y), 0)
                    - new Vector3(col.bounds.size.x / 2, col.bounds.size.y / 2, 0)
                    + new Vector3(spriteSize.x/2, spriteSize.y/2, 0));
                child.transform.rotation = (transform.rotation);
                child.transform.parent = transform;
                child.gameObject.layer = gameObject.layer;
                child.gameObject.tag = gameObject.tag;
            }
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;

        // Disable the currently existing sprite component since its now a repeated image
        sprite.enabled = false;

        col.enabled = isForeground;
    }
}