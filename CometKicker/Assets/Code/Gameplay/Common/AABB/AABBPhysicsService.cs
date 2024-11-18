using UnityEngine;

namespace Code.Gameplay.Common.AABB
{
    public class AABBPhysicsService : IAABBPhysicsService
    {
        public bool IsColliding(GameEntity entityA, GameEntity entityB)
        {
            Vector2 positionA = entityA.WorldPosition;
            Vector2 sizeA = GetSpriteSize(entityA.SpriteRenderer);

            Vector2 positionB = entityB.WorldPosition;
            Vector2 sizeB = GetSpriteSize(entityB.SpriteRenderer);

            return IsAABBIntersecting(positionA, sizeA, positionB, sizeB);
        }
        
        public bool IsWithinCameraBounds(Vector2 position, Vector2 size, GameEntity camera)
        {
            float halfWidth = size.x / 2;
            float halfHeight = size.y / 2;
            Vector3 bottomLeft = camera.Camera.ViewportToWorldPoint(new Vector3(0, 0, camera.Camera.nearClipPlane));
            Vector3 topRight = camera.Camera.ViewportToWorldPoint(new Vector3(1, 1, camera.Camera.nearClipPlane));

            return  position.x - halfWidth >= bottomLeft.x && position.x + halfWidth <= topRight.x &&
                    position.y - halfHeight >= bottomLeft.y && position.y + halfHeight <= topRight.y;
        }

        public ((bool xWithinBounds, float xOutDistance), (bool yWithinBounds, float yOutDistance))  XYWithinCameraBounds(Vector2 position, Vector2 size, GameEntity camera)
        {
            float halfWidth = size.x / 2;
            float halfHeight = size.y / 2;
            Vector3 bottomLeft = camera.Camera.ViewportToWorldPoint(new Vector3(0, 0, camera.Camera.nearClipPlane));
            Vector3 topRight = camera.Camera.ViewportToWorldPoint(new Vector3(1, 1, camera.Camera.nearClipPlane));

           
            bool xWithinBounds = position.x - halfWidth >= bottomLeft.x && position.x + halfWidth <= topRight.x;
            float xOutDistance = 0;
            if (!xWithinBounds)
            {
                if (position.x - halfWidth < bottomLeft.x)
                {
                    xOutDistance = (position.x - halfWidth) - bottomLeft.x;
                }
                else if (position.x + halfWidth > topRight.x)
                {
                    xOutDistance = (position.x + halfWidth) - topRight.x;
                }
            }
            
            bool yWithinBounds = position.y - halfHeight >= bottomLeft.y && position.y + halfHeight <= topRight.y;
            float yOutDistance = 0;
            if (!yWithinBounds)
            {
                if (position.y - halfHeight < bottomLeft.y)
                {
                    yOutDistance = (position.y - halfHeight) - bottomLeft.y;
                }
                else if (position.y + halfHeight > topRight.y)
                {
                    yOutDistance = (position.y + halfHeight) - topRight.y;
                }
            }

            return ((xWithinBounds, xOutDistance), (yWithinBounds, yOutDistance));
        }
        
        private Vector2 GetSpriteSize(SpriteRenderer spriteRenderer)
        {
            Vector2 size = spriteRenderer.sprite.bounds.size;
            return new Vector2(size.x, size.y);
        }
        private bool IsAABBIntersecting(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {
            return positionA.x - sizeA.x / 2 < positionB.x + sizeB.x / 2 &&
                   positionA.x + sizeA.x / 2 > positionB.x - sizeB.x / 2 &&
                   positionA.y - sizeA.y / 2 < positionB.y + sizeB.y / 2 &&
                   positionA.y + sizeA.y / 2 > positionB.y - sizeB.y / 2;
        }
        private bool IsWithinBounds(Vector2 position, Vector2 size, GameEntity camera)
        {
            Vector3 bottomLeft = camera.Camera.ViewportToWorldPoint(new Vector3(0, 0, camera.Camera.nearClipPlane));
            Vector3 topRight = camera.Camera.ViewportToWorldPoint(new Vector3(1, 1, camera.Camera.nearClipPlane));

            return position.x - size.x / 2 >= bottomLeft.x && position.x + size.x / 2 <= topRight.x &&
                   position.y - size.y / 2 >= bottomLeft.y && position.y + size.y / 2 <= topRight.y;
        }
    }
}