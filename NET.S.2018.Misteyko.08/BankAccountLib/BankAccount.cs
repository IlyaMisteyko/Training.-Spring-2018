using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Class describes bank account.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Field for the bonus
        /// </summary>
        private int bonus = 0;

        /// <summary>
        /// Field for the state
        /// </summary>
        private State state;

        /// <summary>
        /// State of the account
        /// </summary>
        private enum State
        {
            Active = 1,
            Closed = 2
        }

        /// <summary>
        /// Field for the account number
        /// </summary>
        private static int accountNumber = 0;

        /// <summary>
        /// Gets firstname.
        /// </summary>
        /// <value>
        /// Firstname of the owner.
        /// </value>
        public string Firstname { get; }

        /// <summary>
        /// Gets lastname.
        /// </summary>
        /// <value>
        /// Lastname of the owner.
        /// </value>
        public string Lastname { get; }

        /// <summary>
        /// Gets patronymic.
        /// </summary>
        /// <value>
        /// Patronymic of the owner.
        /// </value>
        public string Patronymic { get; }

        /// <summary>
        /// Gets status of the account.
        /// </summary>
        /// <value>
        /// Status of the account.
        /// </value>
        public string Status { get; }

        /// <summary>
        /// Gets balance of the account.
        /// </summary>
        /// <value>
        /// Balance of the account.
        /// </value>
        public int Balance { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="firstname">Firstname.</param>
        /// <param name="lastname">Lastname.</param>
        /// <param name="patronymic">Patronymic.</param>
        /// <param name="status">Status of the account.</param>
        public BankAccount(string firstname, string lastname, string patronymic, string status) : this(firstname,
            lastname, patronymic, status, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="firstname">Firstname.</param>
        /// <param name="lastname">Lastname.</param>
        /// <param name="patronymic">Patronymic.</param>
        /// <param name="status">Status of the account.</param>
        /// <param name="balance">Starting balance.</param>
        /// <exception cref="ArgumentNullException">Invalid parameter!</exception>
        public BankAccount(string firstname, string lastname, string patronymic, string status, int balance)
        {
            if (firstname == null || lastname == null || patronymic == null || status == null || balance < 0)
            {
                throw new ArgumentNullException("Invalid parameter!");
            }

            Firstname = firstname;
            Lastname = lastname;
            Patronymic = patronymic;
            state = State.Active;
            Balance = balance;
            Status = status;
            accountNumber++;
        }

        /// <summary>
        /// Replenishments amount.
        /// </summary>
        /// <param name="amount">Needed amount.</param>
        public void Replenishment(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"Wrong {nameof(amount)}!");
            }

            if (state == State.Closed)
            {
                throw new ArgumentException($"Your account closed!");
            }

            Balance += amount;
            GetBonus(amount);
        }

        /// <summary>
        /// Withdraws amount.
        /// </summary>
        /// <param name="amount">Needed amount.</param>
        public void Withdraw(int amount)
        {
            if (amount < 0 || amount > Balance)
            {
                throw new ArgumentException($"Wrong {nameof(amount)}!");
            }

            if (state == State.Closed)
            {
                throw new ArgumentException($"Your account closed!");
            }

            Balance -= amount;
            GetBonus(amount);
        }

        /// <summary>
        /// Gets bonus.
        /// </summary>
        /// <param name="amount">Current amount.</param>
        public void GetBonus(int amount)
        {
            if (amount < Balance)
            {
                return;
            }

            if ("Base".Equals(Status))
            {
                bonus += (int)((amount - Balance) * 0.01);
            }

            if ("Silver".Equals(Status))
            {
                bonus += (int)((amount - Balance) * 0.05);
            }

            if ("Gold".Equals(Status))
            {
                bonus += (int)((amount - Balance) * 0.10);
            }

            if ("Platinum".Equals(Status))
            {
                bonus += (int)((amount - Balance) * 0.20);
            }
        }

        /// <summary>
        /// Changes the state of the account.
        /// </summary>
        public void ChangeState()
        {
            state = State.Closed;
        }
    }
}
