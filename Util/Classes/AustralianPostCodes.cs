namespace full_stack.Util.Classes
{
    public static class AustralianPostCodes
    {
        //Reference taken from the https://postcode.auspost.com.au/free_display.html?id=1

        public static String NSW { get { return "1000-2599,2620-2899,2921-2999"; } }
        public static String VIC { get { return "3000-3999,8000-8999"; } }
        public static String QLD { get { return "4000-4999,9000-9999"; } }
        public static String SA { get { return "5000-5999"; } }
        public static String WA { get { return "6000-6999"; } }
        public static String TAS { get { return "7000-7999"; } }
        public static String ACT { get { return "0200-0299,2600-2619,2900-2920"; } }
        public static String NT { get { return "0800-0999"; } }
    }
}
