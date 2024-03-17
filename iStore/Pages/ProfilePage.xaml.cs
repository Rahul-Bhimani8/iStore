namespace iStore.Pages
{
    public partial class ProfilePage : ContentPage, INotifyPropertyChanged
    {
        private Employee _employee;
    public event PropertyChangedEventHandler PropertyChanged;
    private readonly DatabaseHelper _databaseHelper; // Database helper for CRUD operations
    public Employee Employee
    {
        get { return _employee; }
        set
        {
            if (_employee != value)
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
    }

    public MainPage()
    {
        InitializeComponent();

        // Inicialización de DatabaseHelper y obtención del Employee inicial
        _databaseHelper = new DatabaseHelper();
        Employee = GetEmployee("agaviria");
        BindingContext = this;
        //CreateFirst();
        //CreateFirstA();
        //CreateFirstB();
    }

    private void OnLoadEmployee(object sender, EventArgs e)
    {
        string username = employeeEntry.Text;
        Employee = GetEmployee(username);
    }

    private Employee GetEmployee(string username)
    {
        return _databaseHelper.GetEmployee(username);
    }

    private void CreateFirst()
    {
        var employee = new Employee { FirstName = "Sneha",
            LastName = "Patel",
            User = "spatel",
            DateOfBirth = "2004-01-01",
            Password="S.Patel"
        };
        _databaseHelper.AddEmployee(employee); // Add the student to the database
    }

    private void CreateFirstA()
    {
        var employee = new Employee
        {
            FirstName = "Aryan",
            LastName = "Rana",
            User = "arana",
            DateOfBirth = "2005-01-01",
            Password = "A.Rana"
        };
        _databaseHelper.AddEmployee(employee); // Add the student to the database
    }

    private void CreateFirstB()
    {
        var employee = new Employee
        {
            FirstName = "Rahul",
            LastName = "Bhimani",
            User = "rbhimani",
            DateOfBirth = "2000-01-01",
            Password = "R.Bhimani"
        };
        _databaseHelper.AddEmployee(employee); // Add the student to the database
    }
    private void OnAddStudentClicked(object sender, EventArgs e)
    {
        // Get the input values
        /*var name = nameEntry.Text;
        var age = int.TryParse(ageEntry.Text, out var parsedAge) ? parsedAge : 0; // Basic validation

        // Check for valid input
        if (!string.IsNullOrWhiteSpace(name) && age > 0)
        {
            var student = new Student { Name = name, Age = age };
            _databaseHelper.AddStudent(student); // Add the student to the database
            LoadStudents(); // Reload the student list

            // Clear the input fields
            nameEntry.Text = string.Empty;
            ageEntry.Text = string.Empty;
        }*/
    }

    private async void OnEditEmployeeInvoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var employee = swipeItem.BindingContext as Employee;

        // Prompt the user for new values
        /*var newName = await DisplayPromptAsync("Edit Student", "Enter new name:", initialValue: employee.Name);
        var newAge = await DisplayPromptAsync("Edit Student", "Enter new age:", initialValue: employee.Age.ToString(), keyboard: Keyboard.Numeric);

        // Update the student if valid input was provided
        if (!string.IsNullOrWhiteSpace(newName) && int.TryParse(newAge, out var age))
        {
            _databaseHelper.UpdateStudent(new Student { Id = employee.Id, Name = newName, Age = age });
            LoadStudents(); // Reload the student list
        }*/
    }

    private void OnDeleteEmployeeInvoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var employee = swipeItem.BindingContext as Employee;

        _databaseHelper.DeleteEmployee(employee.Id); // Delete the student from the database
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
}
