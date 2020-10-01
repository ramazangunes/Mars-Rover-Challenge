using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public static class Parser
{

    public static int ToInt(this string value, int defaulValue = 1)
    {
        int outParams = 0;
        var parseResult = int.TryParse(value, out outParams);
        if (!parseResult)
        {
            return defaulValue;
        }
        else
        {
            return outParams;
        }
    }

}

