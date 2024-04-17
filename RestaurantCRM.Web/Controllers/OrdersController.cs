using Microsoft.AspNetCore.Mvc;
using RestaurantCRM.Domain.DTO;
using RestaurantCRM.Domain.Entities;
using RestaurantCRM.Service.Interface;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IOrderService _orderService;
        private readonly IMenuItemService _menuItemService;


        public OrdersController(IOrderService orderservice, IRestaurantService restaurantservice, IMenuItemService menuItemService)
        {
            _restaurantService = restaurantservice;
            _orderService = orderservice;
            _menuItemService = menuItemService;

        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [Route("CreateNewOrder")]
        [HttpPost]
        public IActionResult CreateNewOrder([FromBody] OrderDTO order)
        {
            Restaurant restaurant = _restaurantService.GetById(order.RestaurantId);
            Order order_to_create = new Order();
            order_to_create.TableNumber = 1;
            order_to_create.RestaurantId = order.RestaurantId;
            order_to_create.Restaurant = restaurant;
            List<MenuItem> itemsOrdered = new List<MenuItem>();
            foreach(var item in order.MenuItems)
            {
                MenuItem newItem = _menuItemService.GetMenuItemById(item.Id);
                itemsOrdered.Add(newItem);
            }
            order_to_create.ItemsOrdered = itemsOrdered;

            return Ok(order_to_create);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
