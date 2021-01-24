using System;
namespace fpAPI.Access
{
    public static class EFCtx
    {
        public static DbCtx.InvCtx Inv;

        public static void Init()
        {
            Inv = new DbCtx.InvCtx();
        }
    }
}
