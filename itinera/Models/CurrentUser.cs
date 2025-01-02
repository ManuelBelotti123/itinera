using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItinerariApp.Models
{
    public static class CurrentUser
    {
        public static int UserId { get; set; } // ID dell'utente
        public static string Username { get; set; } // Username dell'utente
        public static string UserType { get; set; } // Tipo utente: "base" o "ente"

        public static void Reset()
        {
            UserId = 0;
            Username = "";
            UserType = "";
        }
    }
}

