using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Solution;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IRepository repository;
        private IEnumerable<ICheker> cheker;

        public PasswordCheckerService(IRepository repository, IEnumerable<ICheker> cheker)
        {
            if (ReferenceEquals(repository, null))
            {
                throw new ArgumentNullException($"{repository} is null!");
            }

            if (ReferenceEquals(cheker, null))
            {
                throw new ArgumentNullException($"{cheker} is null!");
            }

            this.repository = repository;
            this.cheker = cheker;
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            bool state = false;
            string message = String.Empty;

            foreach (var i in cheker)
            {
                state = i.VerifyPassword(password).Item1;
                message = i.VerifyPassword(password).Item2;

                if (!state)
                {
                    return Tuple.Create(state, message);
                }
            }

            repository.Create(password);
            return Tuple.Create(state, message);
        }
    }
}
