namespace RazorTranstator.Localization.Touch
{
    public static class L
    {
        public static class General
        {
            public static string GoToMarket
            {
                get { return Ioc.Get<ITranslator>().Translate("tt_general_go_to_market"); }
            }
            public static string Hello
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Hello"); }
            }
            public static string Hello3
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Hello3"); }
            }
        }
    }

}
