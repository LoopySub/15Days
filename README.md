<!-- 마크다운으로 작성하면 꾸밀 수 있어요 -->
# 15Days
> **프로젝트 명** : 15 Days (유니티 버전 : 2022.3.2fl)
> 
> 프로젝트 소개 : 좀비 아포칼립스로 인해 멸망해버린 세상… 행동해라, 딸을 구하기 위해!
    
    당신의 집 주변은 좀비로 가득하고, 당신의 하나 뿐인 소중한 딸은 좀비에게 물려 의식을 잃었습니다 !
    항생제로 딸의 감염을 어떻게든 늦추고 있지만 바이러스는 날이 갈수록 조금씩 조금씩 그녀를 갉아먹고 있습니다.
    아버지는 구조대가 오길 기다리며 위험한 바깥을 돌아다니며 식량과 딸을 위한 약을 얻을 수 있습니다.
    게임 내 곳곳에서 정보와 단서를 얻을 수 있으며, 어쩌면 바이러스를 완전히 치료하는 백신을 만들수 있을지도 모릅니다.
    이 절망으로 가득 찬 나날 끝에서 당신이 손에 쥐게 될 것은 비극일까요, 희극일까요?


![titleScene](https://github.com/LoopySub/15Days/assets/153998744/7520064e-9d3c-4de2-b461-db1211b83d17)

## 개요
 - 프로젝트 이름: 15 Days
 - 프로젝트 작업 기간: 2024.02.26 ~ 2024.03.05 
 - 개발엔진 및 언어: Unity & C#
 - 멤버: 송문섭, 정현우, 조기조, 이은실

## 구현 기능 정리:
### 1. 주인공 캐릭터의 이동 및 기본 동작  
- 캐릭터는 키보드로 이동 / 공격은 클릭버튼 

### 2. 적 좀비 이동 
좀비는 일정 범위에 플레이어가 들어가면 쫓아오도록 구현 / <br/> 
좀비는 야외 맵에서 랜덤 마릿수가 랜덤 위치에 스폰됨. (밤이 깊어질 수록 더 많이 출현) 

### 3. 맵 ( 집 , 연구소 , 편의점 )
맵은 시가지,연구소,편의점 

### 4.상태관리 (스태미나 / 시간 ,날짜 / 감염도 / 배고픔)
- 스태미나: 간호하기,자료조사,바깥 탐사 등 어떤 행동을 할때 필요하다. 매일 아침 회복된다.
- 시간: 어떤 행동을 할 때 시간이 흘러간다. 매일 아침 08시에 하루가 시작되고, 매일 자정이 되면 하루가 끝난다. <br/>
 플레이 경과에 따라 15일 차 아침에 엔딩이 출력된다. 
- 감염도: 레베카의 감염도, 레베카의 감염도는 매일 25~35의 랜덤한 값으로 증가하는데 , <br/>
 100이 되면 완전히 좀비가 되어 돌이킬 수 없고, ‘간호하기’ 선택지로  감소시키는 것이 가능하다.
- 배부름: 존의 공복도 상태이다. 시간이 지날 수록 감소하며, <br/>
 배부름이 낮을 수록 매일 아침 스태미나가 적게 회복되고,  0에 이르면 아사 엔딩이 출력된다.

### 5.인벤토리 및 아이템 
- TAB키로 인벤토리 오픈/닫기 가능
- 소비가능 아이템 : 항생제, 케이크
- 보유 시 이벤트가 활성화되는 아이템: 
- 연구소 카드키: 연구소 출입에 필요한 카드키이다. 미 보유 시 연구소 출입이 불가능하다.
- 백신 미완성품A,B,C : 3개가 모여야 백신 완성품 아이템을 얻을 수 있다.
- 연구소 내부키: 연구소 내부 백신을 조합할 수 있는 곳에 들어갈 수 있는 카드키이다.
- 각 보유 시 이벤트 활성화 아이템을 보유하고 연구소 뒷문, 도어락, 합성대 오브젝트에 Z키를 누를 시 상호작용할 수 있다.
- 각 이벤트 활성화 아이템은 맵 곳곳에 숨겨져 있고, 한번 획득하면 다시 생성되지 않는다.
- 소비 가능 아이템은 위치한 맵에 진입할 때마다 재생성된다.

### 6.선택지
- 각종 행동에 대한 선택지이다. 예/아니오로 선택 및 취소가 가능하다.
- 각 오브젝트에 접근해서 바라보는 상태로 'Z'키를 눌러 상호작용할 수 있다.
- 레베카 간호하기 / PC 정보 탐색 / 라디오 정보 탐색 / 시계 시간 확인 / 책꽂이 게임팁 확인 <br/>
/ 침대 2시간 쉬기 / 침대 하루 쉬기 / 연구소 출입문 및 합성대 조사 등

### 7.대화창 및 대화 스크립트
- 매일 아침 독백, 라디오, PC를 통해 매일마다 얻을 수 있는 정보가 달라지는 등 150여 개 이상의 대화 스크립트가 구현되어있다. 
- 레베카의 상태는 총 7종 (감기 증세 / 불안정 / 폭력적 / 미쳐감 / 거의 좀비 / 좀비 / 완치됨)이며, <br/>
  레베카의 각 상태마다 2~4개의 대사 모음이 준비 되어있고 랜덤으로 출력된다.
- Z키를 누르거나 마우스로 [▶] 버튼, 예/아니오 버튼을 눌러 대화를 진행할 수 있다.<br/>
  WASD및 방향키로 예/아니오 선택지를 전환할 수 있다.

### 8.오디오/bgm
- 배경 BGM 구현 , 5종의 행동할때 행동오디오 출력 

### 9. 총 6종의 엔딩
 **게임 오버 엔딩:**
> 존은 바깥을 싸돌아다니다가 좀비에게 습격당해 죽습니다.
> 바깥 탐사 중 HP가 0이 되면 보게되는 엔딩

**늦은 밤 엔딩:** 
> 존이 자정을 넘어서도 귀가하지 못했을 시 보게 되는 엔딩.
> 세계관 설정 상 자정이 넘어가면 좀비들이 매우 흉폭해지기 때문에, 죽습니다.

**아사 엔딩 :**
> 식량이 다 떨어졌고, 배고픔 수치도 최대치라서 자고 일어나도 스태미나가 회복되지 않아서 아무것도 할 수 없는 상태가 되면 보게되는 엔딩.

**감염 엔딩:**
> 레베카의 감염을 늦추지 못해 그녀가 완전히 좀비가 되고, 
> 존은 레베카의 상태를 확인하러 방에 들어갔다가 습격당해 죽습니다.

**노말 엔딩:** 
> (비극 엔딩) 존은 15일동안 생존하는데 성공하고 레베카의 감염을 늦추는데도 성공하지만, 도착한 구조대는 바이러스 보균자인 레베카를 즉시 사살합니다.

**트루 엔딩:**
> 존은 레베카의 바이러스를 백신으로 치료하는데 성공하고, 15일 동안 버티는 데에도 성공해 구조대에게 무사히 구조됩니다.


## 역할 분담
- 송문섭-아이템 및 인벤토리 및 아이템 상호작용 / 팀장
- 정현우-UI / 상태 관리 및 선택지 및 상호작용 / 시나리오 / 맵(씬)간 이동 / <br/> 
대화창 구현 및 대화 스크립트 작성 / 전반전인 게임 데이터 관리 및 로직 설계 / 기획 및 QA / 부팀장
- 조기조-캐릭터 조작 (이동 및 공격) / 애니메이션 및 이펙트 ,  적(좀비) 공격 / 이동 / 애니메이션 및 이펙트
- 이은실-맵 제작 및 맵 타일셋 배치 <br/> 


---
## 스크립트 목록

1. CharacterScript //캐릭터 공격 및 적과의 전투 관련 스크립트 일체
```
//ScriptableObjects
AttackSO.cs
CharacterStatsHandler.cs
RangedAttackData.cs

CharacterGameManager.cs
CharacterStats.cs
DisappearOnDeath.cs
DustParticleControl.cs
HealthSystem.cs
ObjectPool.cs
PlayerInputController.cs
ProjectileManager.cs
RangedAttackController.cs
TopDownAimRotation.cs
TopDownAnimationController.cs
TopDownAnimations.cs
TopDownCharacterController.cs
TopDownContactEnemyController.cs
TopDownEnemyController.cs
TopDownMovement.cs
TopDownRangeEnemyContreoller.cs
TopDownShooting.cs
```
2. 스크립트
 ```
InteractionManager : 상호작용에 대한 스크립트
ItemObject: 상호작용 텍스트에 뜨는 아이템 이름에 대한 스크립트 / ITEMData와연동
Inventory :인벤토리 내 모든 기능 함수를 모아놓은 스크립트.
ItemSlotUI : 인벤토리 내 슬롯칸 스크립트.
ItemData : 아이템 타입,설명,능력치에 관한 스크립트. ScriptableObject와 연동

```

3. 스크립트 
```
[매니저 스크립트]
OverallManager 
 게임에 전체적으로 통용되는 스크립트들을 통합해서 참조하도록 하는 종합 터미널 같은 역할을 하는 스크립트. 
 싱글톤 및 Don't Distroy가 걸려있음
GameDataManager
 게임의 핵심 데이터를 계산하고 처리하는 메서드를 모아놓은 스크립트.
UiManager
 UI 및 대화창 관련 일체의 메서드 및 프로퍼티를 모아놓은 스크립트.
PlayerManager
 플레이어 오브젝트에 부착되어 플레이어의 상태 및 상호작용을 처리하는 메서드 및 프로퍼티를 모아놓은 스크립트.
TestManager
 게임 속도 증가 및 감소, 테스트 메세지 출력 등 테스트하는데 유용한 기능을 모아놓은 스크립트.
```
```
[공용 데이터]
Public_Variable
 게임에서 공용으로 사용되는 데이터 및 해당 데이터 관련 이벤트, 콜백 메서드를 모아놓은 스크립트.
Public_Enum
 게임에서 공용으로 사용되는 Enum 값을 모아놓은 스크립트.
```
```
[선택지 / 상호작용 및 대사 출력]
Researchable
 선택지 및 상호작용하는 스크립트들의 뼈대가 되는 부모 스크립트.
Obj_Researchable 폴더의 Researchable 자식 스크립트들
 직접적으로 선택지 및 상호작용하는 역할을 하는 각각의 오브젝트들에 부착되는 스크립트들.
```
```
[맵 관련]
PotalInfo
 맵 이동 트리거 및 다음맵에서의 좌표값과 맵 정보를 저장하는 스크립트 
SceneFader
 씬 이동 시 페이드 아웃 효과를 주는 메서드를 담아둔 스크립트
SceneTransition
 실질적으로 씬 이동을 제어하는 스크립트.
```
```
[기타]
Title_Ui_Controller
 타이틀 화면의 UI를 제어하는 스크립트 
PrologueController
 프롤로그 화면을 제어하는 스크립트
EndingController
 엔딩 화면을 제어하는 스크립트
CameraController
 게임 내에서 카메라를 제어하는 스크립트
```

### 시연영상




https://github.com/LoopySub/15Days/assets/153998744/2f7c1fcd-cf76-4dca-ae35-0ef9048b5685

[발표 구글 슬라이드 보기](https://docs.google.com/presentation/d/e/2PACX-1vQmuseV9kTzGkwgsivGAydbM1kgfFf7MGu_f-L25PPmHVdY6-LWTncYL4UxCS115Qfu1RHSjbE8xAN4/pub?start=true&loop=true&delayms=3000&slide=id.g2bf18da56ac_0_11810)

---
---

**[리소스 출처]**

- 5종 효과음 
https://pixabay.com/ko/music/

- 아이템 아이콘
https://www.flaticon.com/kr/
    
- 에셋
Dotween (무료 에셋)
https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676

- 폰트
neodgm네오둥근모 체
Copyright © 2017-2022, Eunbin Jeong (Dalgona.) 
<project-neodgm@dalgona.dev>
with reserved font name "Neo둥근모" and "NeoDunggeunmo".

- 커튼 이미지
https://www.pexels.com/ko-kr/photo/462197/

- 바닥타일 및 소품(무료 유니티 에셋)
https://assetstore.unity.com/packages/2d/2d-basic-room-assets-234762

-보물상자(무료 유니티 에셋)
https://assetstore.unity.com/packages/2d/environments/pixel-chests-pack-animated-263923

-오두막(무료 유니티 에셋)
https://assetstore.unity.com/packages/2d/textures-materials/2d-tileset-platformer-254632

- 플레이어 스프라이트(무료 유니티 에셋)
https://assetstore.unity.com/packages/2d/characters/2d-character-astronaut-182650
- 좀비 스프라이트(무료 유니티 에셋)
  https://assetstore.unity.com/packages/2d/characters/2d-fantasy-character-pack-demo-101030

- 발표 슬라이드 템플릿1(무료템플릿)
https://slidesgo.com/theme/zombie-pride-day-minitheme#search-%EC%A2%80%EB%B9%84&position-2&results-9&rs=search
- 발표 슬라이드 템플릿2(무료템플릿)
https://slidesgo.com/theme/zombies-minitheme#search-%EC%A2%80%EB%B9%84&position-5&results-9&rs=search  

