using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantCRM.Domain.DTO;
using RestaurantCRM.Domain.Entities;
using RestaurantCRM.Service.Interface;

namespace RestaurantCRM.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMenuItemService _menuItemService;

        public RestaurantsController(IRestaurantService restaurantService, IMenuItemService menuItemService)
        {
            _restaurantService = restaurantService;
            _menuItemService = menuItemService;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(_restaurantService.GetAll());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id);
            List<MenuItem> items = _menuItemService.GetMenuItems(id);
            restaurant.MenuItems = items;
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Address,City,PhoneNumber")] Restaurant restaurant)
        {
            
            if (ModelState.IsValid)
            {
                _restaurantService.AddNew(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        public IActionResult AddNewMenuItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMenuItem(Guid id, [Bind("Name,ListOfIngredients,Price,Category")] MenuItemDTO menuItemDTO)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    MenuItem newItem = new MenuItem();
                    newItem.Name = menuItemDTO.Name;
                    newItem.ListOfIngredients = menuItemDTO.ListOfIngredients;
                    newItem.Price = menuItemDTO.Price;
                    newItem.Category = menuItemDTO.Category;
                    newItem.RestaurantId = id;
                    _menuItemService.Create(newItem);
                    _restaurantService.AddNewItem(id, newItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_restaurantService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Address,City,PhoneNumber,Id")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _restaurantService.Edit(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_restaurantService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant != null)
            {
                _restaurantService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
