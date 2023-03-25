using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{
    
    public LayerMask collisionMask;	
	public const float skinWidth = .015f;
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;
	
	public BoxCollider2D box2D;
	public RaycastOrigins raycastOrigins;

    public virtual void Start() {
		CalculateRaySpacing ();
	}

	public void UpdateRaycastOrigins() {
		Bounds bounds = box2D.bounds;
		bounds.Expand (skinWidth * -2);
		
		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}
	
	public void CalculateRaySpacing() {
		Bounds bounds = box2D.bounds;
		bounds.Expand (skinWidth * -2);
		
		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);
		
		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}
	
	public struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

    public void OnDrawGizmos() {
        if(box2D != null && !Application.isPlaying){
            CalculateRaySpacing();
            UpdateRaycastOrigins();            
            for (int i = 0; i < horizontalRayCount; i++)
            {                
                Debug.DrawRay(raycastOrigins.bottomRight + Vector2.up * (horizontalRaySpacing * i), Vector2.right * 2f,Color.green);
                Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.up * (horizontalRaySpacing * i), Vector2.left * 2f,Color.green);
            }

            for (int i = 0; i < verticalRayCount; i++){
                Debug.DrawRay(raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i), Vector2.up * 2,Color.red);
                Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * (verticalRaySpacing * i), Vector2.down * 2,Color.red);
            }
        }
    }
}
