using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CocosSharp;

namespace BouncingGame
{
    /// <summary>
    /// メインのシーンクラス
    /// </summary>
    class GameScene : CCScene
    {
        CCLayer mainLayer;

        public GameScene(CCWindow mainWindow) : base (mainWindow)
        {
            // レイヤーを作成する
            mainLayer = new CCLayer();

            // シーンにレイヤーを追加する
            AddChild(mainLayer);
        }

    }
}
