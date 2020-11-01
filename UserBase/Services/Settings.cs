using System;
using Xamarin.Essentials;

namespace UserBase.Services
{
    public static class Settings
    {
        private const string IdUrlBase = "url_base";
        private static readonly string UrlBaseDefault = "https://run.mocky.io/v3";

        private const string IdAuthToken= "auth_token";
        private static readonly string AuthTokenDefault = "";

        private const string IdUser = "user_email";
        private static readonly string UserDefault = "";

        public static string UrlBase
        {
            get
            {
                return Preferences.Get(IdUrlBase, UrlBaseDefault);
            }
            set
            {
                Preferences.Set(IdUrlBase, value);
            }
        }

        public static string AuthToken
        {
            get
            {
                return Preferences.Get(IdAuthToken, AuthTokenDefault);
            }
            set
            {
                Preferences.Set(IdAuthToken, value);
            }
        }

        public static string User
        {
            get
            {
                return Preferences.Get(IdUser, UserDefault);
            }
            set
            {
                Preferences.Set(IdUser, value);
            }
        }
    }
}
