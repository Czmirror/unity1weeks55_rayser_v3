# unity1weeks55_rayser_v3  
RAYSER(V3)の公開ソースです（Scriptのみ）  
一週間ゲームジャム「そろえる」で実装したRAYSER(V3)のスクリプトです。  
https://unityroom.com/games/rayser_v3  
  
# 使用ライブラリ・アセット  
- UniRx  
ゲームステータス更新などで主に使用  
- DOTween Pro  
タイトル画面UI切り替えやステージ移動処理などで主に使用  
- Very Animation  
VRMキャラクターのアニメーションなどに使用  
- Cinemachine
トップビュー、サイドビュー、フロントビューのカメラの切り替えで使用しています。
- Input System
トップビュー、サイドビュー、フロントビューの自機の操作で使用しています。
  
# 使用ソフト  
- VRoid Studio  
キャラクター造形  
  
# ゲームについて  
縦型シューティングからサイドビューやフロントビューに切り替わるタイプのシューティングゲームを作ってみたくてチャレンジしてみました。  
シューティングゲームにストーリー性を持たせたかったので、ゲーム進行中に会話を加えたりしています。  
  
# スクリプト説明  
Scripts  
├── BGM （BGMを切り替えるスクリプトです）  
│   ├── BGMSwitch.cs  
│   └── BGMSwitch.cs.meta  
├── BGM.meta  
├── Capsule （パワーアップなどのカプセル取得、カプセル効果実現などの処理を記載したスクリプトです）  
│   ├── CapsuleAnnihilation.cs  
│   ├── CapsuleAnnihilation.cs.meta  
│   ├── CapsuleBonus.cs  
│   ├── CapsuleBonus.cs.meta  
│   ├── CapsuleEnum.cs  
│   ├── CapsuleEnum.cs.meta  
│   ├── CapsuleLaserPowerUp.cs  
│   ├── CapsuleLaserPowerUp.cs.meta  
│   ├── CapsuleMove.cs  
│   ├── CapsuleMove.cs.meta  
│   ├── CapsuleShieldRecover.cs  
│   ├── CapsuleShieldRecover.cs.meta  
│   ├── CapsuleSpawner.cs  
│   ├── CapsuleSpawner.cs.meta  
│   ├── CapsuleSpeedUp.cs  
│   ├── CapsuleSpeedUp.cs.meta  
│   ├── CapsuleStock.cs  
│   ├── CapsuleStock.cs.meta  
│   ├── EnemyCapsuleDrop.cs  
│   ├── EnemyCapsuleDrop.cs.meta  
│   ├── ICapsuleinfo.cs  
│   ├── ICapsuleinfo.cs.meta  
│   ├── PlayerCapsule.cs  
│   ├── PlayerCapsule.cs.meta  
│   ├── PresenterCapsule.cs  
│   └── PresenterCapsule.cs.meta  
├── Capsule.meta  
├── CustomEditor EditorでSceneObjectを定義するためのクラスを記載しています  
│   ├── SceneObject.cs  
│   └── SceneObject.cs.meta  
├── CustomEditor.meta  
├── Damage ダメージ関連のインターフェースです  
│   ├── IDamagable.cs  
│   ├── IDamagable.cs.meta  
│   ├── IDamageableToEnemy.cs  
│   ├── IDamageableToEnemy.cs.meta  
│   ├── IDamageableToPlayer.cs  
│   └── IDamageableToPlayer.cs.meta  
├── Damage.meta  
├── EnemyBreakdown ボスを倒した時のブレイクダウン処理のスクリプトです  
│   ├── StageEnemyBreakdown.cs  
│   └── StageEnemyBreakdown.cs.meta  
├── EnemyBreakdown.meta  
├── EnemyMove 敵の動きのスクリプトです  
│   ├── Stage1BossMove.cs  
│   ├── Stage1BossMove.cs.meta  
│   ├── Stage1EnemyMoveChase.cs  
│   ├── Stage1EnemyMoveChase.cs.meta  
│   ├── Stage2BossMove.cs  
│   ├── Stage2BossMove.cs.meta  
│   ├── Stage2EnemyForwardMove.cs  
│   ├── Stage2EnemyForwardMove.cs.meta  
│   ├── Stage3EnemyMoveApproach.cs  
│   └── Stage3EnemyMoveApproach.cs.meta  
├── EnemyMove.meta  
├── EnemySpawn 敵機やボスを登場させるスクリプトです  
│   ├── EnemyDisappear.cs  
│   ├── EnemyDisappear.cs.meta  
│   ├── Stage1BossEnemySpawner.cs  
│   ├── Stage1BossEnemySpawner.cs.meta  
│   ├── Stage1BossSpawner.cs  
│   ├── Stage1BossSpawner.cs.meta  
│   ├── Stage1EnemySpawner.cs  
│   ├── Stage1EnemySpawner.cs.meta  
│   ├── Stage2BossEnemySpawner.cs  
│   ├── Stage2BossEnemySpawner.cs.meta  
│   ├── Stage2EnemySpawner.cs  
│   ├── Stage2EnemySpawner.cs.meta  
│   ├── Stage3EnemySpawner.cs  
│   └── Stage3EnemySpawner.cs.meta  
├── EnemySpawn.meta  
├── Event ステージクリア時などの自機や敵機の移動処理などを行なっています。  
│   ├── EnemyBattleshipStage2Move.cs  
│   ├── EnemyBattleshipStage2Move.cs.meta  
│   ├── EventPlayerMove.cs  
│   ├── EventPlayerMove.cs.meta  
│   ├── Signal UniRxのMessageBrokerなどで使用するステージ切り替え、カプセル発動、敵機撃退時のスコア処理などを発信するPub部分のクラスです。  
│   │   ├── AnnihilationEnemy.cs  
│   │   ├── AnnihilationEnemy.cs.meta  
│   │   ├── CapsuleSpawn.cs  
│   │   ├── CapsuleSpawn.cs.meta  
│   │   ├── EnemyBreakdownSignal.cs  
│   │   ├── EnemyBreakdownSignal.cs.meta  
│   │   ├── GameClear.cs  
│   │   ├── GameClear.cs.meta  
│   │   ├── GameStartEventEnd.cs  
│   │   ├── GameStartEventEnd.cs.meta  
│   │   ├── Gameover.cs  
│   │   ├── Gameover.cs.meta  
│   │   ├── PlayerGetCapsule.cs  
│   │   ├── PlayerGetCapsule.cs.meta  
│   │   ├── PlayerLaserLevelUp.cs  
│   │   ├── PlayerLaserLevelUp.cs.meta  
│   │   ├── PlayerMoveSpeedLevelUp.cs  
│   │   ├── PlayerMoveSpeedLevelUp.cs.meta  
│   │   ├── PlayerShieldRecover.cs  
│   │   ├── PlayerShieldRecover.cs.meta  
│   │   ├── ScoreAccumulation.cs  
│   │   ├── ScoreAccumulation.cs.meta  
│   │   ├── Stage1BossEncounter.cs  
│   │   ├── Stage1BossEncounter.cs.meta  
│   │   ├── Stage2BossEncounter.cs  
│   │   ├── Stage2BossEncounter.cs.meta  
│   │   ├── Stage2IntervalStart.cs  
│   │   ├── Stage2IntervalStart.cs.meta  
│   │   ├── Stage2Start.cs  
│   │   ├── Stage2Start.cs.meta  
│   │   ├── Stage3IntervalStart.cs  
│   │   ├── Stage3IntervalStart.cs.meta  
│   │   ├── Stage3Start.cs  
│   │   └── Stage3Start.cs.meta  
│   ├── Signal.meta  
│   ├── Stage1BossDestroy.cs  
│   ├── Stage1BossDestroy.cs.meta  
│   ├── Stage2BossDestroy.cs  
│   ├── Stage2BossDestroy.cs.meta  
│   ├── Stage3BossDestroy.cs  
│   ├── Stage3BossDestroy.cs.meta  
│   ├── StarfieldStage2Move.cs  
│   ├── StarfieldStage2Move.cs.meta  
│   ├── StarfieldStage3Move.cs  
│   └── StarfieldStage3Move.cs.meta  
├── Event.meta  
├── Explosion 敵機撃破時の爆破処理のスクリプトです  
│   ├── Explode.cs  
│   ├── Explode.cs.meta  
│   ├── Stage3BossExplosion.cs  
│   └── Stage3BossExplosion.cs.meta  
├── Explosion.meta  
├── InputSystem インプットシステムの自機の移動処理を記載したスクリプトです  
│   ├── PlayerController.cs  
│   └── PlayerController.cs.meta  
├── InputSystem.meta  
├── Obstacle ステージ１のフェンスを表示するスクリプトです  
│   ├── Stage1WallVisible.cs  
│   └── Stage1WallVisible.cs.meta  
├── Obstacle.meta  
├── PlayerMove ステージ毎にトップビュー、サイドビュー、フロントビューの自機の移動切り替え、自機のスピードアップ処理を記載したスクリプトです。  
│   ├── FrontViewMove.cs  
│   ├── FrontViewMove.cs.meta  
│   ├── IMovable.cs  
│   ├── IMovable.cs.meta  
│   ├── PlayerMoveCore.cs  
│   ├── PlayerMoveCore.cs.meta  
│   ├── PlayerSpeedLevel.cs  
│   ├── PlayerSpeedLevel.cs.meta  
│   ├── PresenterSpeedLevel.cs  
│   ├── PresenterSpeedLevel.cs.meta  
│   ├── SideViewMove.cs  
│   ├── SideViewMove.cs.meta  
│   ├── TopViewMove.cs  
│   └── TopViewMove.cs.meta  
├── PlayerMove.meta  
├── Score スコア加算処理のスクリプトです。  
│   ├── EnemyScore.cs  
│   ├── EnemyScore.cs.meta  
│   ├── PresenterScore.cs  
│   ├── PresenterScore.cs.meta  
│   ├── ScoreCounter.cs  
│   └── ScoreCounter.cs.meta  
├── Score.meta  
├── Shield 自機と敵機のシールド（耐久値）のスクリプトです。自機のシールドUI更新処理なども。  
│   ├── EnemyShield.cs  
│   ├── EnemyShield.cs.meta  
│   ├── IShield.cs  
│   ├── IShield.cs.meta  
│   ├── PlayerShield.cs  
│   ├── PlayerShield.cs.meta  
│   ├── PlayerShieldEffect.cs  
│   ├── PlayerShieldEffect.cs.meta  
│   ├── PresenterPlayerShield.cs  
│   ├── PresenterPlayerShield.cs.meta  
│   ├── PresenterPlayerShieldPercent.cs  
│   └── PresenterPlayerShieldPercent.cs.meta  
├── Shield.meta  
├── Status ゲームステータスを管理するスクリプトです。  
│   ├── GameState.cs  
│   ├── GameState.cs.meta  
│   ├── GameStatus.cs  
│   └── GameStatus.cs.meta  
├── Status.meta  
├── Target 敵機のロックオン処理のスクリプトです。  
│   ├── EnemyTarget.cs  
│   ├── EnemyTarget.cs.meta  
│   ├── IEnemyTarget.cs  
│   ├── IEnemyTarget.cs.meta  
│   ├── ITargetedObject.cs  
│   ├── ITargetedObject.cs.meta  
│   ├── LockonMaker.cs  
│   ├── LockonMaker.cs.meta  
│   ├── PlayerTargeting.cs  
│   └── PlayerTargeting.cs.meta  
├── Target.meta  
├── Turret 自機と敵機攻撃処理のスクリプトです。自機のレーザーパワーアップ処理、自機のレーザーのマズルフラッシュなども含みます。  
│   ├── EnemyBeam.cs  
│   ├── EnemyBeam.cs.meta  
│   ├── EnemyBeamTurret.cs  
│   ├── EnemyBeamTurret.cs.meta  
│   ├── IHitByLaser.cs  
│   ├── IHitByLaser.cs.meta  
│   ├── ITurret.cs  
│   ├── ITurret.cs.meta  
│   ├── Laser.cs  
│   ├── Laser.cs.meta  
│   ├── LaserHitEffectExtinguishment.cs  
│   ├── LaserHitEffectExtinguishment.cs.meta  
│   ├── LaserMuzzleFlashExtinguishment.cs  
│   ├── LaserMuzzleFlashExtinguishment.cs.meta  
│   ├── PlayerLaserLevel.cs  
│   ├── PlayerLaserLevel.cs.meta  
│   ├── PlayerLaserTurret.cs  
│   ├── PlayerLaserTurret.cs.meta  
│   ├── PresenterLaserLevel.cs  
│   ├── PresenterLaserLevel.cs.meta  
│   ├── Stage1BossTurret.cs  
│   ├── Stage1BossTurret.cs.meta  
│   ├── Stage2BossTurret.cs  
│   ├── Stage2BossTurret.cs.meta  
│   ├── Stage3BossTurret.cs  
│   └── Stage3BossTurret.cs.meta  
├── Turret.meta  
├── UI UI系処理をまとめたスクリプトです。ゲームスタート、マニュアルなどの表記、Twitter投稿など  
│   ├── Game 主にゲームシーンのUI関連をまとめています。ゲームクリア、ゲームオーバー処理など  
│   │   ├── GameClearButton.cs  
│   │   ├── GameClearButton.cs.meta  
│   │   ├── GameClearUI.cs  
│   │   ├── GameClearUI.cs.meta  
│   │   ├── GameStartUIMingTurn.cs  
│   │   ├── GameStartUIMingTurn.cs.meta  
│   │   ├── GameoverButton.cs  
│   │   ├── GameoverButton.cs.meta  
│   │   ├── GameoverUI.cs  
│   │   ├── GameoverUI.cs.meta  
│   │   ├── LaserPowerTextEffect.cs  
│   │   ├── LaserPowerTextEffect.cs.meta  
│   │   ├── RankingButton.cs  
│   │   ├── RankingButton.cs.meta  
│   │   ├── RetryButton.cs  
│   │   ├── RetryButton.cs.meta  
│   │   ├── Stage1BossStartButton.cs  
│   │   ├── Stage1BossStartButton.cs.meta  
│   │   ├── Stage2StartButton.cs  
│   │   ├── Stage2StartButton.cs.meta  
│   │   ├── Stage3StartButton.cs  
│   │   ├── Stage3StartButton.cs.meta  
│   │   ├── TalkEnum.cs  
│   │   ├── TalkEnum.cs.meta  
│   │   ├── TalkUI.cs  
│   │   ├── TalkUI.cs.meta  
│   │   ├── TwitterButton.cs  
│   │   └── TwitterButton.cs.meta  
│   ├── Game.meta  
│   ├── Title タイトル画面の処理を行なっています。背景の星の動きなど  
│   │   ├── ButtonManual.cs  
│   │   ├── ButtonManual.cs.meta  
│   │   ├── ButtonStart.cs  
│   │   ├── ButtonStart.cs.meta  
│   │   ├── TitleStarfieldMove.cs  
│   │   └── TitleStarfieldMove.cs.meta  
│   └── Title.meta  
├── UI.meta  
├── VRM VRMキャラクターの瞬きや口パクなどをしているスクリプトです。  
│   ├── EyeBlink.cs  
│   ├── EyeBlink.cs.meta  
│   ├── MouthAnimation.cs  
│   └── MouthAnimation.cs.meta  
└── VRM.meta  