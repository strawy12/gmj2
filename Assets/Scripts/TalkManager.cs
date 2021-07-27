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
         "�ȳ��ϼ���. ����� �̰����� Ż���� �� �ֵ��� ���͵帮�� ����� ����Ʈ�� AI �ҿ��Դϴ�.",

         "�̰��� ���� ��� �ȳ��ص帮�ڽ��ϴ�.",

         "���� ���� ���� �ִ� ��Ʈ�� ����� ���� ü���� ��Ÿ���ϴ�." ,

         "���� �� �ٷ� �Ʒ��� �������� ����Ʈ�� ��뵵�� ��Ÿ���ϴ�.",

         "���������� �� �ٷ� �Ʒ��� UI�� ���� ��� Ƚ���� ��Ÿ���ϴ�.",

         "���� Ƚ����ŭ ���� �� �� ������ ���� ������ �ִ� 3ȸ���� �����մϴ�.!",

         "���� ���� Ƚ���� 0�Ͻÿ��� ������ �Ҽ� �����ϴ�.",

         "��? ��ħ �տ� ��ֹ��� �ֱ��� �̰� \"Space\"�� ���� ������ �����Ͽ� ���ϸ� �� �� �����ϴ�.",

         "�տ� ���̴� ���ع��� ������ ���� �� �����.",

         "\"Shift\"�� �����ø� �����̵��� �����ϴ� �����̵��� �ؼ� ���غ��ðھ��?",

         "���� �������� �ֱ���! �ѹ� ���� �Ծ�ô�~!",

         "�������� �̷ο� ȿ���� ������ ���� ��� �ϸ� �������� �� �ǰ� �̳� ���ŷ¿� �����ƿ�! ������ ��� �Ͻô°� ��õ�帳�ϴ�.",

        "������� ��� �⺻ ������ ���Դϴ�. �� �̰����� ��Ƴ��� ����մϴ�" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex > 12) return null;
        return talkData[id][talkIndex];
    }
}
