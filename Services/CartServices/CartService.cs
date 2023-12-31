﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Services.CartServices
{
	public class CartService : ICartService
	{
		private readonly RestaurantDbContext _context;
		public CartService(RestaurantDbContext context)
		{
			_context = context;
		}

		// adds the cart to the Orders database
		//public async Task<bool> Order(OrderModel cart)
		//{
		//	_context.Orders.Add(cart);
		//	await _context.SaveChangesAsync();
		//	return true;
		//}
        public async Task<int> Order(OrderModel cart)
        {
            _context.Orders.Add(cart);
            await _context.SaveChangesAsync();
            cart = await _context.Orders.OrderByDescending(c => c.Id).FirstOrDefaultAsync();
    
            return cart.Id;
        }
        // deletes a product from users cart, 
        //public void RemoveProduct(OrderModel cart, ProductModel product)
        //{
        //	cart.Products.Remove(product);
        //}
        //public void AddToCart(OrderModel cart, ProductModel product)
        //{
        //	cart.Products.Add(product);
        //}
    }
}
