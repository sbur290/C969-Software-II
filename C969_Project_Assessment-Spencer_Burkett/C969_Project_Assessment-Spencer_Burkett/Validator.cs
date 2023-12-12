using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett
{
   public static class Validator
   {
      public static bool IsNullOrWhitespace(Control control)
      {
         string controlText = control.Text;

         if(string.IsNullOrEmpty(controlText))
         {
            return true;
         }
         else 
         {
            return false;
         }
      }

      public static bool HasInvalidCharacters(Control control) 
      {
         string controlText = control.Text;
         char[] invalidChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '?', '>', '<', '/', '\\',
                    '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '|', '[', ']', '\'', '"', ';', ':', ',', '.' };

         for (int i = 0; i < invalidChars.Length; i++) 
         {
            if (controlText.Contains(invalidChars[i]))
            {
               return true;
            }
         }
         return false;
      }

      public static bool PhoneValid(Control control)
      {
         char[] phoneChars = control.Text.ToCharArray();

         if (phoneChars.Length == 12         &&
             phoneChars[3] == '-'            &&
             phoneChars[7] == '-'              )
         {
            IEnumerable<char> phoneNoDashes =
               from c in phoneChars
               where c != '-'
               select c;
            foreach (char c in phoneNoDashes)
            {
               if (c < '0' || c > '9')
               {
                  return false;
               }
            }
            return true;
         }
         return false;
      }

      public static bool PostCodeValid(Control control) 
      {
         char[] postChars = control.Text.ToCharArray();

         if (postChars.Length == 5 )
         {
            foreach (char c in postChars) 
            {
               if (c < '0' || c > '9')
               {
                  return false;
               }
            }
            return true;
         }
         return false;

      }
   }
}
