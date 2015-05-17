using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    public bool destroyable;

    public static Block getBlockAt(float x, float y) {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block b in blocks) {
            if (b.transform.position.x == x &&
                b.transform.position.y == y)
                return b;
        }
        return null;
    }

    public static void destroyBlockAt(float x, float y) {
        Block b = getBlockAt(x, y);
        if (b != null && b.destroyable)
            Destroy(b.gameObject);
    }
}