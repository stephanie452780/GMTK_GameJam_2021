using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    private List<BaseNPC> memberList;
    private int memberCount;

    public List<BaseNPC> GetMemberList()
    {
        return memberList;
    }

    public int GetMemberCount()
    {
        return memberCount;
    }
}
