using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    // Time after which the bomb explodes
    float time = 3.0f;

	// Worm game objects, needed to destroy the worms after being hit 
	public GameObject worm1;
	public GameObject worm2;
	public GameObject worm3;

    // Explosion Prefab
    public GameObject explosion;

	    void Start ()
	{
        // Call the Explode function after a few seconds
        Invoke("Explode", time);
    }
    
    void Explode()
	{
        // Remove Bomb from game
        Destroy(gameObject);

        // Spawn Explosion
        Instantiate(explosion,
                    transform.position,
                    Quaternion.identity);

        // Destroy stuff
        Vector2 pos = transform.position;
        Block.destroyBlockAt(pos.x,   pos.y);   // same
        Block.destroyBlockAt(pos.x,   pos.y+1); // top
        Block.destroyBlockAt(pos.x+1, pos.y);   // right
        Block.destroyBlockAt(pos.x,   pos.y-1); // bottom
        Block.destroyBlockAt(pos.x-1, pos.y);   // left


		destroyBomber ();
    }


	// Checks if the bomb explosion ranges to Bomberman position. Also checks if bomb hits worm. 
	void destroyBomber()
	{
		if (Move.bombermanPositionRounded == BombDrop.roundedPos || Move.bombermanPositionRounded == BombDrop.rangeUp 
						|| Move.bombermanPositionRounded == BombDrop.rangeLeft || Move.bombermanPositionRounded == BombDrop.rangeRight
						|| Move.bombermanPositionRounded == BombDrop.rangeDown) 
		{
			Move.BombExplosion();
		}

	
		if (GetPosition.roundedWormPos1 == BombDrop.roundedPos || GetPosition.roundedWormPos1 == BombDrop.rangeUp 
						|| GetPosition.roundedWormPos1 == BombDrop.rangeLeft || GetPosition.roundedWormPos1 == BombDrop.rangeRight
						|| GetPosition.roundedWormPos1 == BombDrop.rangeDown)
		{

					if(worm1 == null){
						worm1 = GameObject.Find ("Worm1");
				Destroy (worm1.gameObject);}
		}

		if (GetPosition.roundedWormPos2 == BombDrop.roundedPos || GetPosition.roundedWormPos2 == BombDrop.rangeUp 
						|| GetPosition.roundedWormPos2 == BombDrop.rangeLeft || GetPosition.roundedWormPos2 == BombDrop.rangeRight
						|| GetPosition.roundedWormPos2 == BombDrop.rangeDown) {
			if (worm2 == null){
						worm2 = GameObject.Find ("Worm2");
				Destroy (worm2.gameObject);}
				}
		
		if (GetPosition.roundedWormPos3 == BombDrop.roundedPos || GetPosition.roundedWormPos3 == BombDrop.rangeUp 
			|| GetPosition.roundedWormPos3 == BombDrop.rangeLeft || GetPosition.roundedWormPos3 == BombDrop.rangeRight
			|| GetPosition.roundedWormPos3 == BombDrop.rangeDown)
		{
				if (worm3 == null){
						worm3 = GameObject.Find ("Worm3");
				Destroy (worm3.gameObject);}
		}
		
	}
}
