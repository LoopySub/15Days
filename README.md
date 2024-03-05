<!-- 마크다운으로 작성하면 꾸밀 수 있어요 -->
# 15Days
> **프로젝트 명** : 15 Days (유니티 버전 : 2022.3.2fl)
> 
> 프로젝트 소개 : 좀비 아포칼립스로 인해 멸망해버린 세상… 딸을 위한 아버지의 선택!
    
    당신의 집 주변은 좀비로 가득하고, 당신의 하나 뿐인 소중한 딸은 좀비에게 물려 의식을 잃었습니다 !
    항생제로 딸의 감염을 어떻게든 늦추고 있지만 바이러스는 날이 갈수록 조금씩 조금씩 그녀를 갉아먹고 있습니다.
    아버지는 구조대가 오길 기다리며 밖에서 식량과 딸을 위한 약을 얻을 수 있습니다.
    연구소에서는 백신 제조법에 대한 힌트가 존재하며 , 어쩌면 백신을 만들수 있을지도 모릅니다.
    이 절망으로 가득 찬 나날 끝에서 당신이 손에 쥐게 될 것은 비극일까요, 희극일까요?


![titleScene](https://github.com/LoopySub/15Days/assets/153998744/7520064e-9d3c-4de2-b461-db1211b83d17)


## 구현 기능 정리:
### 1. 주인공 캐릭터의 이동 및 기본 동작  
- 캐릭터는 키보드로 이동 / 공격은 클릭버튼 

### 2. 적 좀비 이동 
좀비는 일정 범위에 플레이어가 들어가면 쫓아오도록 구현

### 3. 맵 ( 집 , 연구소 , 편의점 )
맵은 시가지,연구소,편의점 

### 4.상태관리 (스태미나 / 시간 ,날짜 / 감염도 / 배고픔)
- 스태미나: 간호하기,자료조사,바깥 탐사 등 어떤 행위를 할때 필요하다. 매일 아침 회복된다.
- 시간: 어떤 행동을 할때 시간이 흘러간다.  플레이 경과에 따라 15일 차에 엔딩이 출력된다. 매일 자정이 되면 하루가 끝난다. 
- 감염도: 레베카의 감염도, 레베카의 감염도는 매일 증가하는데 , 100이 되면 완전히 좀비가 되어 돌이킬 수 없고, ‘간호하기’ 선택지로  감소시키는것이 가능하다.
- 배부름: 존의 공복도 상태이다. 배부름이 낮을 수록 매일 아침 스태미나가 적게 회복되고,  0에 이르면 아사 엔딩을 볼 수 있다.

### 5.인벤토리 및 아이템 
- TAB키로 인벤토리 오픈/닫기 가능
- 소비가능 아이템 : 항생제, 케이크
- 보유 시 이벤트가 활성화되는 아이템: 
- 연구소 카드키: 연구소 출입에 필요한 카드키이다. 미 보유 시 연구소 출입이 불가능하다.
- 백신 미완성품A,B,C : 3개가 모여야 백신 완성품 아이템을 얻을 수 있다.
- 연구소 내부키: 연구소 내부 백신을 조합할 수 있는 곳에 들어갈 수 있는 카드키이다.

### 6.선택지
- 각 종 행동에 대한 선택지이다. 예/아니오로 선택 및 취소가 가능하다.

### 7.대화창
- 매일 아침 독백, 라디오, PC를 통한 정보 탐색 등 150여 종의 대화 스크립트가 구현되어있다. 
- 레베카의 상태 대화창은 레베카의 현재 상태에 따라 랜덤으로 띄워진다.

### 8.오디오/bgm
- 배경 BGM 구현 , 5종의 행동할때 행동오디오 출력 

### 9. 총 6종의 엔딩
- 게임 오버 엔딩:존은 바깥을 싸돌아다니다가 좀비에게 습격당해 죽습니다.
- 바깥 탐사 중 HP가 0이 되면 보게되는 엔딩


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

---
## 스크립트 목록

1. CharacterScript
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

```

3. 스크립트 
```

```

---
### 시연영상




https://github.com/LoopySub/15Days/assets/153998744/2f7c1fcd-cf76-4dca-ae35-0ef9048b5685




[발표 구글 슬라이드](https://docs.google.com/presentation/d/e/2PACX-1vQmuseV9kTzGkwgsivGAydbM1kgfFf7MGu_f-L25PPmHVdY6-LWTncYL4UxCS115Qfu1RHSjbE8xAN4/pub?start=true&loop=true&delayms=3000&slide=id.g2bf18da56ac_0_11810)
    
