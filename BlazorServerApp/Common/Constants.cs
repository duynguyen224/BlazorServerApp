namespace BlazorServerApp.Common
{
    public static class Constants
    {
        // Status for record in database
        public enum Status
        {
            InActive = 0,
            Active = 1,
        }

        // Bootstrap class type
        public static string BOOTSTRAP_PRIMANY = "primary";
        public static string BOOTSTRAP_SECONDARY = "secondary";
        public static string BOOTSTRAP_SUCCESS = "success";
        public static string BOOTSTRAP_DANGER = "danger";
        public static string BOOTSTRAP_WARNING = "warning";
        public static string BOOTSTRAP_INFO = "info";
        public static string BOOTSTRAP_LIGHT = "light";
        public static string BOOTSTRAP_DARK = "dark";

        // Sort direction
        public static string SORT_DIRECTION_ASC = "ASC";
        public static string SORT_DIRECTION_DESC = "DESC";


    }
}
