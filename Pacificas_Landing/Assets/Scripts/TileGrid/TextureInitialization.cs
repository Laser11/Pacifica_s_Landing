using UnityEditor;
using UnityEngine;
using System.Collections;
public static class TextureInitialization
{
   public static int[] getRedAssets()
   {
       //set a map as an asset then proceed to load it.
       AssetDatabase.ImportAsset("Assets/Resources/basicmap.png", ImportAssetOptions.ForceUpdate);
       Texture2D mapProcess = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Resources/basicmap.png");
       int[] john = new int[(mapProcess.width)*(mapProcess.height)];
       for(int i = 0; i< mapProcess.height- 1; i++)
       {
           for(int j = 0; j < mapProcess.width - 1; j++)
           {
                float redVal = mapProcess.GetPixel(j, i).r;
                int location = i*(mapProcess.width-1)+j;
                if(location%1000 == 1){
                	    Debug.Log("location: " + location + "x-value: " + i);
                }
                if(redVal < .25)
                {
                    john[location] = 1;
                }
                else if( redVal < .5)
                {
                    john[location] = 2;
                }
                else if( redVal < .75)
                {
                    john[location] = 3;
                }
                else
                {
                    john[location] = 4;
                }
           }
           
       }
       return john;
      // mapProcess.GetPixels
   }
   public static int[] getBlueAssets()
   {
       //set a map as an asset then proceed to load it.
       AssetDatabase.ImportAsset("Resources/basicmap.png", ImportAssetOptions.ForceUpdate);
       Texture2D mapProcess = AssetDatabase.LoadAssetAtPath<Texture2D>("Rescources/basicmap.png");
       int[] john = new int[(mapProcess.width)*(mapProcess.height)];
       for(int i = 0; i< mapProcess.height - 1 ; i++)
       {
           for(int j = 0; i < mapProcess.width - 1; j++)
           {
                float blueVal = mapProcess.GetPixel(j, i).b;
                int location = i*mapProcess.width+j;
                if(blueVal < .25)
                {
                    john[location] = 1;
                }
                else if( blueVal < .5)
                {
                    john[location] = 2;
                }
                else if( blueVal < .75)
                {
                    john[location] = 3;
                }
                else
                {
                    john[location] = 4;
                }
           }
           
       }
       return john;
      // mapProcess.GetPixels
   }
   public static int[] getGreenAssets()
   {
       //set a map as an asset then proceed to load it.
       AssetDatabase.ImportAsset("Resources/basicmap.png", ImportAssetOptions.ForceUpdate);
       Texture2D mapProcess = AssetDatabase.LoadAssetAtPath<Texture2D>("Rescources/basicmap.png");
       int[] john = new int[(mapProcess.width)*(mapProcess.height)];
       for(int i = 0; i< mapProcess.height; i++)
       {
           for(int j = 0; i < mapProcess.width; j++)
           {
                float greenVal = mapProcess.GetPixel(j, i).g;
                int location = i*mapProcess.width+j;
                if(greenVal < .25)
                {
                    john[location] = 1;
                }
                else if( greenVal < .5)
                {
                    john[location] = 2;
                }
                else if( greenVal < .75)
                {
                    john[location] = 3;
                }
                else
                {
                    john[location] = 4;
                }
           }
           
       }
       return john;
      // mapProcess.GetPixels
   }
}