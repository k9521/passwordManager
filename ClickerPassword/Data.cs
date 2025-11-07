using PasswordManager;
using System;
using System.Runtime.Serialization;

namespace ClickerPassword
{

    [Serializable]
    public class Data
    {
        public string ownName;
        public string username;
        public string password;
        public string widnowTitle;
        public bool isStrictWidnow;
        [OptionalField]
        public string keyboardLayout;

        // Konstruktor dla starej wersji
        public Data(string ownName, string username, string password, string widnowTitle, bool isStrictWidnow)
            : this(ownName, username, password, widnowTitle, isStrictWidnow, null) // ustaw null jako domyślny layout
        {
        }

        public Data(string ownName, string username, string password, string widnowTitle, bool isStrictWidnow, string keyboardLayout)
        {
            this.ownName = ownName;
            this.username = username;
            this.password = password;
            this.widnowTitle = widnowTitle;
            this.isStrictWidnow = isStrictWidnow;
            if (keyboardLayout == null)
            {
                keyboardLayout = "00000415";// if it's null then set up PL
            }
            this.keyboardLayout = keyboardLayout;
        }
        
        public override string ToString()
        {
            return "ownName: " + ownName +
        "\nusername: " + username +
        "\npassword: " + password +
        "\nwidnowTitle: " + widnowTitle +
        "\nisStrictWidnow: " + isStrictWidnow +
        "KeyboardLayout: " + keyboardLayout;
        }
    }
}
