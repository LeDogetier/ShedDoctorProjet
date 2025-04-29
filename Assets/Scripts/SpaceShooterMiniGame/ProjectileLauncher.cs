using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Projectile ProjectilePrefab; 
    public Transform ProjectileStartPosition; 
    public int MaxMagazineSize = 10; 

    private List<Projectile> _projectilePool = new List<Projectile>();

    void Start()
    {
        for (int i = 0; i < MaxMagazineSize; i++)
        {
            Projectile projectile = ProjectilePrefab.Clone();
            _projectilePool.Add(projectile);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Projectile projectile = GetAvailableProjectile();
        if (projectile != null)
        {
            projectile.Launch(ProjectileStartPosition.position);
        }
    }

    private Projectile GetAvailableProjectile()
    {
        foreach (Projectile projectile in _projectilePool)
        {
            if (!projectile.IsEnabled)
            {
                return projectile;
            }
        }
        return null;
    }
}