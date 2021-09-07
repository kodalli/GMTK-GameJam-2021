using System;
using System.Collections;
using System.Collections.Generic;
using CharTween;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueAnimationTest : MonoBehaviour
{
    // private void Start()
    // {
    //     // Set text
    //     var text = GetComponent<TMP_Text>();
    //     text.text = "DETERMINATION";
    //
    //     var tweener = text.GetCharTweener();    
    //     for (var i = 0; i < tweener.CharacterCount; ++i)
    //     {
    //         // Move characters in a circle
    //         var circleTween = tweener.DOCircle(i, 0.05f, 0.5f)
    //             .SetEase(Ease.Linear)
    //             .SetLoops(-1, LoopType.Restart);
    //
    //         // Oscillate character color between yellow and white
    //         var colorTween = tweener.DOColor(i, Color.yellow, 0.5f)
    //             .SetLoops(-1, LoopType.Yoyo);
    //
    //         // Offset animations based on character index in string
    //         var timeOffset = Mathf.Lerp(0, 1, i / (float)(tweener.CharacterCount - 1));
    //         circleTween.fullPosition = timeOffset;
    //         colorTween.fullPosition = timeOffset;
    //     }
    // }

    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        foreach (var charInfo in textInfo.characterInfo)
        {
            if(!charInfo.isVisible)
                continue;
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for (int i = 0; i < 4; ++i)
            {
                var orig = verts[charInfo.vertexIndex + i];
                verts[charInfo.vertexIndex + i] =
                    orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
            }
        }

        foreach (var meshInfo in textInfo.meshInfo.WithIndex())
        {
            meshInfo.item.mesh.vertices = meshInfo.item.vertices;
            textComponent.UpdateGeometry(meshInfo.item.mesh, meshInfo.index);
        }
    }
}