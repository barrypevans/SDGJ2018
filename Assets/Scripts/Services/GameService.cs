using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService
{

    private static GameService instance;

    public static GameService Instance
    {
        get
        {
            if (null == instance)
                instance = new GameService();
            return instance;
        }
    }

    


}
