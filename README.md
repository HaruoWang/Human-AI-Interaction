<h1>Human AI Interaction</h1>

<p>
  <a href="#conferences-about-ixd"><strong>Conferences about IxD</strong></a> ·
  <a href="#hcaii"><strong>HC(AI)I</strong></a> ·
  <a href="#data-to-context"><strong>Data-to-Context</strong></a> ·
  <a href="#interacting-with-the-virtual-human"><strong>Interacting with the Virtual Human</strong></a> ·
  <a href="#heuristic-evaluation-for-ai-interaction"><strong>Heuristic Evaluation for AI Interaction</strong></a> ·
  <a href="#human-ai-co-creation"><strong>Human-AI Co-Creation</strong></a> ·
  <a href="#can-robots-lead-humans"><strong>Can Robots Lead Humans?</strong></a> ·
  <a href="#author"><strong>Author</strong></a>
</p>

## Conferences about IxD
- CHI：國際電腦人因互動研討會
- CSCW：電腦支援的合作工作與社交計算會議
- UIST：使用者介面軟體及技術研討會議
- ISMAR：IEEE混和與擴增實境國際會議
- APMAR：亞太混合與擴增實境研討會

## HC(AI)I
- SketchLab：韓國科學技術院（KAIST）工業設計系的研究單位。正在探索3D草圖即時生成2D設計的潛力
- VRCopilot：密西根大學的研究。使用NVIDIA的ATISS生成室內場景，並結合Whisper-1和GPT-4 Turbo，支援語音輸入。包含手動（Manual）、自動（Automatic）、鷹架（Scaffolded）三種模式
- Ubicomp：普及運算。由Mark Weiser提出，認為電腦運算無處不在。和智慧城市同樣屬於IoX領域
- AxLab：芝加哥大學資工系的研究單位，打造出能依聲音指令改變外型的可變形介面（Shape-Changing Interfaces），稱為「inFORCE」。Demo中可用來當手機架
- 超人運動協會：透過科技擴展人類運動方式。看似很賽博龐克，實則有追求通用設計的目標

## Data-to-Context
- Unity的VR專案通常採用公尺座標制，因此0.01代表1公分
- 形成性（Formative） & 總結性（Summative）資料：分類基準類似教學評量

## Interacting with the Virtual Human

<img alt="VRChat Unity" src="/img/VRChat Unity.png">

### [VRoid to VRChat Practice](https://github.com/HaruoWang/VRoid-to-VRChat-Practice)

1. 使用CATS匯入VRM，並Fix MMD Model，再調整Visemes設定（Fcl_MTH_A/O/I），以及Eye Tracking設定（Eye_L/R）
2. 到MatCombiner，先install Pillow，完成後將EyeHighlight和Shoes取消勾選後Generate Texture Altas，並用Mesh>Separate>Selection將Shoes分離出來
3. Unpack Resources到textures資料夾，然後將Unity需要的素材，以及上個步驟產生的Altas圖放進自己新建的資料夾Unity textures。需要自己做一張對Face做處理的Outline圖
4. 匯出FBX，記得將Apply Scalings改成FBX ALL，勾選Apply Transform，取消勾選Add Leaf Bones和Animation
5. 去Creator Companion開一個2022 Avatar Project，在專案頁面加入GoGoLoco
6. 在開啟的Unity專案內匯入FBX和Unity textures資料夾，並新建一個空的Materials資料夾。然後將Material Creation Mode改成Standard (Legacy)後，Extract Materials到Materials資料夾，將Rig改成Humanoid，並至Configure內將下巴改成none
7. 將FBX置入場景，掛上VRC Avatar Descriptor，調整View Position至正確的視線位置
8. 於Unity內使用MToon，正確渲染出Toon Shader效果，記得將Body的Render Type設成Cutout + off
9. 開啟VRC Avatar Descriptor的Eye Look綁定眼睛，設定Eyelids為Blendshapes，Blink為Fcl_EYE_CLOSE，並將Playable Layers和Expressions裡的選項設為GoGoLoco，其中GoBeyond可飛行
10. 如果選擇Beyond，場景裡要加入一個prefab，記得去Rotation裡設定Head
11. 透過VRChat SDK匯出角色，如果FBX裡自帶Light請拿掉

<img alt="VRChat Blender" src="/img/VRChat Blender.png">
<img alt="VRChat Test" src="/img/VRChat Test.jpg">

## Heuristic Evaluation for AI Interaction
- AEQ：即Avatar Embodiment Questionnaire。向度含外觀（Appearance）、回應（Response）、所有權感（Ownership）、多重感官（Multi-Sensory）
- 和AEQ類似的研究工具：GEQ（遊戲參與問卷）、VEQ（虛擬體現問卷）、IPQ（Igroup沉浸感問卷）
- SAM量表：自我評價小矮人（Self-Assessment Manikin）
- PAD模型：向度含愉悅感（Pleasure）、喚醒程度（Arousal）、主宰性（Dominance），常見於「社會機器人學」領域
- 鳴海拓志：東大教授，關注和VR相關之五感，如Meta Cookie

## Human-AI Co-Creation
- 研討會投稿評估級距：A（接受）、ARR（接受但要修改）、RRX（下次再來）
- Donald Schon提出Design as a Reflective Practice，發揚Dewey概念
- 顏羽君教授在實驗中發現，在獲得feedback之後reflection對於提升設計之效果最好，而只獲得feedback或只進行reflection的效果其實差不多
- Decipher：Adobe的互動化視覺工具，用於解讀非結構化的設計回饋
- Wicked Problem：棘手問題，由Rittel & Webber所提出，無法trial & error

## Can Robots Lead Humans?
- Robot的詞源是捷克文的「奴隸」（Robata）
- "The fundamental concept in social science is Power in the same sense in which Energy is the fundamental concept in physics." - Bertrand Russell
- RoSAS：機器人社交屬性量表（Robotic Social Attributes Scale）
- Algorithm Aversion：演算法厭惡，相對應的是Appreciation。賓州支持前者，哈佛支持後者
- 侯宗佑教授在實驗中發現，是否相信對方其實並非在於人或非人，而在於背後隱含的權力地位
- Bases of Power：5+1種。分為合法權（Legitimate）、獎賞權（Reward）、強制權（Coercive）、參照權（Referent）、專家權（Expert）、資訊權（Information）
- 日本的社會機器人學者有神田崇行、石黑浩等人

## Author

- [Haruo Wang](https://haruowang.vercel.app)