<h1>Human AI Interaction</h1>

<p>
  <a href="#interacting-with-the-virtual-human"><strong>Interacting with the Virtual Human</strong></a> ·
  <a href="#author"><strong>Author</strong></a>
</p>

## Interacting with the Virtual Human

<img alt="VRChat Unity" src="/img/VRChat Unity.png">

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
11. 透過VRChat SDK匯出角色，若太亮請在FBX裡調光

<img alt="VRChat Blender" src="/img/VRChat Blender.png">
<img alt="VRChat Test" src="/img/VRChat Test.jpg">

GitHub Repo: [VRoid to VRChat Practice](https://github.com/HaruoWang/VRoid-to-VRChat-Practice)

## Author

- [Haruo Wang](https://haruowang.vercel.app)