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
        /// <summary>
        /// レイヤー
        /// 表示の階層を管理する
        /// </summary>
        CCLayer mainLayer;

        /// <summary>
        /// スプライト
        /// リソースを管理する
        /// </summary>
        CCSprite paddleSprite;

        // ボール用のスプライト
        CCSprite ballSprite;

        /// <summary>
        /// ラベル
        /// 文字リソースを管理する
        /// </summary>
        CCLabelTtf scoreLabel;

        /// <summary>
        /// タッチ判定用のリスナー
        /// </summary>
        CCEventListenerTouchAllAtOnce touchListener;

        public GameScene(CCWindow mainWindow) : base (mainWindow)
        {
            // レイヤーを作成する
            mainLayer = new CCLayer();

            // シーンにレイヤーを追加する
            AddChild(mainLayer);

            // リソースを作成
            paddleSprite = new CCSprite("paddle");
            paddleSprite.PositionX = 100;
            paddleSprite.PositionY = 100;
            // レイヤーにリソースを追加
            mainLayer.AddChild(paddleSprite);

            // ボールのスプライトを作成
            ballSprite = new CCSprite("ball");
            ballSprite.PositionX = 320;
            ballSprite.PositionY = 600;
            // レイヤーにボールを追加
            mainLayer.AddChild(ballSprite);

            // ラベルを作成
            scoreLabel = new CCLabelTtf("Score : 0", "arial-22", 22);
            scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MinX + 20;
            scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
            // 基準位置を変更(デフォルトはセンター)
            scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;
            // ラベルをレイヤーに追加
            mainLayer.AddChild(scoreLabel);

            // ロジックを追加
            Schedule(RunGameLogic);

            // タッチリスナーの設定
            touchListener = new CCEventListenerTouchAllAtOnce();
            // タッチした状態で動かしたときのイベント
            touchListener.OnTouchesMoved = HandleTouchesMoved;
            AddEventListener(touchListener, this);
        }

        // ボール進行方向用のパラメータ
        float ballXVelocity;
        float ballYVelocity;

        // 移動定数
        const float gravity = 140;

        // スコア
        int score;

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="frameTimeInSeconds"></param>
        void RunGameLogic(float frameTimeInSeconds)
        {
            // 移動距離を設定
            ballYVelocity += frameTimeInSeconds * -gravity;
            // ボールの位置を設定
            ballSprite.PositionX += ballXVelocity * frameTimeInSeconds;
            ballSprite.PositionY += ballYVelocity * frameTimeInSeconds;

            // ボールとバーが重なったか判定
            bool doesBallOverlapPaddle = ballSprite.BoundingBoxTransformedToParent.IntersectsRect(
                paddleSprite.BoundingBoxTransformedToParent);

            // ボールが落下しているか判定
            bool isMovingDownward = ballYVelocity < 0;

            if (doesBallOverlapPaddle && isMovingDownward)
            {
                // ボール落下中にバーに当たったら
                // ボールのY進行方向を反転
                ballYVelocity *= -1;
                // 移動速度の範囲を設定
                const float minXVelocity = -300;
                const float maxXVelocity = 300;
                // 移動距離を変更
                ballXVelocity = CCRandom.GetRandomFloat(minXVelocity, maxXVelocity);

                // スコアを加算
                score++;
                scoreLabel.Text = "Score : " + score;
            }

            // ボールの位置を取得
            float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
            float ballLeft = ballSprite.BoundingBoxTransformedToParent.MidX;

            // スクリーンの範囲を取得
            float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
            float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

            // ボールが画面外に行ってしまうか判定
            bool shouldReflectXVelocity =
                (ballRight > screenRight && ballXVelocity > 0) ||
                (ballLeft < screenLeft && ballLeft < 0);

            if (shouldReflectXVelocity)
            {
                // ボールのX進行方向を反転
                ballXVelocity *= -1;
            }
        }

        /// <summary>
        /// タッチイベントハンドラーの設定
        /// </summary>
        /// <param name="touches"></param>
        /// <param name="touchEvent"></param>
        void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
        {
            // タッチ位置を取得
            var locationOnScreen = touches[0].LocationOnScreen;
            // 棒の位置を設定
            paddleSprite.PositionX = locationOnScreen.X;
        }

    }
}
