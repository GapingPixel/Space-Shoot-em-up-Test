using UnityEngine;

namespace ShmupBoss
{
    /// <summary>
    /// Handles shooting all player weapons based on input or auto fire.
    /// </summary>
    [AddComponentMenu("Shmup Boss/Weapons/Shooters/Player Shooter")]
    [RequireComponent(typeof(Player))]
    public class PlayerShooter : MonoBehaviour
    {
        private Player player;
        public Object MissileObject;
        private int _count = 0;
        private void Awake()
        {
            player = GetComponent<Player>();
            //Instantiate(MissileObject, new Vector2(transform.position.x+0.5f, transform.position.y), Quaternion.identity);
        }

        void Update()
        {
            if (PlayerInput.IsFire1Pressed || PlayerInput.IsAutoFireEnabled)
            {
                if (_count == 0)
                {
                    Instantiate(MissileObject, new Vector2(transform.position.x+1.2f, transform.position.y),
                        Quaternion.identity);
                    _count = 1;
                }
                
                for (int i = 0; i < player.MunitionWeapons.Length; i++)
                {
                    if(player.MunitionWeapons[i] == null)
                    {
                        continue;
                    }

                    player.MunitionWeapons[i].FireWhenPossible(FacingDirections.Player);
                   
                }

                for (int i = 0; i < player.ParticleWeapons.Length; i++)
                {
                    if (player.ParticleWeapons[i] == null)
                    {
                        continue;
                    }

                    player.ParticleWeapons[i].FireWhenPossible(FacingDirections.Player);
                }
            }
        }
        
        private void FixedUpdate()
        {
            if (_count >= 1)
            {
                _count++;
                if (_count == 50)
                {
                    _count = 0;
                }
            }
        }
    }
}