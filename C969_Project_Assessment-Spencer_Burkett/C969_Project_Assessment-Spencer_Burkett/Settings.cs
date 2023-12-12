using System;
using System.Collections.Generic;
using System.Globalization;

public static class Settings
{
	public const int LOGIN_FORM__TITLE_LBL_ID = 0;
	public const int LOGIN_FORM_USERNAME_LBLTEXT_ID = 1;
	public const int LOGIN_FORM_PASSWORD_LBLTEXT_ID = 2;
	public const int LOGIN_FORM_LOGIN_BTNTEXT_ID = 3;
	public const int LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID = 4;
	public const int LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN = 5;

	private static Dictionary<int, string> englishLabels;
   private static Dictionary<int, string> spanishLabels;
	private static Dictionary<int, string> currentLabel;

	private static readonly List<string> appointmentTypes = new List<string>() { "Meeting", "Presentation", "Evaluation", "Scrum" };
   public static Dictionary<int, string> CurrentLabel
   {
      get { return currentLabel; }
   }

   public static List<string> AppointmentTypes
   {
      get { return appointmentTypes; }
   }
   public static void Initialize()
	{
		LoadLanguageDictionaries();
	}

	private static void LoadLanguageDictionaries()
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;

		englishLabels = new Dictionary<int, string>()
		{
			{ LOGIN_FORM__TITLE_LBL_ID, "Log In" },
			{ LOGIN_FORM_USERNAME_LBLTEXT_ID, "Username:" },
			{ LOGIN_FORM_PASSWORD_LBLTEXT_ID, "Password:" },
			{ LOGIN_FORM_LOGIN_BTNTEXT_ID, "Log In" },
			{ LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID, "Could not connect to Database" },
			{ LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN, "Invalid Login Credentials" }
		};

		spanishLabels = new Dictionary<int, string>()
		{
			{ LOGIN_FORM__TITLE_LBL_ID, "Accesso" },
			{ LOGIN_FORM_USERNAME_LBLTEXT_ID, "Nombre de usuario" },
			{ LOGIN_FORM_PASSWORD_LBLTEXT_ID, "Contraseña" },
			{ LOGIN_FORM_LOGIN_BTNTEXT_ID, "Acceso" },
			{ LOGIN_FORM_EXCEPTIONTEXT_MYQSL_ID, "No se pudo conectar a la base de datos" },
			{ LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN, "Credenciales de acceso invalidos" }

		};


		if(currentCulture.TwoLetterISOLanguageName != "es") 
		{
         currentLabel = new Dictionary<int, string>(englishLabels);
		}
		else
		{
         currentLabel = new Dictionary<int, string>(spanishLabels);
      }
	}
}
