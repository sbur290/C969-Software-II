using System;
using System.Collections.Generic;
using System.Globalization;

public static class Settings
{
	public const int LOGIN_FORM__TITLE_LBL_ID = 0;
	public const int LOGIN_FORM_USERNAME_LBLTEXT_ID = 1
	public const int LOGIN_FORM_PASSWORD_LBLTEXT_ID = 2;
	public const int LOGIN_FORM_LOGIN_BTNTEXT_ID = 3;
	public const int LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID = 4;
	public const int LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN = 5;

   private static Dictionary<int, string> englishLabels
   private static Dictionary<int, string> spanishLabels;
	private static Dictionary<int, string> currentLabel;

	public static void Initialize()
	{
		LoadLanguageDictionaries();
	}

	private static void LoadLanguageDictionaries()
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;

		englishLabels = new Dictionary<int, string>();
		{
			{ LOGIN_FORM__TITLE_LBL_ID, "Log In" }
			{ LOGIN_FORM_USERNAME_LBLTEXT_ID, "Username" }
			{ LOGIN_FORM_PASSWORD_LBLTEXT_ID, "Password" }
			{ LOGIN_FORM_LOGIN_BTNTEXT_ID, "Log In" }
			{ LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID, "Could not connect to Database" }
			{ LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN "Invalid Login Credentials" }
		}

		spanishLabels = new Dictionary<int, string>();
		{
         { LOGIN_FORM__TITLE_LBL_ID, "PLACEHOLDER" }
         { LOGIN_FORM_USERNAME_LBLTEXT_ID, "PLACEHOLDER" }
         { LOGIN_FORM_PASSWORD_LBLTEXT_ID, "PLACEHOLDER" }
         { LOGIN_FORM_LOGIN_BTNTEXT_ID, "PLACEHOLDER" }
         { LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID, "PLACEHOLDER" }
         { LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN "PLACEHOLDER" }

      }


		if(!currentCulture.TwoLetterISOLanguageName == "es") 
		{
         currentLabels = new Dictionary<int, string>(englishLabels);
		}
		else
		{
         currentLabels = new Dictionary<int, string>(spanishLabels);
      }
	}
}
