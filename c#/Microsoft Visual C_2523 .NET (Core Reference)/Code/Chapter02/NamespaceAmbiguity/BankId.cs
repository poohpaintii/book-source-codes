using System;

namespace BankTypes
{
	public class Id
	{
        string _identifier;

		public Id(string Identifier)
		{
            _identifier = Identifier;
		}

        public string GetId()
        {
            return _identifier;
        }
	}
}