using System;
using UnityEngine;
namespace Newspaper
{
    public static class UIActions
    {
        public static Action Weather_ClearQueueAction = delegate { };
        public static Action Facts_LoadListAction = delegate { };
        public static Action<string, string> Facts_LoadFactAction = delegate { };
        public static Action<string> Weather_UpdateAction = delegate { };
    }
}