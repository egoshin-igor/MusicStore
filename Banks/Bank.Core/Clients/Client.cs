using System;

namespace MusicStore.Bank.Core.Clients
{
    public class Client
    {
        public string Email { get; protected set; }
        public decimal Balance { get; protected set; }

        protected Client()
        {
        }

        public Client( string email, decimal balance = 0m )
        {
            Email = email;
            Balance = balance;
        }

        public bool UpdateBalance( decimal changeCount )
        {
            if ( Balance + changeCount < 0 )
            {
                Console.WriteLine( $"Cannot change balance on {changeCount}. Current balance {Balance}" );
                return false;
            }

            Balance += changeCount;
            return true;
        }
    }
}
