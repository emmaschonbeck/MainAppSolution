﻿

namespace MainApp.Helpers
{
    public static class UniqueIdentifierGenerator
    {
        public static string Generate() => Guid.NewGuid().ToString();
    }
}
