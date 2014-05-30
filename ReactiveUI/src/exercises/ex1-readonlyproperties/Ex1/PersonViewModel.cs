using ReactiveUI;

namespace Ex1
{
    public class PersonViewModel : ReactiveObject
    {
        public PersonViewModel()
        {

        }

        //TODO: Add a read-only property for FullName

        private string _firstName;
		private string _lastName;
		private string _fullName;

		public string FullName
		{
			get { return _firstName+  " " + _lastName; }
		}

        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }

		public string LastName
		{
			get { return _lastName; }
			set { this.RaiseAndSetIfChanged(ref _lastName, value); }
		}

        //TODO: Add a second read-write property for LastName
    }
}
