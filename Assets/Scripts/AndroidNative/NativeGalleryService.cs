using System.Collections;
using System.Collections.Generic;
using RestClient.Core.Singletons;
using UnityEngine;
using UnityEngine.UI;

public class NativeGalleryService : MonoBehaviour
{
    public void PickImage()
    {
        string selectedPath = "";
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log( "Image path: " + path );
            selectedPath = path;
            Debug.Log( "Image path: " + selectedPath );
        });

        Debug.Log( "Permission result: " + permission );
    }
}
