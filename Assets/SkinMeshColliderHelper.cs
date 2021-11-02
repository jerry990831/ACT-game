using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinMeshColliderHelper : MonoBehaviour
{
    public SkinnedMeshRenderer MeshRenderer;
    public MeshCollider Collider;

    /// <summary>
    /// 采样间隔
    /// </summary>
    public int FrameInterval;
    /// <summary>
    /// 释放资源间隔
    /// </summary>
    float _unloadResouceTime = 1.5f;
    float _unloadTimer;
    int _interval;

    private void Start()
    {
        if (MeshRenderer == null)
        {
            MeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
            if (MeshRenderer == null)
            {
                DestroyImmediate(this);
                return;
            }
        }
        if (Collider == null)
        {
            Collider = MeshRenderer.GetComponent<MeshCollider>();
            if (Collider == null)
            {
                Collider = MeshRenderer.gameObject.AddComponent<MeshCollider>();

            }
        }
    }

    void Update()
    {
        if (FrameInterval <= _interval)
        {
            _interval = 0;
            Mesh colliderMesh = new Mesh();
            MeshRenderer.BakeMesh(colliderMesh); //更新mesh
            Collider.sharedMesh = null;
            Collider.sharedMesh = colliderMesh; //将新的mesh赋给meshcollider

            colliderMesh = null;


        }
        else
        {
            _interval += FrameInterval;
        }

        //定时释放资源，防止内存泄露
        if (_unloadTimer < _unloadResouceTime)
        {
            _unloadTimer += Time.deltaTime;

        }
        else
        {
            Resources.UnloadUnusedAssets();
            _unloadTimer = 0;

        }
    }
}
