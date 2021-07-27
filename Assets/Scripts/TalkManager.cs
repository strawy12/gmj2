using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(100, new string[] { 
         "안녕하세요. 당신을 이곳에서 탈출할 수 있도록 도와드리는 당신의 스마트폰 AI 밈영입니다.",

         "이곳에 대해 잠시 안내해드리겠습니다.",

         "여기 왼쪽 위에 있는 하트는 당신의 남은 체력을 나타냅니다." ,

         "또한 그 바로 아래의 게이지는 스마트폰 사용도를 나타냅니다.",

         "마지막으로 그 바로 아래의 UI는 점프 사용 횟수를 나타냅니다.",

         "점프 횟수만큼 점프 할 수 있으며 연속 점프는 최대 3회까지 가능합니다.!",

         "만약 점프 횟수가 0일시에는 점프를 할수 없습니다.",

         "어? 마침 앞에 장애물이 있군요 이건 \"Space\"를 눌러 가볍게 점프하여 피하면 될 것 같습니다.",

         "앞에 보이는 장해물은 점프로 피할 수 없어요.",

         "\"Shift\"를 누르시면 슬라이딩이 가능하니 슬라이딩를 해서 피해보시겠어요?",

         "저기 아이템이 있군요! 한번 가서 먹어봅시다~!",

         "아이템은 이로운 효과를 주지만 많이 사용 하면 여러분의 눈 건강 이나 정신력에 안좋아요! 적당히 사용 하시는걸 추천드립니다.",

        "여기까지 모든 기본 설명을 끝입니다. 꼭 이곳에서 살아남길 기원합니다" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex > 12) return null;
        return talkData[id][talkIndex];
    }
}
