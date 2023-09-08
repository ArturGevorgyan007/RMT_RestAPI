using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Model;


namespace Rest_server.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly Data _data = new Data();

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/GetCustomer")]
    public IEnumerable<Customer> Get()
    {
        return _data.GetAllCustomers();
    }

    [HttpPost]
    public ActionResult<Customer> Create(Customer[] customerToCreate)
    {
        return Created("/AddCustomers", _data.CreateNewCustomer(customerToCreate));
    }
}
