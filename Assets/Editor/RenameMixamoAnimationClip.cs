using UnityEditor;

public class RenameMixamoAnimationClip
{
    [MenuItem("Assets/Auto Rename Mixamo AnimationClip")]
    private static void RenameMixamoANimationClips()
    {
        var objs = Selection.gameObjects;
        if (objs == null) return;

        for (var i = 0; i < objs.Length; i++)
        {
            var assetPath = AssetDatabase.GetAssetPath(objs[i]);

            var modelImporter = (ModelImporter)AssetImporter.GetAtPath(assetPath);
            if (modelImporter == null) continue;

            var clips = modelImporter.clipAnimations; // get first clip
            if (clips == null || clips.Length ==0)
                clips = modelImporter.defaultClipAnimations;

            for (var j = 0; j < clips.Length; j++)
            {
                clips[j].name = objs[i].name;
            }

            modelImporter.clipAnimations = clips;
            modelImporter.SaveAndReimport();
        }
    }
}
