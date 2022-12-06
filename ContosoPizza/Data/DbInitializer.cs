using ContosoPizza.Models;

namespace ContosoPizza.Data
{
  public static class DbInitializer
  {
    public static void Initialize(PizzaContext context)
    {
      if (context.Pizzas.Any()
          && context.Toppings.Any()
          && context.Sauces.Any())
      {
        return;
      }

      var pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 130 };
      var sausageTopping = new Topping { Name = "Sausage", Calories = 100 };
      var hamTopping = new Topping { Name = "Ham", Calories = 70 };
      var chickenTopping = new Topping { Name = "Chicken", Calories = 50 };
      var pineappleTopping = new Topping { Name = "Pineapple", Calories = 75 };

      var TomatoSauce = new Sauce { Name = "Tomato", isVegan = true };
      var alfredoSauce = new Sauce { Name = "Alfredo", isVegan = false };

      var pizzas = new Pizza[]
      {
        new Pizza
          {
            Name = "Meat Lovers",
            Sauce = TomatoSauce,
            Toppings = new List<Topping>
              {
                pepperoniTopping,
                sausageTopping,
                hamTopping,
                chickenTopping
              }
          },
        new Pizza
          {
            Name = "Hawaiian",
            Sauce = TomatoSauce,
            Toppings = new List<Topping>
              {
                pineappleTopping,
                hamTopping
              }
          },
        new Pizza
          {
            Name = "Alfredo Chicken",
            Sauce = alfredoSauce,
            Toppings = new List<Topping>
              {
                chickenTopping
              }
          }
      };

      context.Pizzas.AddRange(pizzas);
      context.SaveChanges();
    }
  }
}