using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TranaWarePc.Models;
using TranaWarePc.Services;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOrderService _orderService;

    public CartController(ICartService cartService, UserManager<ApplicationUser> userManager, IOrderService orderService)
    {
        _cartService = cartService;
        _userManager = userManager;
        _orderService = orderService;
    }

    [Authorize]
    public IActionResult Index()
    {
        var cart = _cartService.GetCart();
        return View(cart);
    }

    public async Task< IActionResult > AddToCart(int productId, int quantity = 1)
    {
        await _cartService.AddToCartAsync(productId, quantity);
        return RedirectToAction("Index");
    }

    public IActionResult RemoveFromCart(int productId)
    {
        _cartService.RemoveFromCart(productId);
        return RedirectToAction("Index");
    }

    public IActionResult ClearCart()
    {
        _cartService.ClearCart();
        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = _cartService.GetCart();
        return View(cart);
    }

    [HttpPost]
    public IActionResult SubmitOrder()
    {
        // Save order logic
        _cartService.ClearCart();
        return RedirectToAction("ConfirmOrder", "Cart");
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmOrder()
    {
        var userId = _userManager.GetUserId(User);
        var cartItems = await _cartService.GetCartItemsAsync(userId);
        var cart = _cartService.GetCart(); // Get the entire cart object
        var totalPrice = cart.TotalPrice;

        // Place the order
        var orderId = await _orderService.PlaceOrderAsync(userId, cartItems, totalPrice);

        // Clear the cart if the order was successfully placed
        if (orderId != 0)
        {
            await _cartService.ClearCartAsync(userId);
            _cartService.ClearCart();
            // Redirect to the "Your Orders" page or any other appropriate page
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Handle the case where the order couldn't be placed (optional)
            // You can display an error message or handle it as needed
            return RedirectToAction("Index", "Cart"); // Redirect back to the cart page, for example
        }
    }




}
