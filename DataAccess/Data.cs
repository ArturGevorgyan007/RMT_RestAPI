using System.Text.Json;
using Model;
using System.Linq;

namespace DataAccess;
public class Data
{   
    // I save the data in JSON format in CustomerLogs.json file. Alternatively I could create SQL table and save the data in database
    private const string _filePath = "./DataAccess/CustomerLogs.json";
    private string[] _firstNames = new string[10] { "Leia", "Sadie", "Jose","Sara","Frank","Dewey","Tomas","Joel","Lukas","Carlos"};
    private string[] _lastNames = new string[10] { "Liberty", "Ray","Harrison","Ronan","Drew","Powell","Larsen","Chan","Anderson","Lane"};

    public Data() {
        
        bool fileExists = File.Exists(_filePath);

        // When we initialize this class, let's make sure the file we want to modify exists, and if not, let's create it.
        if(!fileExists) {
            var fs = File.Create(_filePath);
            fs.Close();
        }
    }

    public List<Customer> GetAllCustomers() {
        // Open the file, read the content, close the file
        string fileContent = File.ReadAllText(_filePath);
        if(new FileInfo( "./DataAccess/CustomerLogs.json" ).Length != 0) 
            // take the read string, and deserialize it back to List of Customers
            return JsonSerializer.Deserialize<List<Customer>>(fileContent);
        else
            return new List<Customer>();
    }

    public Customer[] CreateNewCustomer(Customer[] customerArray) {
        List<Customer> customers = new List<Customer>();

        if(new FileInfo( "./DataAccess/CustomerLogs.json" ).Length != 0) 
            customers = GetAllCustomers();

        foreach (Customer customerToCreate in customerArray) {
            Random randomAge = new Random();
            customerToCreate.age = randomAge.Next(10,81);
            Random randomFirstName = new Random();
            int randomIndexFirstName = randomFirstName.Next(0, 10);
            customerToCreate.firstName = _firstNames[randomIndexFirstName];
            Random randomLastName = new Random();
            int randomIndexLastName = randomLastName.Next(0, 10);
            customerToCreate.lastName = _lastNames[randomIndexLastName];

            //I set current id of customer next value of ids of all customers in the list (maxId+1). 
            //If list is empty we got our first customer, so id=1
            if(customers.Count!=0){
                var maxId=customers.Max(p => p.id);
                customerToCreate.id=(customers.Where(x => x.id == maxId).FirstOrDefault()).id+1;
            }
            else
                customerToCreate.id=1;

            // Adding new customer to the list
            customers.Add(customerToCreate);
        }


       
        //As I am not allowed to use any available sorting functions, I implemented sortArray function
        customers=sortArray(customers);

        // Below line another way of sorting using LINQ methods
        // customers = customers.OrderBy(p => p.lastName).ThenBy(p => p.firstName).ToList();

        // Serializing the list as string and writing it back to the file
        string content = JsonSerializer.Serialize(customers);
        File.WriteAllText(_filePath, content);

        return customerArray;
    }

    //sortArray function implements Bubble Sort algorithm
    List<Customer> sortArray(List<Customer> arr) {
        for (int i = 0; i < arr.Count-1; i++) {
            for (int j=i+1; j < arr.Count;j++) {
                if(string.Compare(arr[i].lastName, arr[j].lastName) > 0 || 
                (string.Compare(arr[i].lastName, arr[j].lastName) == 0 && 
                string.Compare(arr[i].firstName, arr[j].firstName) > 0)){
                    Customer temp = arr[i];
                    arr[i]=arr[j];
                    arr[j]=temp; 
                }
            }
        }
        return arr;
    }

}
